using UnityEngine;
using System.Collections;

public class OnLoad : MonoBehaviour {

    public Transform chaoPrefab;
    Transform chao;

    void Awake() {


    }

	// Use this for initialization
	void Start () {
        //Cursor.visible = false;
        chao = Instantiate(chaoPrefab);
        chao.parent = transform;
        

	}
	


}
