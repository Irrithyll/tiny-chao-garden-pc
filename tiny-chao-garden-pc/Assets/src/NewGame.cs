using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

    void OnMouseDown() {
        createNewGame();
    }

    void OnMouseOver() {

    }

    public void createNewGame(){ 
        //initialize the game
        Debug.Log("CREATING NEW GAME, PLEASE WAIT....");


        //prepare a new chao egg	
        Debug.Log("PREPARING NEW CHAO EGG, PLEASE WAIT....");


        //go to chao_garden
        Debug.Log("LOADING CHAO GARDEN, PLEASE WAIT....");
        Application.LoadLevel("scene_chao_garden");

        
        //spawn new chao egg in garden
        Debug.Log("SPAWNING NEW CHAO EGG, PLEASE WAIT....");

    }

}
