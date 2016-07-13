using UnityEngine;
using System.Collections;

public class StatsDisplay : MonoBehaviour {

    public Transform mood;
    public Transform belly;
    public Transform swim;
    public Transform fly;
    public Transform run;
    public Transform power;
    public Transform stamina;
    public Transform garden;

    public Sprite blue_0;
    public Sprite blue_1;
    public Sprite blue_2;
    public Sprite blue_3;
    public Sprite blue_4;
    public Sprite blue_5;
    public Sprite blue_6;
    public Sprite blue_7;
    public Sprite blue_8;
    public Sprite blue_9;
    public Sprite blue_10;

    ChaoBehaviour chaoBehaviour; 
    private SpriteRenderer tempSprite;
    private Chao chao;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        chaoBehaviour = garden.GetComponentInChildren<ChaoBehaviour>();
        chao = chaoBehaviour.chao;

        if (chaoBehaviour == null)
        {

            Debug.Log("chaoBehaviour is null!");
        }
        if (chao == null)
        {
            Debug.Log("chao is null!");
        }


        setBarImage(chao.runStatBar, run);
        setBarImage(chao.swimStatBar, swim);
        setBarImage(chao.staminaStatBar, stamina);
        setBarImage(chao.powerStatBar, power);
        setBarImage(chao.flyStatBar, fly);
        //setBarImage(chao.moodStatBar, mood);
        //setBarImage(chao.bellyStatBar, belly);
        
        

    }


    public void setBarImage(int statBar, Transform stat)
    {
        tempSprite = stat.GetComponent<SpriteRenderer>();
        switch (statBar)
        {
            case 0:
                tempSprite.sprite = blue_0;
                break;
            case 1:
                tempSprite.sprite = blue_1;
                break;
            case 2:
                tempSprite.sprite = blue_2;
                break;
            case 3:
                tempSprite.sprite = blue_3;
                break;
            case 4:
                tempSprite.sprite = blue_4;
                break;
            case 5:
                tempSprite.sprite = blue_5;
                break;
            case 6:
                tempSprite.sprite = blue_6;
                break;
            case 7:
                tempSprite.sprite = blue_7;
                break;
            case 8:
                tempSprite.sprite = blue_8;
                break;
            case 9:
                tempSprite.sprite = blue_9;
                break;
            case 10:
                tempSprite.sprite = blue_10;
                break;
        }
        return;
    }
}
