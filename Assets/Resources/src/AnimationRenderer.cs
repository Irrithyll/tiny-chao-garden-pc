using UnityEngine;
using System.Collections;

public class Animation {
    public static Animation Sit = new Animation(new int[] { 3 });
    public static Animation Trumpet = new Animation(new int[] { 0, 1 });
    public static Animation Pet = new Animation(new int[] { 6, 7, 8 });
    public static Animation Walk = new Animation(new int[] { 22, 26 });

    public int[] frames;
    public Animation(int[] frames) {
        this.frames = frames;
    }
}


public class AnimationRenderer : MonoBehaviour {
    public Sprite[] spriteFrames;
    public Animation currAnim = Animation.Sit;
    SpriteRenderer spriteRenderer;
    float frameElapsed;
    int frameIndex;

    public void PlayAnimation(Animation anim) {
        currAnim = anim;
    }

	void Start () {
        spriteFrames = Resources.LoadAll<Sprite>("img/sprites/chao/chao_amethyst");
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
        frameElapsed += Time.deltaTime;
        if (frameElapsed > 1) {
            frameIndex += 1;
            frameElapsed = 0;
        }

        if (frameIndex >= currAnim.frames.Length)
            frameIndex = 0;

        spriteRenderer.sprite = spriteFrames[currAnim.frames[frameIndex]];
	}
}
