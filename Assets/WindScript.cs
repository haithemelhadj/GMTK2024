using UnityEngine;

public class WindScript : MonoBehaviour
{
    public Transform fanParent;
    public float fanForce = 1;
    public float fanForceF = 1;
    public bool isCollidingWithFan;
    private void Update()
    {
        fanForce = 0.5f;
        //fanForce = fanForceF;
        if (isCollidingWithFan)
        {
            //transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //Vector2 direction = (Vector2)transform.position - (Vector2)fanParent.localPosition;
            //direction.y = 0f;
            //transform.GetComponent<Rigidbody2D>().velocity += (Vector2)fanParent.right * Mathf.Sign(-fanParent.localScale.x) * fanForce * Time.deltaTime; //   AddForce(-fanParent.right * Mathf.Sign(fanParent.localScale.x) * fanForce, ForceMode2D.Impulse);
            transform.GetComponent<Rigidbody2D>().AddForce(-fanParent.right * Mathf.Sign(fanParent.localScale.x) * fanForce, ForceMode2D.Impulse);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && transform.GetComponent<Rigidbody2D>() != null)
        {
            fanParent = collision.transform.parent;
            isCollidingWithFan = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && transform.GetComponent<Rigidbody2D>() != null)
        {
            fanParent = null;
            isCollidingWithFan = false;
        }
    }
}
