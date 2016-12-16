using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//this class will look for enemies within a certain radius from the center of the screen
public class MissileLock : MonoBehaviour {

    private float distFromCenter;
    private float circleCircum;
    private Vector3 screenCenter;
    private Vector3 targetScreenPos;
    private Vector3 lockCircle = new Vector3(200, 150, 0);
    private Vector3[] screenPos;
    private GameObject target;
    private GameObject[] enemyArray;
    private List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] private Camera cam;
    private SwitchTarget<GameObject> switchTarget = new SwitchTarget<GameObject>();
    
	void Start()
    {
        screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        FindEnemies();
    }

    void Update()
    {
        LockCircle(5);

        target = switchTarget.SwitchTargets(enemyList, true);
        Debug.Log(target);
    }

    //this returns the first object that enters the circle it makes in this method
    void LockCircle(float radius)
    {
        //fill screenPos array with screenpositions of all enemies in scene
        int j = 0;
        foreach(GameObject g in enemyList)
        {
            screenPos[j] = cam.WorldToScreenPoint(g.transform.position);
            j++;
        }

        targetScreenPos = cam.WorldToScreenPoint(target.transform.position);

        CheckIfInCircle(targetScreenPos);
    }

    void CheckIfInCircle(Vector3 selectTarget)
    {
        distFromCenter = Vector2.Distance(selectTarget, screenCenter);

        //check if object is within certain distance from screen center
        if(distFromCenter <= 200 && distFromCenter >= -200)
        {
            //Debug.Log("LOCK ON TO " + target.gameObject.name);
        }
    }

    void TargetSwitch()
    {
        int i = enemyList.Count;
        switchTarget.SwitchTargets(enemyList, true);
    }

    void CalcEnemyScreenPos()
    {
        //find way to remove specific enemies from list after they have been removed from scene

        int i = 0;
        foreach (GameObject g in enemyArray)
        {
            //linkedlist syntax
            //enemyList.AddFirst(g);

            //list syntax
            enemyList.Add(g);
            i++;

            //temporarily assign target to be gameobject g
            //later this is to be controlled by player
            target = g;
        }
        screenPos = new Vector3[enemyList.Count];
    }

    public void FindEnemies()
    {
        //empty array and refind all enemies in scene
        enemyArray = null;
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        CalcEnemyScreenPos();
    }
}
