using UnityEngine;

public class BoomerangThrowScript : MonoBehaviour
{
    public Animator bBoomerangAanimator;
    public float throwDuration;
    public float throwTime;
    public Transform throwStartingPosition;
    public Transform boomerangTransform;
    public Vector2 mousePos;
    public float throwForce;
    public Vector2 throwDirection;
    public bool isThrown = false;


    private void Update()
    {
        if (!isThrown)
        {
            boomerangTransform.gameObject.SetActive(false);
            boomerangTransform.position = throwStartingPosition.position;
        }

        if (Input.GetMouseButtonDown(0) && !isThrown)
        {
            isThrown = true;
            boomerangTransform.gameObject.SetActive(true);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            throwDirection = (mousePos - (Vector2)throwStartingPosition.position).normalized;
            throwTime = Time.time;
        }

        if (Time.time - throwTime < throwDuration)
        {
            Throw();
        }
        else
        {
            Back();
        }
        boomerangTransform.Rotate(new Vector3(0f, 0f, 1f) * rotationSpeed * Time.deltaTime);

    }

    public float rotationSpeed;
    public bool isBeingThrown;
    public void Throw()
    {
        isBeingThrown = true;
        boomerangTransform.GetComponent<Rigidbody2D>().velocity = throwDirection * throwForce;
    }

    public void Back()
    {
        isBeingThrown = false;
        Vector2 backDirection = (Vector2)throwStartingPosition.position - (Vector2)boomerangTransform.transform.position;
        boomerangTransform.GetComponent<Rigidbody2D>().velocity = backDirection.normalized * throwForce;
    }


}
