using UnityEngine;
using System.Collections;



public class MissileWeapon : Weapon {
    public Rigidbody bullet;
    public Vector3 fixPosition;
    public int bulletSpeed;
    public float timeUntilNextShot;
    public float bulletsPerSecond;
    private bool readyToFire;

    public override void FireWeapon()
    {
        if (readyToFire)
        {
            Rigidbody clone = (Rigidbody)Instantiate(bullet, transform.position + fixPosition, transform.rotation);
            clone.AddRelativeForce(0, 0, bulletSpeed);
            timeUntilNextShot = 1f / bulletsPerSecond;
            readyToFire = false;
            Destroy(clone.gameObject, 5f);
        }
    }

    public override void GetInput(bool fireMissile, bool fireLaser)
    {
        if (fireMissile == true)
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
            timeUntilNextShot = timeUntilNextShot - 1 * Time.deltaTime;
        }
        if (timeUntilNextShot <= 0)
        {
            readyToFire = true;
        }
    }
}
