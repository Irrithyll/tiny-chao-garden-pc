using UnityEngine;
using System.Collections;

public enum Animation {
    None,
    Sit,
    Trumpet
}


public class AnimationRenderer : MonoBehaviour {
    public Sprite[] frames;
    SpriteRenderer spriteRenderer;
    Animation currAnim = Animation.None;
    float frameElapsed;
    int frameIndex;

    public void PlayAnimation(Animation anim) {
        currAnim = anim;
    }

	void Start () {
        frames = Resources.LoadAll<Sprite>("img/sprites/chao/chao_amethyst");
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
        frameElapsed += Time.deltaTime;

        if (currAnim == Animation.Trumpet)
        {
            if (frameElapsed > 1)
            {
                if (frameIndex == 0) { frameIndex = 1; }
                else {frameIndex = 0;}
                frameElapsed = 0;

            }
            spriteRenderer.sprite = frames[frameIndex];

        }
        else if (currAnim == Animation.Sit)
        {
            spriteRenderer.sprite = frames[3];
        }
        else
        {
            spriteRenderer.sprite = frames[3];
        }
	}
}
