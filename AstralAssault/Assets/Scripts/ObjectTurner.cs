using UnityEngine;
using System.Collections;

//this script turns the object it belongs to so that the airplane object can use this turned object as a refrence to align itself with.     
//the purpose of this object is to easily enable smooth banking while an airplane turns
//the rotation of this object should depend on the input of the player
public class ObjectTurner : MonoBehaviour {

    private Vector3 bankAngle = new Vector3(0, 0, 25);
    [SerializeField]
    private GameObject plane;
    
    void FixedUpdate()
    {
        //transform.position = plane.transform.position;
        //transform.eulerAngles = new Vector3(plane.transform.eulerAngles.x, plane.transform.eulerAngles.y, plane.transform.eulerAngles.z);

        //transform.rotation = plane.transform.rotation;
    }

    public void TurnObj(float multiplier)
    {
        //bankAngle = new Vector3(plane.transform.localRotation.x, plane.transform.localRotation.y, plane.transform.localRotation.z + 25);
        bankAngle = new Vector3(this.transform.localRotation.x, this.transform.localRotation.y, this.transform.localRotation.z + 25);

        if(multiplier != 0)
        {
            transform.localEulerAngles = bankAngle * -multiplier;
        }
        else
        {
            transform.localEulerAngles = new Vector3(plane.transform.rotation.x, plane.transform.rotation.y, plane.transform.rotation.z);
        }
    }
}
