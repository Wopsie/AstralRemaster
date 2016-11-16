using UnityEngine;
using System.Collections;


//this script makes an overlapSphere on an objects position with a radius and layermask selectable through the inspector
//it passes the first seen object position through a delegate to be picked up by any other class
public class SphereRange : MonoBehaviour
{
    [SerializeField] [Range(1, 1000)]
    private float sphereRadius;
    [SerializeField]
    private bool wireframe = false;

    private int layerMask;
    private int updateCount = 0;

    public delegate void TargetPasser(Vector3 targetPos);
    public TargetPasser PassTarget;

    private Vector3 currTargetVector, lastTargetVector, targetMovementVector;

    private PredictVector3 positionPredictor = new PredictVector3();

    private Collider[] hitColliders;

    [SerializeField]
    private GameObject nuzzle;

    void Start()
    {
        layerMask = LayerMask.GetMask("Player");
    }

    void Update()
    {
        SphereSize(sphereRadius);
    }

    void SphereSize(float radius)
    {
        //overlapsphere at the transforms position with radius through inspector
        hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);

        //if something is detected by the overlapsphere
        if(hitColliders.Length != 0)
        {
            updateCount += 1;

            //coordinates of the first collider detected by overlapsphere
            currTargetVector = hitColliders[0].transform.position;

            //if updatecount divided by 2 is higher than or equals to 1... basicly is it uneven
            if (updateCount % 2 >= 1)
            {
                lastTargetVector = hitColliders[0].transform.position;
            }
            
            //to be looked at later
            targetMovementVector = currTargetVector - lastTargetVector;
            targetMovementVector = 3f * targetMovementVector;
            
            //make target position a random position inside a radius of the target
            currTargetVector = Random.insideUnitSphere * 6 + currTargetVector;

            Vector3 targetPosition = Random.insideUnitSphere * 3 + hitColliders[0].transform.position;
            //Vector3 targetPosition = hitColliders[0].transform.position;


            if (PassTarget != null)
            {
                //demo
                PassTarget(targetPosition);

                //to be fixed later
                //PassTarget(positionPredictor.CalcPos(currTargetVector, nuzzle.transform.position, targetMovementVector, 10));
            }
        }
        else
        {
            updateCount = 0;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if(wireframe)
            Gizmos.DrawWireSphere(transform.position, sphereRadius);
        else
            Gizmos.DrawSphere(transform.position, sphereRadius);
    }
}
