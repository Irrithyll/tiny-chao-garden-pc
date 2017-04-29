using UnityEngine;
using System.Collections;

public enum Action {
    Idle,
    PlayTrumpet,
    Walk,
    Think,
    Sleep,
    Cry,
    Frown,
    JumpForJoy,
    FallDown,
    ShakeHead,
    Wave,
    Eat
}

public class ChaoBehaviour : MonoBehaviour {

    public Chao chao; // holds chao data

    int frameIndex = 0;
    float frameElapsed = 0;
    AnimationRenderer anim; // controls animations

    Transform heldItem = null;

    Garden garden; // has all garden information
    Vector2 walkTarget = new Vector2(-1,-1);

    float walkSpeed = 0.5f; 
    bool isBeingPet = false;


    public Action action = Action.Idle; // handles chao's current actions
    public int actionTimer = 0; // times how long actions last
    public int maxActionTime = 100; // maximum duration for an action

    void Awake()
    {
        anim = GetComponent<AnimationRenderer>();
    }

	// Use this for initialization
	void Start () {
        garden = GetComponentInParent<Garden>();

        if (NewGame.newGame == true)
        {
            chao = new Chao();
            chao.initEgg(false);

        }else{ //load existing chao
            chao = new Chao();
            chao = chao.loadChaoFile();
            chao.initEgg(false);
        }

        chao.setTestChao();
        action = Action.PlayTrumpet;
//        Debug.Log("CHAO NAME : " + chao.name);
	}

    void PickUp(Transform item) {
        heldItem = item;
        item.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void DropHeldItem()
    {
        heldItem.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        heldItem = null;
    }
	
	void Update () {
        chao.ageDelta += Time.deltaTime;
//        Debug.Log("Age Delta: " + (chao.ageDelta));

        if (chao.ageDelta > 60 && chao.isEgg())
        {
            chao.hatch();
            updateSprite();
        }

        if (isBeingPet) {
            if (chao.isEgg())
                return; // handle some condition to age egg faster

            anim.PlayAnimation(Animation.Pet);
            DropHeldItem();
            return;
        }

        if (action == Action.PlayTrumpet) {
            //find the trumpet
            var trumpet = GameObject.Find("Trumpet");
            if (trumpet == null) { 
                //don't do anything if the trumpet doesn't exist
                action = Action.Idle; 
                return; 
            }
            if (heldItem == null) {                
                //var trumpet = garden.GetComponentInChildren<Trumpet>();
                
                //walk towards the trumpet
                walkTarget = trumpet.transform.position;
                if (Vector2.Distance(transform.position, walkTarget) < walkSpeed*Time.deltaTime) {
                    PickUp(trumpet.GetComponent<Transform>());
                }
            } else if (heldItem == trumpet.transform) {
                //play the trumpet animation
                playTrumpet();
                return;
            }
        }

        if (Vector2.Distance(transform.position, walkTarget) > walkSpeed * Time.deltaTime)
        {
            //walk towards something
            transform.Translate((walkTarget - (Vector2)transform.position).normalized * walkSpeed * Time.deltaTime);
            anim.PlayAnimation(Animation.WalkDown);
        }
        else if (anim.currAnim == Animation.WalkDown)
        {
            //sit
            transform.position = walkTarget;
            anim.PlayAnimation(Animation.Sit);
        }

        //walkTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void playTrumpet()
    {
        anim.PlayAnimation(Animation.Trumpet);
        updateAction();

    }

    void updateAction()
    {
        actionTimer++;

        if(actionTimer >= maxActionTime)
        {
            actionTimer = 0;
            action = Action.Idle;
        }
    }

    void updateSprite() {
        if (chao.isEgg())
            return;

        anim.spriteFrames = Resources.LoadAll<Sprite>("img/sprites/chao/chao_normal");

    }

    void OnMouseDown() {
        isBeingPet = true;
    }

    void OnMouseUp() {
        isBeingPet = false;
    }
}
