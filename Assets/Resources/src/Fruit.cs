using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {

    int maxSize = 3;
    int currSize;

	// Use this for initialization
	void Start () {
        currSize = maxSize;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void reduceSize()
    {
        currSize--;
        if (currSize == 0)
        {
            //fruit has been eaten!
        }

    }


}
