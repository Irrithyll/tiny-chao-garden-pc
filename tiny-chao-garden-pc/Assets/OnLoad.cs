using UnityEngine;
using System.Collections;

public class OnLoad : MonoBehaviour {

    public Transform chaoPrefab;
    Vector2 mousePos;
    public Texture2D cursorTexture;
    GameObject chaoGO;

    int h = 16;
    int w = 16;

    void Awake() {


    }

	// Use this for initialization
	void Start () {
        //Cursor.visible = false;
        Instantiate(chaoPrefab);

	}
	
	// Update is called once per frame
	void Update () {
        mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
	}

    void OnGUI() {
        GUI.DrawTexture(new Rect(mousePos.x - (w / 2), mousePos.y - (h / 2), w, h), cursorTexture);
    }

}
