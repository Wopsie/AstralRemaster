using UnityEngine;
using System.Collections;

/*
 * this class takes care of the plane's acceleration, direction, rotation and general movement depending on keyboard and (later) controller input
 */

[RequireComponent(typeof(KeyboardInput))]
[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour {

    [SerializeField] private Rigidbody rb;
    [SerializeField] private KeyboardInput keyboard;
    [SerializeField] private ObjectTurner objTurnScript;
    [SerializeField] private float torque;

    private Vector3 speed = new Vector3(0, 0, 300);

    void Start()
    {
        rb.SetMaxAngularVelocity(2.5f);
    }

    void FixedUpdate()
    {
        YawShip();
        PitchShip();
        RollShip();
        ShipAccelleration();
    }

    void YawShip()
    {
        //yaw ship left & right
        float turnHorizontal = Input.GetAxis("Horizontal") * 2f;
        rb.AddTorque(new Vector3(0, 1, 0) * torque * turnHorizontal);

        objTurnScript.TurnObj(turnHorizontal);
    }

    void PitchShip()
    {
        //pitch ship up & down
        float turnVertical = Input.GetAxis("Vertical") * 3.5f;
        rb.AddTorque(transform.right * torque * turnVertical);
    }

    void RollShip()
    {
        if (keyboard.e)
        {
            //bank right
            rb.AddTorque(transform.forward * -torque * 5);
        }
        else if (keyboard.q)
        {
            //bank left
            rb.AddTorque(transform.forward * torque * 5);
        }
    }

    
    void ShipAccelleration()
    {
        //speed up ship
        rb.AddRelativeForce(speed);
    }
}
