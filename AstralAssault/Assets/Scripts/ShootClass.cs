using UnityEngine;
using System.Collections;

public class ShootClass : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

    private int cooldown;

    void Update()
    {
        if(cooldown <= 0)
        {
            //shoot
            Debug.Log("shoot");
            var shot = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            Destroy(shot, 10);

            cooldown = 50;
        }
        cooldown--;
    }

}
