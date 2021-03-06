﻿using UnityEngine;
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
    [SerializeField] private ParticleSystem thruster;

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
        ShipVelocity();
    }

    void YawShip()
    {
        //yaw ship left & right
		float turnHorizontal = InputManager.MainHorizontal() * 2.5f;
        rb.AddTorque(transform.up * torque * turnHorizontal);

        objTurnScript.TurnObj(turnHorizontal);
    }

    void PitchShip()
    {
        //pitch ship up & down
		float turnVertical = -InputManager.MainVertical() * 3.9f;
        rb.AddTorque(transform.right * torque * turnVertical);
    }

    void RollShip()
    {
		if (keyboard.q || InputManager.LBButton())
        {
            //roll right
            rb.AddTorque(transform.forward * torque * 1.85f);
        }
		else if (keyboard.e || InputManager.RBButton())
        {
            //roll left
            rb.AddTorque(transform.forward * -torque * 1.85f);
        }
    }

    void ShipVelocity()
    {
        //accellerate
		if(InputManager.RTrigger() > 0.5f || keyboard.lShift)
        {
            rb.drag = 2;
            torque = 0.8f;

            thruster.startLifetime = 1f;
        }
		else if (keyboard.rShift  || InputManager.LTrigger() > 0.5f) //brake
        {
            //Debug.Log("Braking");
            rb.drag = 4.35f;
            torque = 1.6f;
        }
        else //no buttons pressed neutral speed
        {
            thruster.startLifetime = 0.34f;
            rb.drag = 3;
            torque = 1.2f;
        }
    }

    void ShipAccelleration()
    {
        //speed up ship
        rb.AddRelativeForce(speed);
    }
}
