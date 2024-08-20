using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanChanger : MonoBehaviour
{
    public AreaEffector2D aff1; 
    public AreaEffector2D aff2;
    public float direction;

    private void Update()
    {
        aff1.forceAngle = transform.rotation.z;
        aff2.forceAngle = transform.rotation.z;
    }
}
