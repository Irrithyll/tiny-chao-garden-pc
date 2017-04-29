using UnityEngine;
using System.Collections;

public class ExpressionRenderer : AnimationRenderer
{

    void Start()
    {
        spriteFrames = Resources.LoadAll<Sprite>("img/sprites/chao/expressions");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
