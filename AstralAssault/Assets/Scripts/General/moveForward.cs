using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {

    [SerializeField]
    private float multiplier;

	void Update()
    {
        transform.Translate(Vector3.forward * multiplier * Time.deltaTime);
    }
}
