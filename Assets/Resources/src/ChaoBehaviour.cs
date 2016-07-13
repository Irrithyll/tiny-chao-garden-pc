using UnityEngine;
using System.Collections;

public class ChaoBehaviour : MonoBehaviour {


    public Chao chao;
    int frameIndex = 0;
    float frameElapsed = 0;
    AnimationRenderer anim;

    void Awake()
    {
        anim = GetComponent<AnimationRenderer>();
    }

	// Use this for initialization
	void Start () {
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

//        Debug.Log("CHAO NAME : " + chao.name);
	}
	
	// Update is called once per frame
	void Update () {
        chao.ageDelta += Time.deltaTime;
//        Debug.Log("Age Delta: " + (chao.ageDelta));

        if (chao.ageDelta > 60 && chao.isEgg())
        {
            chao.hatch();
            updateSprite();
        }
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
        anim.PlayAnimation(Animation.Pet);
    }

    void OnMouseUp() {
        anim.PlayAnimation(Animation.Sit);
    }
}
