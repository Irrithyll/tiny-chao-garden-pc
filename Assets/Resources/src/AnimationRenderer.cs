using UnityEngine;
using System.Collections;

public class Animation {
    // chao animations
    public static Animation Idle = new Animation(new int[] { 24 });

    public static Animation Sit = new Animation(new int[] { 3 });
    public static Animation Trumpet = new Animation(new int[] { 0, 1 });
    public static Animation Pet = new Animation(new int[] { 6, 7, 8, 7 });

    public static Animation WalkUp = new Animation(new int[] { 19, 20, 21 });
    public static Animation WalkDown = new Animation(new int[] { 22, 26 });

    public static Animation BlinkSit = new Animation(new int[] { 4, 3, 4 });
    public static Animation Sleep = new Animation(new int[] { 4, 5 });
    public static Animation BlinkStandLeft = new Animation(new int[] { 9, 10, 9 });
    public static Animation Cry = new Animation(new int[] { 15, 16 });
    public static Animation ThinkEyesOpen = new Animation(new int[] { 17 });
    public static Animation ThinkEyesClosed = new Animation(new int[] { 18 });

    public static Animation PokeOutTongue = new Animation(new int[] { 30, 31 });
    public static Animation Frown = new Animation(new int[] { 32 });
    public static Animation JumpForJoy = new Animation(new int[] { 33, 34 });
    public static Animation FallDown = new Animation(new int[] { 39, 40, 41 });
    public static Animation ShakeHead = new Animation(new int[] { 44, 45, 46 });
    public static Animation Wave = new Animation(new int[] { 47, 48 });
    public static Animation Eat = new Animation(new int[] { 49, 50 });

    // chao expression animations
    public static Animation eNormal = new Animation(new int[] { 4 });
    public static Animation eHeart = new Animation(new int[] { 2, 3 });
    public static Animation eHurt = new Animation(new int[] { 0, 1 });
    public static Animation eQuestion = new Animation(new int[] { 5 });
    public static Animation eExclaim = new Animation(new int[] { 6 });

    public int[] frames;
    public Animation(int[] frames) {
        this.frames = frames;
    }
}


public class AnimationRenderer : MonoBehaviour {
    public Sprite[] spriteFrames;
    public Animation currAnim = Animation.Sit;
    public SpriteRenderer spriteRenderer;
    public float frameElapsed;
    public int frameIndex;

    public void PlayAnimation(Animation anim) {
        currAnim = anim;
    }

    public void StopAnimation()
    {
        currAnim = Animation.Idle;
    }

	void Start () {
        spriteFrames = Resources.LoadAll<Sprite>("img/sprites/chao/chao_normal");
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
        frameElapsed += Time.deltaTime;
        if (frameElapsed > 0.4f) {
            frameIndex += 1;
            frameElapsed = 0;
        }

        if (frameIndex >= currAnim.frames.Length)
            frameIndex = 0;

        spriteRenderer.sprite = spriteFrames[currAnim.frames[frameIndex]];
	}
}
