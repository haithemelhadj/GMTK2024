using UnityEngine;
using UnityEngine.UI;

public class BoomerangThrowScript : MonoBehaviour
{
    //refrences
    public Transform throwStartingPosition;
    public GameObject boomerangPrefab;
    public int throwables = 4;

    //scaling
    public float[] xScaling;
    public int xScalingIndex;
    public Text xScalingText;
    public float[] yScaling;
    public int yScalingIndex;
    public Text yScalingText;




    private void Awake()
    {
        xScalingText.text = "X Scaling: " + xScaling[xScalingIndex].ToString();
        yScalingText.text = "Y Scaling: " + yScaling[yScalingIndex].ToString();
    }
    private void Update()
    {
        SetScaling();
        if (Input.GetMouseButtonDown(0))
        {
            if (throwables > 0)
            {
                throwables--;
                //instantiate a boomerang 
                GameObject boomerangSpwn= Instantiate(boomerangPrefab, throwStartingPosition.position, Quaternion.identity);
                boomerangSpwn.GetComponent<BoomerangLogicScript>().ThrowBoomerang(xScaling[xScalingIndex], yScaling[yScalingIndex]);
            }
        }

    }


    public void SetScaling()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            xScalingIndex++;
            xScalingIndex = xScalingIndex % xScaling.Length;
            xScalingText.text= "X Scaling(E): " + xScaling[xScalingIndex].ToString();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            yScalingIndex++;
            yScalingIndex = yScalingIndex % yScaling.Length;
            yScalingText.text= "Y Scaling(Q): " + yScaling[yScalingIndex].ToString();
        }
    }
}
