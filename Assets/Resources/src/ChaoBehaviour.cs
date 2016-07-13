using UnityEngine;
using System.Collections;

public class ChaoBehaviour : MonoBehaviour {

    private enum Animation
    {
        None,
        Sit,
        Trumpet

    }

    public Chao chao;
    private SpriteRenderer chaoSprite;
    Sprite[] chaoSprites;
    private Animation currAnim = Animation.None;
    int frameIndex = 0;
    float frameElapsed = 0;


    void Awake()
    {
        chaoSprites = Resources.LoadAll<Sprite>("img/sprites/chao/chao_amethyst");
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

        Debug.Log("CHAO NAME : " + chao.name);
        chaoSprite = GetComponent<SpriteRenderer>();
        updateSprite();

        currAnim = Animation.Sit;
        
	}
	
	// Update is called once per frame
	void Update () {

        chao.ageDelta += Time.deltaTime;
        Debug.Log("Age Delta: " + (chao.ageDelta));

        if (chao.ageDelta > 60 && chao.isEgg())
        {
            chao.hatch();
            updateSprite();
        }

        updateAnimation();
	
	}

    void updateSprite() {
        if (chao.isEgg())
        {

            return;
        }
        if (chao.colour == Chao.ColourSA2B.Black || chao.texture == Chao.TextureSA2B.BlackJewel)
        {
            //set to onyx sprite
            chaoSprite.sprite = Resources.Load<Sprite>("img/sprites/chao/chao_normal");
            return;
        }else if (chao.colour == Chao.ColourSA2B.Blue || chao.texture == Chao.TextureSA2B.BlueJewel){
            //set to sapphire sprite
            chaoSprite.sprite = Resources.Load<Sprite>("img/sprites/chao/chao_normal");
            return;
        }
        else if (chao.colour == Chao.ColourSA2B.Red || chao.texture == Chao.TextureSA2B.RedJewel)
        {
            //set to garnet sprite
            chaoSprite.sprite = Resources.Load<Sprite>("img/sprites/chao/chao_normal");
            return;
        }
        else
        {
            //set to normal sprite
            chaoSprite.sprite = chaoSprites[3];
            return;
        }

    }

    void playAnimation()
    {

        return;
    }

    void updateAnimation()
    {

        frameElapsed += Time.deltaTime;

        if (currAnim == Animation.Trumpet)
        {
            if (frameElapsed > 1)
            {
                if (frameIndex == 0) { frameIndex = 1; }
                else {frameIndex = 0;}
                frameElapsed = 0;

            }
            chaoSprite.sprite = chaoSprites[frameIndex];

        }
        else if (currAnim == Animation.Sit)
        {
            chaoSprite.sprite = chaoSprites[3];
        }
        else
        {
            chaoSprite.sprite = chaoSprites[3];
        }

        return;
    }



}
