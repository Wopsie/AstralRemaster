using UnityEngine;
using System.Collections;

//this script turns the object it belongs to so that the airplane object can use this turned object as a refrence to align itself with.     
//the purpose of this object is to easily enable smooth banking while an airplane turns
//the rotation of this object should depend on the input of the player
public class ObjectTurner : MonoBehaviour {

    private Vector3 bankAngle = new Vector3(0, 0, 25);
    [SerializeField]
    private GameObject plane;
    
    public void TurnObj(float multiplier)
    {
        bankAngle = new Vector3(plane.transform.localRotation.x, plane.transform.localRotation.y, plane.transform.localRotation.z + 25);

        if(multiplier != 0)
        {
            //turn object according to analogue input multiplier
            transform.localEulerAngles = bankAngle * -multiplier;
        }
        else
        {
            //assume rotation of the parent 
            transform.rotation = plane.transform.rotation;
        }
    }
}
