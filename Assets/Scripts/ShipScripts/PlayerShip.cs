using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour
{
    protected float throttle;
    protected float speed;
    protected Vector3 rotation;
    protected float rotationSpeed;
    public int acceleration;
    public int mass;
    protected int health;
    protected int shield;
    public int maxSpeed;
    public int maxHealth;
    private bool leftWeaponClicked;
    private bool rightWeaponClicked;
    public Weapon leftWeapon;
    public Weapon rightWeapon;
    public Rigidbody rb;
    public bool MouseControlsEnabled;
    public int screenMiddleX;
    public int screenMiddleY;
    public int deadZone;//mouse movement will not register within this much pixels from center.

    // Use this for initialization
    void Start()
    {
        throttle = 0;
        speed = 0;
        rotationSpeed = 1;
        health = maxHealth;
        shield = 100;
        screenMiddleX = Screen.width;
        screenMiddleY = Screen.height;
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        RotateShip();
        MoveShip();
        FireWeapons();
    }


    void RotateShip()
    {
        if(MouseControlsEnabled)
        {
            //wip code.
            Vector2 mouseLocation = GetMouseControls();
            rotation = new Vector3(mouseLocation.y, mouseLocation.x, Input.GetAxis("Roll"));
        }
        else
        {
            rotation = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), Input.GetAxis("Roll"));//vector stores axis values
        }
        
        rotation *= rotationSpeed;//multiply by rotationspeed
        rb.AddRelativeTorque(rotation);//change to new rotation
    }

    void MoveShip() {
        if (speed <= maxSpeed && speed >= 0)
        {
            throttle = Input.GetAxis("Throttle");

            speed = speed + throttle;
        }
        else if (speed < 0f)
        {
            speed = 0f;
        }
        else if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }

        rb.MovePosition(rb.position + (transform.forward*speed)*Time.deltaTime);
    }

    void FireWeapons()
    {
        if(Input.GetButtonDown("FireLeft"))
        {
            leftWeapon.GetInput(true, false);
        }

        if(Input.GetButton("FireLeft"))
        {
            leftWeapon.GetInput(false, true);
        }

        if(Input.GetButtonDown("FireRight"))
        {
            rightWeapon.GetInput(true, false);
        }

        if (Input.GetButton("FireRight"))
        {
            rightWeapon.GetInput(false, true);
        }
    }

    Vector2 GetMouseControls()
    {
        float currentMouseX;
        float currentMouseY;
        Debug.Log(Input.mousePosition);//TODO remove when done
        currentMouseX = Input.mousePosition.x;//convert to make it easy to use.
        currentMouseY = Input.mousePosition.y;//convert to make it easy to use.

        if (currentMouseX < screenMiddleX - deadZone)
        {
            if (currentMouseY < screenMiddleY - deadZone)
            {
                return new Vector2(1, 1);
            }
            else if (currentMouseY > screenMiddleY + deadZone)
            {
                return new Vector2(1, -1);
            } 
        }
        return new Vector2(0,0);
    }
}
