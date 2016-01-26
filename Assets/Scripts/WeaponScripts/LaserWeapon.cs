using UnityEngine;
using System.Collections;
using System;

public class LaserWeapon : Weapon {
    public Rigidbody bullet;
    public float bulletsPerSecond;
    public Vector3 fixPosition;
    public int bulletSpeed;
    public float timeUntilNextShot;
    private bool readyToFire;

    public override void FireWeapon()
    {
        if(readyToFire){
            Rigidbody clone = (Rigidbody)Instantiate(bullet, transform.position + fixPosition, transform.rotation);
            clone.AddRelativeForce(0, 0, bulletSpeed);
            timeUntilNextShot = 1f / bulletsPerSecond;
            readyToFire = false;   
            Destroy(clone.gameObject, 5f);
        }

    }

    public override void GetInput(bool fireMissile, bool fireLaser)
    {
        if(fireLaser == true)
        {
            FireWeapon();
        }
    }

    // Use this for initialization
    void Start () {
        timeUntilNextShot = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeUntilNextShot > 0)
        {
            timeUntilNextShot = timeUntilNextShot - 1*Time.deltaTime;
        }
        if(timeUntilNextShot <= 0)
        {
            readyToFire = true;
        }	
	}
}
