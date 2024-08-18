using UnityEngine;

public class BoomerangLogicScript : MonoBehaviour
{
    public BoomerangThrowScript boomerangThrowScript;
    public float throwDuration;
    public float throwTime;
    public Transform throwStartingPosition;
    public GameObject boomerangObject;
    public Vector2 mousePos;
    public float throwForce;
    public Vector2 throwDirection;
    public bool isThrown = false;
    public Rigidbody2D rb;
    public Vector3 rotationVector = new Vector3(0f, 0f, 1f);
    public CircleCollider2D coll;

    private void Awake()
    {
        boomerangObject = this.gameObject;
        rb = boomerangObject.GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (isThrown)
        {
            flyingBoomerang();//code when the boomerang is thrown
        }
        else
        {
            //HeldBoomerang();
        }
    }

    public void ThrowBoomerang()
    {
        rb.velocity = Vector2.zero;
        isBeingThrown = true;
        rb.gravityScale = 0f;
        transform.position = throwStartingPosition.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        throwDirection = (mousePos - (Vector2)throwStartingPosition.position).normalized;
        throwTime = Time.time;
        coll.isTrigger = true;
        isThrown = true;
    }



    private void flyingBoomerang()
    {
        //check if the player didn't catch the boomerang
        if (Vector2.Distance(lastPlayerPos, boomerangObject.transform.position) < disapearDistance && !isBeingThrown)
        {
            //isThrown = false;
            isFalling = true;
            coll.isTrigger = false;
            rb.gravityScale = 4f;
            Debug.Log("didn't catch");
        }
        else if (Time.time - throwTime > throwDuration)//this is not "else" for gameplay reason and to add other conditions
        {
            Back();
            boomerangObject.transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime);
        }
        //check if the has thrown the boomerang or not
        else
        {
            Throw();
            boomerangObject.transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime);
        }
    }

    public float disapearDistance;
    public float rotationSpeed;
    public bool isBeingThrown;
    //when the boomerang is thrown
    public void Throw()
    {
        isBeingThrown = true;
        rb.velocity = throwDirection * throwForce;
        lastPlayerPos = throwStartingPosition.position;
    }

    public bool isFalling;
    public Vector2 lastPlayerPos;
    //when the boomerang is retuning back
    public void Back()
    {
        isBeingThrown = false;
        Vector2 backDirection = lastPlayerPos - (Vector2)boomerangObject.transform.position;
        rb.velocity = backDirection.normalized * throwForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the player cactches the boomerang
        if (collision.CompareTag("Player") && !isBeingThrown)
        {
            Debug.Log(isThrown);
            isThrown = false;
            isFalling = false;
            boomerangThrowScript.throwables++;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isBeingThrown)
        {
            Debug.Log(isThrown);
            isThrown = false;
            isFalling = false;
            boomerangThrowScript.throwables++;
            gameObject.SetActive(false);
        }
    }
}
