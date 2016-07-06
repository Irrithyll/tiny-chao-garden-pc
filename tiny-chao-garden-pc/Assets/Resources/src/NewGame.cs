using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

    public static bool newGame = false;
    public static Chao chaoGLOBAL;


    void OnMouseDown() {
        createNewGame();
    }


    public void createNewGame(){ 
        //go to chao_garden
        Application.LoadLevel("scene_chao_garden");


    }

}
