using UnityEngine;
using System.Collections;

public class OnLoad : MonoBehaviour {

    public Transform chaoPrefab;
    GameObject chaoGO;

    void Awake() {


    }

	// Use this for initialization
	void Start () {
        //Cursor.visible = false;
        Instantiate(chaoPrefab);

	}
	


}
