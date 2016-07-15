using UnityEngine;
using System.Collections;

public enum Action {
    Idle,
    PlayTrumpet
}

public class ChaoBehaviour : MonoBehaviour {
    public Chao chao;
    int frameIndex = 0;
    float frameElapsed = 0;
    AnimationRenderer anim;
    public Action action = Action.Idle;
    Transform heldItem = null;

    Garden garden;
    Vector2 walkTarget = new Vector2(-1,-1);
    float walkSpeed = 1f;
    bool isBeingPet = false;

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
            anim.PlayAnimation(Animation.Pet);
            DropHeldItem();
            return;
        }

        if (Vector2.Distance(transform.position, walkTarget) > walkSpeed*Time.deltaTime) {
            //walk towards something
            transform.Translate((walkTarget - (Vector2)transform.position).normalized * walkSpeed * Time.deltaTime);
            anim.PlayAnimation(Animation.WalkDown);
        } else if (anim.currAnim == Animation.WalkDown) {
            //sit
            transform.position = walkTarget;
            anim.PlayAnimation(Animation.Sit);
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
                anim.PlayAnimation(Animation.Trumpet);
            }
        }

        //walkTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
