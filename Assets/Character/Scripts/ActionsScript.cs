using System.Collections;
using UnityEngine;

public class ActionsScript : MonoBehaviour
{
    public InputsScript inputsScript;
    public JumpScript jumpScript;
    public WallSlidingScripit wallSlideScript;

    private void Awake()
    {
        inputsScript = GetComponent<InputsScript>();
        jumpScript = GetComponent<JumpScript>();
        wallSlideScript = GetComponent<WallSlidingScripit>();
    }

    private void Update()
    {
        DashInput();
    }

    #region Dash


    [Header("Dash")]
    public float dashForce;
    public float dashTime;
    public bool canDash;
    public bool isDashing;

    public float drag;
    public void DashInput()
    {
        if (inputsScript.dashInput && canDash)
        {
            StartCoroutine(Dash());
        }
        if (wallSlideScript.isWallSliding)
        {
            StopCoroutine(Dash());
            isDashing = false;
            inputsScript.playerAnimator.SetBool("Dashing", isDashing);
        }
        if (!isDashing && (inputsScript.isGrounded || wallSlideScript.isWallSliding))
        {
            canDash = true;
        }
    }

    public IEnumerator Dash()
    {
        //set vars
        canDash = false;
        isDashing = true;
        inputsScript.playerAnimator.SetBool("Dashing", isDashing);
        //save gravity
        float originalGravity = inputsScript.playerRb.gravityScale;
        inputsScript.playerRb.gravityScale = 0f;
        inputsScript.playerRb.constraints.Equals(RigidbodyConstraints2D.FreezePositionY);
        //set air friction 
        float originalDrag = inputsScript.playerRb.drag;
        inputsScript.playerRb.drag = drag;
        //stop jumping
        jumpScript.isJumping = false;
        //set jumping animation
        inputsScript.playerAnimator.SetBool("isJumping", jumpScript.isJumping);
        //null velocity
        inputsScript.playerRb.velocity = Vector2.zero;
        //dash 
        inputsScript.playerRb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        yield return new WaitForSeconds(dashTime);
        //rest everything
        inputsScript.playerRb.constraints.Equals(RigidbodyConstraints2D.None);
        inputsScript.playerRb.constraints.Equals(RigidbodyConstraints2D.FreezePosition);
        inputsScript.playerRb.drag = 0f;
        inputsScript.playerRb.gravityScale = originalGravity;
        inputsScript.playerRb.drag = originalDrag;
        isDashing = false;
        inputsScript.playerAnimator.SetBool("Dashing", isDashing);
        yield return new WaitForSeconds(dashTime);

    }
    #endregion

}
