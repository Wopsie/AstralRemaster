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

    public delegate void TargetPasser(Vector3 targetPos);
    public TargetPasser PassTarget;

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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);

        Debug.Log(hitColliders.Length);

        //if something is detected by the overlapsphere
        if(hitColliders.Length != 0)
        {
            //coordinates of the first collider detected by overlapsphere
            Vector3 targetVector = hitColliders[0].transform.position;

            Debug.Log(hitColliders[0].transform.name);

            if (PassTarget != null)
            {
                PassTarget(targetVector);
            }
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
