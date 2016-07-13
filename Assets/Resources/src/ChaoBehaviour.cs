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
            return;
        }

        if (Vector2.Distance(transform.position, walkTarget) > walkSpeed*Time.deltaTime) {
            transform.Translate((walkTarget - (Vector2)transform.position).normalized * walkSpeed * Time.deltaTime);
            anim.PlayAnimation(Animation.Walk);
        } else if (anim.currAnim == Animation.Walk) {
            transform.position = walkTarget;
            anim.PlayAnimation(Animation.Sit);
        }

        if (action == Action.PlayTrumpet) {
            if (heldItem == null) {                
                var trumpet = garden.GetComponentInChildren<Trumpet>();
                walkTarget = trumpet.transform.position;

                if (Vector2.Distance(transform.position, walkTarget) < walkSpeed*Time.deltaTime) {
                    PickUp(trumpet.GetComponent<Transform>());
                }
            } else if (heldItem.GetComponent<Trumpet>()) {
                anim.PlayAnimation(Animation.Trumpet);
            }
        }

        //walkTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

    void updateSprite() {
        if (chao.isEgg())
            return;

        anim.spriteFrames = Resources.LoadAll<Sprite>("img/sprites/chao/chao_normal");

/*        if (chao.colour == Chao.ColourSA2B.Black || chao.texture == Chao.TextureSA2B.BlackJewel)
        {
            //set to onyx sprite
            anim.spriteFrames = Resources.LoadAll<Sprite>("img/sprites/chao/chao_normal");
        }else if (chao.colour == Chao.ColourSA2B.Blue || chao.texture == Chao.TextureSA2B.BlueJewel){
            anim.frames = Resources.LoadAll<Sprite>("img/sprites/chao/chao_normal");
        }
        else if (chao.colour == Chao.ColourSA2B.Red || chao.texture == Chao.TextureSA2B.RedJewel)
        {
            anim.frames = Resources.LoadAll<Sprite>("img/sprites/chao/chao_normal");
        }
        else
        {
            anim.frames = Resources.LoadAll<Sprite>("img/sprites/chao/chao_normal");
        }*/
    }

    void OnMouseDown() {
        isBeingPet = true;
    }

    void OnMouseUp() {
        isBeingPet = false;
    }
}
