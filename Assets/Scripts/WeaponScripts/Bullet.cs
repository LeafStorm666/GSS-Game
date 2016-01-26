using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Rigidbody rb;
    public int damage;
    public int speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(rb.position + (transform.forward * (0 - speed)) * Time.deltaTime);//0 - speed isnt the neatest solution honestly. but at least my bullets are going the right way now
    }
}
