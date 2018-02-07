using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitBall : MonoBehaviour
{

    public float RotSpeed = 30;
    public Transform Center;
    public Vector3 Axis = Vector3.up;

    void FixedUpdate()
    {
        transform.RotateAround(Center.position, Axis, RotSpeed * Time.deltaTime);
    }
}
