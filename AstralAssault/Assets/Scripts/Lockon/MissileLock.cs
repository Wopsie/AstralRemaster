using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//this class will look for enemies within a certain radius from the center of the screen
public class MissileLock : MonoBehaviour {

    private float circleCircum;
    private Vector3 screenCenter;

    [SerializeField]
    private Camera cam;

    private List<GameObject> enemyList = new List<GameObject>();
    private GameObject[] enemyArray;

    private Vector3[] screenPos;

    private GameObject target;

	void Start()
    {
        screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        FindEnemies();
    }

    void Update()
    {
        LockCircle(5);
        CalcEnemyScreenPos();
    }

    //this returns the first object that enters the circle it makes in this method
    void LockCircle(float radius)
    {
        //if any of the enemies in scene screenpos are within radius
        
        for (int i = 0; i < screenPos.Length; i++)
        {
            //if((screenPos[i] - screenCenter) )

        }
        
        //Debug.Log(circleCircum);

        //fill screenPos array with screenpositions of all enemies in scene
        int j = 0;
        foreach(GameObject g in enemyList)
        {
            screenPos[j] = cam.WorldToScreenPoint(g.transform.position);
            j++;
        }

        Debug.Log(screenPos[0].y - screenCenter.y);

        Debug.Log(target.gameObject.name);

        if(screenPos[0].x - screenCenter.x <= 200 && screenPos[0].x - screenCenter.x >= -200 && screenPos[0].y - screenCenter.y <= 200 && screenPos[0].y - screenCenter.y >= 200)
        {
            Debug.Log("Lock On");
        }
    }

    void CalcEnemyScreenPos()
    {

    }

    public void FindEnemies()
    {
        //empty array and refind all enemies in scene
        enemyArray = null;
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        int i = 0;
        foreach(GameObject g in enemyArray)
        {
            //enemyDict.Add(i, g);
            enemyList.Add(g);
            i++;

            target = g;
        }
        screenPos = new Vector3[enemyList.Count];
    }
}
