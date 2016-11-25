using UnityEngine;
using System.Collections;

public class projectileCollision : MonoBehaviour {

    private RaycastHit collRayHit;
    private Ray collRay;
    private int layerMask;
    
    [SerializeField]
    private GameObject sparks;
    
    void Start()
    {
        layerMask = LayerMask.GetMask("Player");
    }

	void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            //Debug.Log(hit.collider.gameObject.tag);

            /*
            if (hit.collider.gameObject.tag == Tags.playerTag && hit.distance < 3)
            {
                var boom = (GameObject)Instantiate(sparks, transform.position, transform.rotation);
                Destroy(boom, 3);

                Destroy(gameObject);
            }
            */
        } 
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == Tags.playerTag || coll.gameObject.tag == Tags.AsteroidTag || coll.gameObject.tag == "Untagged") ;
        {
            var boom = (GameObject)Instantiate(sparks, transform.position, transform.rotation);
            Destroy(boom, 3);

            Destroy(gameObject);
        }
    }
}
