using UnityEngine;
using System.Collections;

//this class sends out a delegate if it is in view of a camera
//object needs to have any sort of renderer
public class CameraDetection : MonoBehaviour {

    public delegate void IsSeenByCam(Vector3 worldPos, bool isSeen);
    public IsSeenByCam IsSeenDelegate;

    private Renderer r;

    void Start()
    {
        r = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(r.isVisible)
        {
            if(IsSeenDelegate != null)
            {
                IsSeenDelegate(transform.position, true);
            }
        }
        else
        {
            if (IsSeenDelegate != null)
            {
                IsSeenDelegate(transform.position, false);
            }
        }
    }
}
