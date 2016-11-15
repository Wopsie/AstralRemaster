using UnityEngine;
using System.Collections;

//this script rotates its object towards a vector3 over a specified axis
public class AxisRotation : MonoBehaviour {

    [SerializeField]
    private bool rotX, rotY;

    [SerializeField]
    private SphereRange turretRange;

    Vector3 originalPos;

	void Start()
    {
        turretRange.PassTarget += RotateTo;
    }

    public void RotateTo(Vector3 targetPos)
    {
        //Debug.Log(targetPos);
        if(rotX)
        {
            //rotate over X axis
            transform.LookAt(new Vector3(targetPos.x, transform.position.y, targetPos.z));
        }

        if(rotY)
        {
            //rotate over Y axis
            transform.LookAt(targetPos);
            if(transform.rotation.eulerAngles.x > 22 && transform.rotation.eulerAngles.x <180)
            {
                transform.eulerAngles = new Vector3(22, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
        }
    }

}
