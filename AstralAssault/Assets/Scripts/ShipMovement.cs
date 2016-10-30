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

    [SerializeField]
    private GameObject bankRefrence;
    [SerializeField]
    private ObjectTurner bankRefrenceScript;

    [SerializeField]    //this gameobject is the child of the gameobject this class is attached to that should be banking
    private GameObject hull;

    //steadily increase euleranglevelocity to make smooth rotation. 
    private Vector3 eulerAngleVelocity = Vector3.zero;

    private Vector3 turningVector = Vector3.zero;

    private int bankingBuffer;

    public float torque;

    //replace this with some vector to make Z axis rotation smooth
    public Transform target;

    void Start()
    {
        rb.SetMaxAngularVelocity(2.5f);
    }

    void FixedUpdate()
    {
        //ShipAccelleration();
        TurningInput();

        

        /*
        Quaternion current = transform.localRotation;
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        */
    }

    void BankingInput()
    {
        if (keyboard.e)
        {
            //bank right
            eulerAngleVelocity.z += 5;

            ShipBanking(-1);
            bankingBuffer = -1;
        }
        else if (keyboard.q)
        {
            //bank left
            eulerAngleVelocity.z += 5;

            ShipBanking(1);
            bankingBuffer = 1;
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
        //turn ship
        float turnHorizontal = Input.GetAxis("Horizontal") * 2f;
        //rb.AddTorque(transform.up * torque * turnHorizontal);

        //up & down
        float turnVertical = Input.GetAxis("Vertical") * 3.5f;
        //rb.AddTorque(transform.right * torque * turnVertical);

        bankRefrenceScript.TurnObj(turnHorizontal);

        hull.transform.rotation = Quaternion.Slerp(hull.transform.rotation, bankRefrence.transform.rotation, Time.time * 0.05f);
    }

    //speed up and slow down ship
    void ShipAccelleration()
    {
        //transform.position += transform.forward * Time.deltaTime * 30;
        rb.AddRelativeForce(new Vector3(0,0,900) * Time.deltaTime * 10);
    }

    //ships sideways rotation
    void ShipBanking(int negative)
    {
        //aligns this rotation with rotation of that of a target transform.     check if this can be used to make a banking effect
        



        if (eulerAngleVelocity.z > 100)
        {
            eulerAngleVelocity.z = 100;
        }

        eulerAngleVelocity = eulerAngleVelocity * negative;
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        eulerAngleVelocity = eulerAngleVelocity * negative;
    }
}
