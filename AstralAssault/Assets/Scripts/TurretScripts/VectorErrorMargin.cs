using UnityEngine;
using System.Collections;

//this script adds a random number inside unit sphere to a vector3 and returns it.
//this creates for a margin of error for things like turrets.
public class VectorErrorMargin {

    public Vector3 AddRandomUnitSphere(Vector3 targetPos, float errorMargin)
    {
        Vector3 targetPosition = Random.insideUnitSphere * errorMargin + targetPos;
        return targetPosition;
    }
}
