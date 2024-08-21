using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetBehaviour : MonoBehaviour
{
    public float magnetForce = 10f;
    public float magnetSize;
    public Transform redpole;
    public LayerMask ignoreLayers;
    public float magnetLength = 2f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        magnetSize = MathF.Abs( transform.localScale.x + transform.localScale.y)*MathF.Sign(transform.localScale.y) * magnetLength;
        RaycastHit2D hit = Physics2D.Raycast(redpole.position, -transform.up, magnetSize, ~ignoreLayers);
        Debug.DrawRay(redpole.position, -transform.up * magnetSize, Color.red);
        if (hit.collider != null)
        {
        Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Metal")
            {
                Debug.Log("pulling");
                hit.collider.GetComponent<Rigidbody2D>().AddForce((transform.position - hit.collider.transform.position) * magnetForce);
            }
        }
    }
}
