using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallX : MonoBehaviour
{
    public float X1 = 0, X2 = 0, Y1 = 0, Y2 = 0, Z1 = 0, Z2 = 0, time = 0;

    void Update()
    {
        Vector3 pointA = new Vector3(X1, Y1, Z1);
        Vector3 pointB = new Vector3(X2, Y2, Z2);
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, time));
    }
}
