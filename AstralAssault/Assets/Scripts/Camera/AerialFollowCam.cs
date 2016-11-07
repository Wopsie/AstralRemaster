using UnityEngine;
using System.Collections;

public class AerialFollowCam : MonoBehaviour {
    
    [SerializeField]
    private Transform target;
    private Vector3 defaultDistance = new Vector3(0, 5, -0.1f);
    private Vector3 velocity = Vector3.one;
    private float distanceToDamp = 0.20f;

    void Update()
    {
        SmoothFollow();
    }

	void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(transform.position, toPos, ref velocity, distanceToDamp);
        transform.position = curPos;

        transform.LookAt(target.transform.localPosition + (target.up * 5), target.up);
    }
}
