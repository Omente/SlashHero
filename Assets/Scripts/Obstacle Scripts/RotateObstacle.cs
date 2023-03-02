using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    private float rotateSpeed;
    private float zAngle;

    private void Awake()
    {
        rotateSpeed = Random.Range(200f, 400f);
        rotateSpeed = Random.Range(0, 2) > 0 ? rotateSpeed * (-1) : rotateSpeed;
    }

    private void Update()
    {
        zAngle += rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);
    }

}
