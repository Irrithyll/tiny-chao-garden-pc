using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

    public Sprite spr_normal;
    public Sprite spr_hover;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        //hover over the button
        spriteRenderer.sprite = spr_hover;
    }

    void OnMouseExit()
    {
        //no longer hovering over the button
        spriteRenderer.sprite = spr_normal;
    }



}
