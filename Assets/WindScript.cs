using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public Transform fanParent;
    public float fanForce = 1;
    public bool isCollidingWithFan;
    private void Update()
    {
        if(isCollidingWithFan)
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.GetComponent<Rigidbody2D>().AddForce(-fanParent.right * fanForce, ForceMode2D.Force);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && transform.GetComponent<Rigidbody2D>() != null) 
        {
            fanParent = collision.transform;
            isCollidingWithFan = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && transform.GetComponent<Rigidbody2D>() != null)
        {
            fanParent = null;
            isCollidingWithFan = false;
        }
    }
}
