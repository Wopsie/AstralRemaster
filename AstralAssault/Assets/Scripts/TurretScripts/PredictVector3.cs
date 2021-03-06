﻿using UnityEngine;
using System.Collections;

public class PredictVector3 {

    private float travelTime;
    private float dist;
    private Vector3 predictedPos;
    
	public Vector3 CalcPos(Vector3 targetPos, Vector3 shotPos, Vector3 targetVelocity, float bulletSpeed)
    {
        bulletSpeed = bulletSpeed * Time.fixedDeltaTime;

        dist = Vector3.Distance(shotPos, targetPos);

        travelTime = dist / bulletSpeed;

        predictedPos = targetPos + targetVelocity * travelTime;

        return predictedPos;
    }
}
