using UnityEngine;

public class BoomerangLogicScript : MonoBehaviour
{

    //scaling vars
    [HideInInspector] public float xScaling;
    [HideInInspector] public float yScaling;
    //animator vars
    [HideInInspector] public bool isRotating;
    //components
    public BoomerangThrowScript boomerangThrowScript;
    public Rigidbody2D rb;
    public CircleCollider2D coll;

    //refrences
    public Transform throwStartingPosition;
    public GameObject boomerangObject;

    //throw vars
    public float throwForce;
    public float throwDuration;
    [HideInInspector] public float throwTime;
    [HideInInspector] public Vector2 mousePos;
    [HideInInspector] public Vector2 throwDirection;
    public bool isThrown; //to check if boomerang is in hand or not
    public bool isBeingThrown; // to check if boomerang is going or coming back

    //returning back
    public float disapearDistance;
    [HideInInspector] public Vector2 lastPlayerPos;
    //loose
    public bool isLoose;

    //extra or placeholders
    public float rotationSpeed;
    [HideInInspector] public Vector3 rotationVector = new Vector3(0f, 0f, 1f);

    private void Awake()
    {
        boomerangObject = gameObject;
        rb = boomerangObject.GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (isRotating)
        {
            boomerangObject.transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime); // place holder rotation
        }
        if (isThrown)
        {
            BoomerangThrown();//code when the boomerang is thrown
            //Debug.Log("isthrown");
        }
    }


    #region functions

    public void ThrowBoomerang(float x, float y)
    {
        //
        xScaling = x;
        yScaling = y;
        //
        isBeingThrown = true;
        coll.isTrigger = true;
        isThrown = true;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        //
        throwTime = Time.time;
        transform.position = throwStartingPosition.position;
        //
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        throwDirection = (mousePos - (Vector2)throwStartingPosition.position).normalized;
    }


    //when thrown it has three states : thrown, returning back, loose
    private void BoomerangThrown()
    {
        //check if the boomerang is thrown 
        if (Time.time - throwTime < throwDuration)
        {
            //Debug.Log("is Thrown");
            isBeingThrown = true; //is being thrown
            rb.velocity = throwDirection * throwForce;//throw velocity
            lastPlayerPos = throwStartingPosition.position;//return to last player position
            isRotating = true;
            return;
        }
        //check if the boomerang is loose
        else if (Vector2.Distance(lastPlayerPos, boomerangObject.transform.position) < disapearDistance && !isBeingThrown)
        {
            isLoose = true;
            //Debug.Log("didn't catch");
            rb.velocity = Vector2.zero;
            coll.isTrigger = false;
            rb.gravityScale = 2f;
            isRotating = false;

        }
        //check if boomerang is returning back
        else if (Time.time - throwTime > throwDuration && !isLoose)
        {
            //Debug.Log("is coming back");
            isBeingThrown = false; // is coming back
            Vector2 backDirection = lastPlayerPos - (Vector2)boomerangObject.transform.position;// return direction
            rb.velocity = backDirection.normalized * throwForce;// return velocity
            isRotating = true;
        }



    }



    #endregion

    #region collisions

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the player cactches the boomerang
        if (collision.CompareTag("Player") && !isBeingThrown)
        {
            //Debug.Log("did catch");
            isLoose = false;
            isThrown = false;
            boomerangThrowScript.throwables++;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if(collision.CompareTag("Scalable")&& !isLoose)
        {
            collision.gameObject.transform.localScale = new Vector3(xScaling, yScaling, 1f);
            if(collision.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().gravityScale *= Mathf.Sign(yScaling);
            }   
        }
        if (collision.gameObject.layer == 3 && isLoose)
        {

            rb.velocity = Vector2.zero;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isBeingThrown)
        {
            //Debug.Log("did catch");
            isLoose = false;
            isThrown = false;
            boomerangThrowScript.throwables++;
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        //if (collision.gameObject.CompareTag("Ground") && isLoose)
        if (collision.gameObject.layer == 3 && isLoose)
        {
            rb.velocity = Vector2.zero;
            //Debug.Log("hit the ground");
        }
    }

    #endregion
}
