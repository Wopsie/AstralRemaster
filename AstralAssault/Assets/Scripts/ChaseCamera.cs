using UnityEngine;
using System.Collections;

public class ChaseCamera : MonoBehaviour {

    [SerializeField]
    private GameObject target;

    private float bias = 0.98f;

    void FixedUpdate()
    {
        Vector3 moveCamTo = target.transform.position - transform.forward * 20f + Vector3.up * 5;
        
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1f - bias);
        Camera.main.transform.LookAt(target.transform.position + transform.forward * 30f);

    }
}
