using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangLogicScript : MonoBehaviour
{
    public BoomerangThrowScript boomerangThrowScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !boomerangThrowScript.isBeingThrown) 
        {
            boomerangThrowScript.isThrown = false;
        }
    }
}
