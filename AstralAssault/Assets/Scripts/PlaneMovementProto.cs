using UnityEngine;
using System.Collections;

public class PlaneMovementProto : MonoBehaviour {

    private float speed = 50f;

	void Update () {
        //rework
        transform.position += transform.forward * Time.deltaTime * speed;

        //increase & decrease speed depending on if plane is going up or down
        speed -= transform.forward.y * 2f * Time.deltaTime;
        if(speed < 35)
        {
            speed = 35;
        }

        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        //remove later
        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        if(terrainHeight > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }
	}
}
