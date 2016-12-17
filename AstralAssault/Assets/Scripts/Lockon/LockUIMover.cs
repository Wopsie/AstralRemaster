using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//this class will be responsible for moving the UI element to the correct position,
//keeping the correct position and appearing and reappearing when needed
public class LockUIMover : MonoBehaviour {

    [SerializeField] private Image lockReticle;
    private MissileLock ml;

	void Start()
    {

    }

    void PlaceUI(bool foundTarget)
    {
        lockReticle.enabled = foundTarget;

    }
}
