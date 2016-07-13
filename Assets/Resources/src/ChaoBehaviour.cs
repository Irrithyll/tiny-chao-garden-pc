using UnityEngine;
using System.Collections;

public class ChaoBehaviour : MonoBehaviour {

    public Chao chao;
    private SpriteRenderer chaoSprite;
    Sprite[] chaoSprites;



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



}
