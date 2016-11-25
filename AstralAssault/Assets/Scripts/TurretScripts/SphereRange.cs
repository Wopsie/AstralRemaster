using UnityEngine;
using System.Collections;


//this script makes an overlapSphere on an objects position with a radius and layermask selectable through the inspector
//It passes the position of a target through a delegate to be picked up by other classes.
//It also incorperates an optional margin of error.
public class SphereRange : MonoBehaviour
{
    [SerializeField] [Range(1, 1000)]
    private float sphereRadius;
    private float errorMargin = 3;
    public float ErrorMargin {
        get { return errorMargin;} set { errorMargin = value; } }

    private Vector3 randomTargetPosition;   //target position with a slight, random margin of error
    private Vector3 lastPosition;
    private Vector3 targetMove;
    private Vector3 predictedTarget;

    [SerializeField]
    private bool wireframe = false;
    private bool targetInRange;

    private int layerMask;
    private int updateCount = 0;

    public delegate void TargetPasser(Vector3 targetPos);
    public TargetPasser PassTarget;

    private Collider[] hitColliders;

    private VectorErrorMargin vError = new VectorErrorMargin();
    private PredictVector3 predictPosition = new PredictVector3();

    void Start()
    {
        layerMask = LayerMask.GetMask("Player");
    }

    void Update()
    {
        SphereSize(sphereRadius);
    }

    void FixedUpdate()
    {
        if(targetInRange)
        {
            updateCount += 1;

            //if updatecount divided by 2 is higher than or equals to 1... basicly is it uneven
            //
            //in this if-statement the velocity of the target is worked out by subtracting the position of the target on
            //the previous frame from the position of the target on the current frame
            if (updateCount % 2 >= 1) {
                lastPosition = hitColliders[0].transform.position;
            }    
            else
            {
                targetMove = hitColliders[0].transform.position - lastPosition;
                lastPosition = hitColliders[0].transform.position;
            }
        }else
            updateCount = 0;
    }

    void SphereSize(float radius)
    {
        //overlapsphere at the transforms position with radius through inspector
        hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);

        //if something is detected by the overlapsphere
        if(hitColliders.Length != 0)
        {
            targetInRange = true;
            RandomizeTarget();

            if (PassTarget != null)
            {
                PassTarget(predictPosition.CalcPos(randomTargetPosition, transform.position, targetMove, 500f));
            }
        }
        else
            targetInRange = false;
    }

    //add a random margin of error to target position before shooting
    void RandomizeTarget()
    {
        if (errorMargin < 0)
            errorMargin = 3;
        else
            randomTargetPosition = vError.AddRandomUnitSphere(hitColliders[0].transform.position, errorMargin);
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
