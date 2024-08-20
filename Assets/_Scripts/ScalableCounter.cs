using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalableCounter : MonoBehaviour
{
    private Vector3 initialScale;
    private Vector3 scaleModifier = Vector3.one;
    private Vector3 scaleSign = Vector3.one;
    public int numberOfTimesToScale = 1;
    private float timer = -1;
    void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
    }

    public void ScaleObject(float xScale, float yScale)
    {
        if (timer <= 0)
        {
            scaleSign.x *= Mathf.Sign(xScale);
            scaleSign.y *= Mathf.Sign(yScale);
            scaleModifier.y *= Mathf.Abs(yScale);
            scaleModifier.x *= Mathf.Abs(xScale);
            if (scaleModifier.x > Mathf.Pow(2, numberOfTimesToScale)) scaleModifier.x = Mathf.Pow(2, numberOfTimesToScale);
            if (scaleModifier.y > Mathf.Pow(2, numberOfTimesToScale)) scaleModifier.y = Mathf.Pow(2, numberOfTimesToScale);
            if (scaleModifier.x < Mathf.Pow(0.5f, numberOfTimesToScale)) scaleModifier.x = Mathf.Pow(0.5f, numberOfTimesToScale);
            if (scaleModifier.y < Mathf.Pow(0.5f, numberOfTimesToScale)) scaleModifier.y = Mathf.Pow(0.5f, numberOfTimesToScale);
            transform.localScale = new Vector3(initialScale.x * scaleModifier.x * scaleSign.x, initialScale.y * scaleModifier.y * scaleSign.y, 1f);
            timer = 1f;
        }
    }
}
