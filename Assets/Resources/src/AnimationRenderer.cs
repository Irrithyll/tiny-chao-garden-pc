using UnityEngine;
using System.Collections;

public class Animation {
    public static Animation Sit = new Animation(new int[] { 3 });
    public static Animation Trumpet = new Animation(new int[] { 0, 1 });
    public static Animation Pet = new Animation(new int[] { 6, 7, 8 });

    public int[] frames;
    public Animation(int[] frames) {
        this.frames = frames;
    }
}


public class AnimationRenderer : MonoBehaviour {
    public Sprite[] spriteFrames;
    SpriteRenderer spriteRenderer;
    Animation currAnim = Animation.Sit;
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
