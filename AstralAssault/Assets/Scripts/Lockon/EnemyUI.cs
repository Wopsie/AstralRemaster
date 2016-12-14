using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {

    [SerializeField] private Camera cam;
    [SerializeField] private Image ui;
    [SerializeField] private GameObject canvas;
    [SerializeField] private CameraDetection cd;
    private Vector3 screenPos;

    void Start()
    {
        //create UI element for this enemy
        ui = (Image)Instantiate(ui, Vector3.one, Quaternion.identity, canvas.transform);
        cd.IsSeenDelegate += PlaceUI;
    }

    void PlaceUI(Vector3 pos, bool isSeen)
    {
        ui.enabled = isSeen;
        //only update UI if you are seen
        if(isSeen){
            screenPos = cam.WorldToScreenPoint(pos);
            ui.rectTransform.position = screenPos;
        }        
    }
}