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

    private Dictionary<int, GameObject> enemyDict = new Dictionary<int, GameObject>();
    private List<GameObject> enemyList = new List<GameObject>();
    private GameObject[] enemyArray;

    private Vector3[] screenPos;

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

        //Debug.Log(screenPos[0].x - screenCenter.x);

        //if any of the enemies in scene screenpos are within radius
        /*
        for (int i = 0; i < screenPos.Length; i++)
        {
            //if((screenPos[i] - screenCenter) )

        }
        */
        //Debug.Log(circleCircum);
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
            //Debug.Log(enemyDict[i].gameObject.name);
            i++;
        }
    }
}
