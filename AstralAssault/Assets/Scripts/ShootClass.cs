using UnityEngine;
using System.Collections;

public class ShootClass : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

    private int cooldown;

    [SerializeField]
    private SphereRange turretRange;

    void Start()
    {
        //delegate from sphereRange
        turretRange.PassTarget += Shoot;
    }

    void Shoot(Vector3 target)
    {
        if(target != null)
        {
            if (cooldown <= 0)
            {
                var shot = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
                Destroy(shot, 10);
                cooldown = 50;
                turretRange.ErrorMargin -= 0.2f;
            }
            else
                cooldown--;
            
        }
    }
}
