using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {

    [HideInInspector]
    public bool up, down, left, right, space, lShift, rShift, w, a, s, d, q, e, r, lAlt, rAlt, lCntr, rCntr = false;

    void Update()
    {
        GetKeyboardInput();
    }

    void GetKeyboardInput()
    {
        //arrow keys
        up = Input.GetKey(KeyCode.UpArrow);
        down = Input.GetKey(KeyCode.DownArrow);
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);

        //letter keys
        w = Input.GetKey(KeyCode.W);
        a = Input.GetKey(KeyCode.A);
        s = Input.GetKey(KeyCode.S);
        d = Input.GetKey(KeyCode.D);
        q = Input.GetKey(KeyCode.Q);
        e = Input.GetKey(KeyCode.E);
        r = Input.GetKey(KeyCode.R);

        //side keys
        lShift = Input.GetKey(KeyCode.LeftShift);
        rShift = Input.GetKey(KeyCode.RightShift);
        space = Input.GetKey(KeyCode.Space);
        lCntr = Input.GetKey(KeyCode.LeftControl);
        rCntr = Input.GetKey(KeyCode.RightControl);
        lAlt = Input.GetKey(KeyCode.LeftAlt);
        rAlt = Input.GetKey(KeyCode.RightAlt);
    }
}
