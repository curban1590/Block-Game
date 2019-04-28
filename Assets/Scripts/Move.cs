using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //public float mousePosX;
    //public float centerOfObject;
    //public float moveDistance;
    public Rigidbody rb;
    public bool canMove=true;
    public Vector3 moveSpd;

    void Start()
    {
        // Store reference to attached Rigidbody
        rb = GetComponent<Rigidbody>();
        // rb.constraints = RigidbodyConstraints.FreezeAll;

    }/*
    void OnMouseDrag()
    {


        Vector3 v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        Debug.Log(v3); //Current Position of mouse in world space

        if (canMove == true)
            rb.MovePosition(v3);

    }*/

    void OnMouseDrag()
    {
        //rb.isKinematic = false;
        //rb.constraints = RigidbodyConstraints.FreezeRotation|RigidbodyConstraints.FreezePositionY;
        moveSpd = (Vector3.right * .1f);

        // mousePosX = Input.mousePosition.x;
        if (canMove) { 
        if (rb.tag == "Horiz")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY| RigidbodyConstraints.FreezePositionZ;
                if (canMove)
                    transform.Translate(moveSpd * Input.GetAxis("Mouse X"));
        }
        else if (rb.tag == "Vert")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
                if (canMove)
                    transform.Translate(moveSpd * Input.GetAxis("Mouse Y"));
        }
        }
        print(moveSpd);
        //moveDistance = centerOfObject + mousePosX;
        //if(Input.GetAxis("Mouse X")>.1f)
        //    moveDistance = mousePosX+ Input.GetAxis("Mouse X");
        //else if(Input.GetAxis("Mouse X") < -0.1f)
        //    moveDistance = mousePosX - Input.GetAxis("Mouse X");
        //float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position*.9f).z;
        //Debug.Log(Vector3.right * .1f * Input.GetAxis("Mouse X"));
        // Move by Rigidbody rather than transform directly
        //if (mousePosX<275&& mousePosX>200)  
        /*
        Vector3 movX = Input.GetAxis("Mouse X") * Vector3.right;
        if (rb.tag == "Horiz")
        {
            if (canMove == true)
                rb.AddForce(Vector3.right * Input.GetAxis("Mouse X")* 100);
                //rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));        //canMove = false;

        }
        if (rb.tag == "Vert")
        {
            if (canMove == true)
                //rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.y, Input.mousePosition.x, distance_to_screen)));        //canMove = false;
                rb.AddForce(Vector3.right * Input.GetAxis("Mouse Y")* 100);
        }*/

        //rb.AddForce(Vector3.right * Input.GetAxis("Mouse X")*Time.deltaTime);
        //transform.Translate(movX);


    }
    
    void OnCollisionEnter(Collision col)
    {
        // Freeze on collision
        //float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x-.1f, Input.mousePosition.y, distance_to_screen)));        //canMove = false;
        print("Block hit something");
        //canMove = false;
        //rb.MovePosition(v3*-1);
        moveSpd = moveSpd * .00001f;
       // rb.isKinematic = true;
       // rb.constraints = RigidbodyConstraints.FreezeAll;
        canMove = false;

        
    }
    void Update()
    {


        //have to check if block or wall exists where they are moving

    }
    void OnMouseUp()
    {
       

        //need snapping by rounding float values of x and y
        Debug.Log("Drag ended!");
        if (rb.tag == "Horiz")
        {
            rb.MovePosition(new Vector3(Mathf.Round(rb.position.x), 0, 0));

        }
        if (rb.tag == "Vert")
        {
            rb.MovePosition(new Vector3(0, 0, Mathf.Round(rb.position.z)+.5f));

        }
        canMove = false;
       // rb.constraints = RigidbodyConstraints.FreezeAll;




    }
    void OnMouseDown()
    {
        canMove = true;


    }
 












}
