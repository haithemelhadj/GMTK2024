using UnityEngine;
using UnityEngine.UI;

public class BoomerangThrowScript : MonoBehaviour
{
    //refrences
    public Transform throwStartingPosition;
    public BoomerangLogicScript boomerangPrefab;
    public int throwables = 4;

    //scaling
    public float[] xScaling;
    public int xScalingIndex;
    public Text xScalingText;
    public Transform xAxisImg;
    public float[] yScaling;
    public int yScalingIndex;
    public Text yScalingText;
    public Transform yAxisImg;

    //singelton
    public static BoomerangThrowScript instance;

    private void Awake()
    {
        if (xScaling != null)
        {
            //xScalingText.text = "X Scaling(E): " + xScaling[xScalingIndex].ToString();
            //yScalingText.text = "Y Scaling(Q): " + yScaling[yScalingIndex].ToString(); 
            xScalingText.text= "*" + xScaling[xScalingIndex].ToString();
            yScalingText.text= "*" + yScaling[yScalingIndex].ToString();
        }
            //singelton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
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
                BoomerangLogicScript boomerangSpwn = Instantiate(boomerangPrefab, throwStartingPosition.position, Quaternion.identity);
                boomerangSpwn.ThrowBoomerang(xScaling[xScalingIndex], yScaling[yScalingIndex]);
            }
        }

    }


    public void SetScaling()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            xScalingIndex++;
            xScalingIndex = xScalingIndex % xScaling.Length;
            xScalingText.text= "*" + xScaling[xScalingIndex].ToString();
            //xScalingText.text= "X Scaling(E): " + xScaling[xScalingIndex].ToString();
            xAxisImg.localScale = new Vector3(xScaling[xScalingIndex], 1, 1);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            yScalingIndex++;
            yScalingIndex = yScalingIndex % yScaling.Length;
            yScalingText.text= "*" + yScaling[yScalingIndex].ToString();
            //yScalingText.text= "Y Scaling(Q): " + yScaling[yScalingIndex].ToString();
            yAxisImg.localScale = new Vector3(1, yScaling[yScalingIndex], 1);
        }
    }
}
