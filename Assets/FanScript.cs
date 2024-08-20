using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{

    //just to make it easier for us to make levels
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer2;

    public ParticleSystem ps;
    void Start()
    {
        spriteRenderer.enabled = false;
        spriteRenderer2.enabled = false;
    }
    private void Update()
    {
        //ps.shape.scale = transform.localScale;
        //ps.shape.

        // Get the Shape module of the particle system
        var shape = ps.shape;

        // Set the Scale value (Vector3)
        shape.scale = transform.localScale;
    }
}
