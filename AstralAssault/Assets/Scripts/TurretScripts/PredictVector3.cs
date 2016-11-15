using UnityEngine;
using System.Collections;

public class PredictVector3 {

	public Vector3 CalcPos(Vector3 targetPos, Vector3 callPos, Vector3 targetMovement, float bulletSpeed)
    {
        //get target position

        //get bullet speed

        //get distance to player

        //get bullet to target traveltime
        float targetDistance = Vector3.Distance(callPos, targetPos);
        //Debug.Log(targetDistance);

        float traveltime = targetDistance / bulletSpeed;

        Vector3 predictedPos = targetPos + targetMovement * traveltime;

        return predictedPos;
    }
}
