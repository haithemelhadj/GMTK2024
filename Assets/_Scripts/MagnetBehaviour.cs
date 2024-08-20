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
    public LayerMask player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        magnetSize = (transform.localScale.x + transform.localScale.y) * 2f;
        RaycastHit2D hit = Physics2D.Raycast(redpole.position, -transform.up, magnetSize, ~player);
        Debug.DrawRay(redpole.position, -transform.up * magnetSize, Color.red);
        Debug.Log(hit.collider.tag);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Metal")
            {
                Debug.Log("pulling");
                hit.collider.GetComponent<Rigidbody2D>().AddForce((transform.position - hit.collider.transform.position) * magnetForce);
            }
        }
    }
}
