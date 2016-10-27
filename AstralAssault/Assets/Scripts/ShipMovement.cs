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

    //steadily increase euleranglevelocity to make smooth rotation. 
    private Vector3 eulerAngleVelocity = Vector3.zero;

    private Vector3 turningVector = Vector3.zero;

    private int bankingBuffer;


    public float torque;

    void FixedUpdate()
    {
        ShipAccelleration();
        BankingInput();
        TurningInput();
    }

    void BankingInput()
    {
        if (keyboard.e)
        {
            //bank right
            eulerAngleVelocity.z += 5;

            ShipBanking(-1);
            bankingBuffer = -1;

            //make sure player can turn and bank plane at the same time
            TurningInput();
        }
        else if (keyboard.q)
        {
            //bank left
            eulerAngleVelocity.z += 5;

            ShipBanking(1);
            bankingBuffer = 1;

            TurningInput();
        }

        //slow down rotation
        if (!keyboard.e && !keyboard.q)
        {
            if (eulerAngleVelocity.z > 0)
            {
                eulerAngleVelocity.z -= 5;
                ShipBanking(bankingBuffer);
            }
        }
    }

    void TurningInput()
    {
        if (keyboard.a)
        {
            //turn left
            turningVector.y += 1;
            ShipTurning(-1);
        }
        else if (keyboard.d)
        {
            //turn right
            turningVector.y += 1;
            ShipTurning(1);
        }
    }

    //speed up and slow down ship
    void ShipAccelleration()
    {
        transform.position += transform.forward * Time.deltaTime * 30;
    }

    //ships sideways rotation
    void ShipBanking(int negative)
    {
        

        if (eulerAngleVelocity.z > 100)
        {
            eulerAngleVelocity.z = 100;
        }

        eulerAngleVelocity = eulerAngleVelocity * negative;
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        eulerAngleVelocity = eulerAngleVelocity * negative;
    }

    //ships actual turning
    void ShipTurning(int turn)
    {
        transform.Rotate(Vector3.up * ((turn * 30) * Time.deltaTime));
    }
}
