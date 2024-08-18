using UnityEngine;

public class BoomerangThrowScript : MonoBehaviour
{
    //refrences
    public Transform throwStartingPosition;
    public GameObject[] boomerangObject;
    public GameObject boomerangPrefab;
    public int throwables;






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
                //instantiate a boomerang 
                GameObject boomerangSpwn= Instantiate(boomerangPrefab, throwStartingPosition.position, Quaternion.identity);
                boomerangSpwn.GetComponent<BoomerangLogicScript>().ThrowBoomerang();
            }

        }
    }
}
