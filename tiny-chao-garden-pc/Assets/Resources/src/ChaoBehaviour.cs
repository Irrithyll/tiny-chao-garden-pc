using UnityEngine;
using System.Collections;

public class ChaoBehaviour : MonoBehaviour {

    public Chao chao;
    

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

        Debug.Log("CHAO NAME : " + chao.name);

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
