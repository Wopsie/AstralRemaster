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
        Vector3 fwd = transform.TransformDirection(Vector3.forward / 20);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            //print("Found an object - distance: " + hit.collider.gameObject.name);
            
            if (hit.collider.gameObject.tag == "Player")
            {
                var boom = (GameObject)Instantiate(sparks, this.transform.position, transform.rotation);
                Destroy(boom, 3);

                Destroy(gameObject);
            }
        }   
    }
}
