using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {

	void Update()
    {
        transform.Translate(new Vector3(0,0,1) * 10);
    }
}
