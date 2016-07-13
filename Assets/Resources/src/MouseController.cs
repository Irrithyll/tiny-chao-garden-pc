using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

    Vector2 mousePos;
    public Texture2D cursorNORMAL;
    public Texture2D cursorOPEN;
    public Texture2D cursorCLOSED;
    public Texture2D cursorREOPEN;
    private Texture2D cursorTexture;
       
    int w = 16;
    int h = 16;

    Ray ray;
    RaycastHit hit;


	// Use this for initialization
	void Start () {
        cursorTexture = cursorNORMAL;
	}

    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.gameObject);
        }

    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(mousePos.x - (w / 2), mousePos.y - (h / 2), w, h), cursorTexture);
    }

    public void updateCursorIamge(string type) {

        if (type == "NORMAL") {
            cursorTexture = cursorNORMAL;
        }
        else if (type == "OPEN") {
            cursorTexture = cursorOPEN;
        }
        else if (type == "CLOSED") {
            cursorTexture = cursorCLOSED;
        }
        else
        {


        }
    }
}
