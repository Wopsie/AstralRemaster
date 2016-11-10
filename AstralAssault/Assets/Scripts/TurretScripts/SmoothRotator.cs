using UnityEngine;
using System.Collections;

public class SmoothRotator : MonoBehaviour {

    [SerializeField]
    private Transform rotationRefrence;

    [SerializeField]
    private float slerpSpeed;

    void FixedUpdate()
    {
        Quaternion current = transform.rotation;
        Quaternion rotation = new Quaternion(rotationRefrence.rotation.x, rotationRefrence.rotation.y, rotationRefrence.rotation.z, rotationRefrence.rotation.w);

        transform.rotation = Quaternion.Slerp(current, rotation, slerpSpeed * Time.fixedDeltaTime);

    }
}
