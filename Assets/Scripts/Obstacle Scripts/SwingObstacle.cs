using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
    private float rotateSpeed;
    private float zAngle;
    private float minRotationValue = -0.6f, maxRotationValue = 0.6f;

    private void Awake()
    {
        rotateSpeed = Random.Range(50f, 100);
    }

    private void Update()
    {
        zAngle += rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);


        
        if (transform.rotation.z < minRotationValue)
        {
            rotateSpeed = Mathf.Abs(rotateSpeed);
            
        }
        else if (transform.rotation.z > maxRotationValue)
        {
            rotateSpeed = -Mathf.Abs(rotateSpeed);
        }
    }
}
