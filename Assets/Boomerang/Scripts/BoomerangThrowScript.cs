using UnityEngine;

public class BoomerangThrowScript : MonoBehaviour
{
    public Transform throwStartingPosition;
    public GameObject[] boomerangObject;
    public int throwables = 1;
    public Vector2 throwDirection;
    public Vector2 mousePos;




    private void Awake()
    {
        throwables = boomerangObject.Length;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (throwables > 0)
            {
                throwables--;
                boomerangObject[boomerangObject.Length - throwables - 1].SetActive(true);
                boomerangObject[boomerangObject.Length - throwables - 1].GetComponent<BoomerangLogicScript>().ThrowBoomerang();
            }

        }
    }
}
