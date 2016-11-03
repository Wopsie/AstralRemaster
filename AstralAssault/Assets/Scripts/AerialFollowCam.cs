using UnityEngine;
using System.Collections;

public class AerialFollowCam : MonoBehaviour {
    
    [SerializeField]
    private Transform target;
    private Vector3 defaultDistance = new Vector3(0, 3, -1);
    private Vector3 velocity = Vector3.one;
    private float distanceToDamp = 0.25f;

    void Update()
    {
        SmoothFollow();
    }

	void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(transform.position, toPos, ref velocity, distanceToDamp);
        transform.position = curPos;

        transform.LookAt(target, target.up);
    }
}
