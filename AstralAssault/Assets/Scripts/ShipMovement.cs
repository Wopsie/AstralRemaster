using UnityEngine;
using System.Collections;

/*
 * this class takes care of the plane's acceleration, direction, rotation and general movement depending on keyboard and (later) controller input
 */

[RequireComponent(typeof(KeyboardInput))]
[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private KeyboardInput keyboard;

    public float torque;
    public ObjectTurner objTurnScript;

    void Start()
    {
        rb.SetMaxAngularVelocity(2.5f);
    }

    void FixedUpdate()
    {
        TurningInput();
        ShipAccelleration();
    }

    void TurningInput()
    {

        Debug.Log(transform.up);
        //turn ship
        float turnHorizontal = Input.GetAxis("Horizontal") * 2f;
        rb.AddTorque(new Vector3(0,1,0) * torque * turnHorizontal);

        //up & down
        float turnVertical = Input.GetAxis("Vertical") * 3.5f;
        rb.AddTorque(transform.right * torque * turnVertical);


        objTurnScript.TurnObj(turnHorizontal);
    }

    //speed up and slow down ship
    void ShipAccelleration()
    {
        //transform.position += transform.forward * Time.deltaTime * 30;
        rb.AddRelativeForce(new Vector3(0,0,900) * 0.5f);
    }
}
