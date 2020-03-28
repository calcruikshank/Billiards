using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallMobileController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform firePoint;
    public float cueForce = 0f;
    public bool abletoShoot = true;
    public float chargeTimer = 0f;
    //attempt to create mouse drag option
    public Vector3 mousePosOnClick;
    public Vector2 direction;
    public Vector2 cueForceDirection;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //faceMouse(); 


        if (Input.GetButtonDown("Fire1")) //when left click is pressed get the mouse position
        {
            mousePosOnClick = Input.mousePosition;
            mousePosOnClick = Camera.main.ScreenToWorldPoint(mousePosOnClick);
        }

        if (Input.GetButton("Fire1"))
        {
            startCharge();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            launchCueBall();
        }

    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.right = direction;

        
    }


    void startCharge()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);  //equal to the difference of current mouse position transform
        direction = direction.normalized;


        cueForceDirection = new Vector2(mousePosition.x - mousePosOnClick.x, mousePosition.y - mousePosOnClick.y);

        //Debug.Log(cueForceDirection.x);
        //Debug.Log(cueForceDirection.y);

        
        cueForce = Mathf.Abs(cueForceDirection.x) + Mathf.Abs(cueForceDirection.y); //get absolute value of cueforce direction x and y and multiply it to the direction
        cueForce *= 2;

        Debug.Log(cueForce);
        rb.velocity = rb.velocity * 0.99f;  //slow velocity while holding left click
        //chargeTimer += Time.deltaTime;
        //cueForce += chargeTimer/5;
        //Debug.Log(cueForce);
        if (cueForce > 20)
        {
            //cueForce = 20;
        }
    }


    void launchCueBall()
    {
        rb.AddForce(direction * cueForce, ForceMode2D.Impulse);
        //rb.AddForce(firePoint.right * cueForce, ForceMode2D.Impulse);
        //abletoShoot = false;
        chargeTimer = 0;
        cueForce = 0;
    }

}

