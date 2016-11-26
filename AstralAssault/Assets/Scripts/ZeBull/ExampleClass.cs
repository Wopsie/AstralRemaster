using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExampleClass : MonoBehaviour {

    public Transform target;
    Camera camera;

    public Image lockonImage;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 screenPos = camera.WorldToScreenPoint(target.position);
        //Debug.Log("target is " + screenPos.x + " pixels from the left");

        Debug.Log(screenPos);

        if(screenPos.x >= 0 && screenPos.x < Screen.width)
        {
            lockonImage.rectTransform.position = screenPos;
        }
        else
        {
            lockonImage.rectTransform.position = Vector3.one;
        }
        
    }
}
