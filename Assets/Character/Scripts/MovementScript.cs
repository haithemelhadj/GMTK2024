using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [Header("Refrences")]
    public InputsScript inputsScript;
    public ActionsScript ActionsScript;
    public JumpScript jumpingScript;

    private void Awake()
    {
        //get scripts
        inputsScript = GetComponent<InputsScript>();
        ActionsScript = GetComponent<ActionsScript>();
        jumpingScript = GetComponent<JumpScript>();

    }

    private void Update()
    {
        if (ActionsScript.isDashing) return; //if dashing stop movement
        horizontalInput = inputsScript.horizontalInput;

    }
    private void FixedUpdate()
    {
        //if starts walljumping can move for a little while
        //if (!jumpingScript.isNotMoving)
        if (ActionsScript.isDashing || jumpingScript.isWallJumping)
            return;
        Move();

    }

    [Header("Variables")]
    public float horizontalInput;
    public float CurrentAcceleration;
    public float acceleration;
    public float wallJumpAcceleration;
    public float deceleration;
    public float maxHSpeed;

    public void Move()
    {
        //move player
        //if (horizontalInput != 0f)// && Mathf.Abs(inputsScript.playerRb.velocity.x) < maxHSpeed)
        if (horizontalInput != 0f && Mathf.Abs(inputsScript.playerRb.velocity.x) < maxHSpeed)
        {
            //inputsScript.playerRb.velocity = Vector3.Lerp(inputsScript.playerRb.velocity, new Vector3(horizontalInput * maxHSpeed, inputsScript.playerRb.velocity.y, 0), acceleration);
            //Debug.Log("moving");
            //inputsScript.playerRb.velocity += new Vector2(horizontalInput * acceleration, 0);
            inputsScript.playerRb.AddForce(new Vector2(horizontalInput * acceleration, 0), ForceMode2D.Force);  //velocity += new Vector2(horizontalInput * acceleration * maxHSpeed, 0);
        }
        //inputsScript.playerRb.velocity = Vector3.Lerp(inputsScript.playerRb.velocity, new Vector3(horizontalInput * maxHSpeed, inputsScript.playerRb.velocity.y, 0), CurrentAcceleration);
        else //slow player to stop
            inputsScript.playerRb.velocity = Vector3.Lerp(inputsScript.playerRb.velocity, new Vector3(0, inputsScript.playerRb.velocity.y, 0), deceleration);

        //HSpeedLimit();

        //flip character and keep it that way when no inputs
        if (horizontalInput > 0 && isFacingRight)
            Flip();
        if (horizontalInput < 0 && !isFacingRight)
            Flip();


    }

    public bool isFacingRight;
    public void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;

    }

    //public float maxHSpeed;
    private void HSpeedLimit()
    {
        if (horizontalInput != 0 && inputsScript.playerRb.velocity.x > maxHSpeed)
        {
            inputsScript.playerRb.velocity = new Vector2(maxHSpeed * Mathf.Sign(horizontalInput), inputsScript.playerRb.velocity.y);
        }
    }

}
