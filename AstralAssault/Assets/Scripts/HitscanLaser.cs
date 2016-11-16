using UnityEngine;
using System.Collections;

//a laser than instantly hits anything in a certain direction with a raycast. this is not a projectile.
public class HitscanLaser : MonoBehaviour
{

    [SerializeField]
    private GameObject sparks;

    [SerializeField]
    private LineRenderer lineRen;

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward * 1000);

        RaycastHit hit;

        Ray ray = new Ray(transform.position, fwd);
        

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            if (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Asteroid")
            {
                var boom = (GameObject)Instantiate(sparks, hit.point, Quaternion.identity);

                lineRen.SetPosition(0, transform.position);
                lineRen.SetPosition(1, hit.point);

                Debug.Log("Hit " + hit.collider.gameObject.tag);

                Destroy(gameObject, 0.04f);
            }
            else if(hit.collider.gameObject.tag == "Killplane")
            {
                lineRen.SetPosition(0, transform.position);
                lineRen.SetPosition(1, hit.point);

                Destroy(gameObject, 0.04f);
            }
        }
    }
}
