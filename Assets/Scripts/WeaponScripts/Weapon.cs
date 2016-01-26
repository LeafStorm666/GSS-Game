using UnityEngine;
using System.Collections;


//this class is not supposed to be used for anything. it is just for polymorphism purposes. i would use an interface if i could, but i think i need monobehaviour to get this working.
public abstract class Weapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public abstract void GetInput(bool fireMissile, bool fireLaser);

    public abstract void FireWeapon();
}
