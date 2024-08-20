using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{

    //just to make it easier for us to make levels
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer2;
    void Start()
    {
        spriteRenderer.enabled = false;
        spriteRenderer2.enabled = false;
    }
}
