using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float mousePosX;
    public float mousePosY;
    public float moveDistance;
    public Rigidbody rb;
    public bool canMove=true;

    void Start()
    {
        // Store reference to attached Rigidbody
        rb = GetComponent<Rigidbody>();
        
    }

    void OnMouseDrag()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;
        //if(Input.GetAxis("Mouse X")>.1f)
        //    moveDistance = mousePosX+ Input.GetAxis("Mouse X");
        //else if(Input.GetAxis("Mouse X") < -0.1f)
        //    moveDistance = mousePosX - Input.GetAxis("Mouse X");
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Debug.Log(Input.GetAxis("Mouse X"));
        // Move by Rigidbody rather than transform directly
        //if (mousePosX<275&& mousePosX>200)     
        if (canMove == true)
            rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(mousePosX, 0, distance_to_screen)));


    }

    void OnCollisionEnter(Collision col)
    {
        // Freeze on collision
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x-.1f, Input.mousePosition.y, distance_to_screen)));        //canMove = false;
        print("Block hit wall");
        canMove = false;
    }
    void Update()
    {
        

        //have to check if block or wall exists where they are moving

        //need snapping by rounding float values of x and y
    }
    void OnMouseUp()
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Drag ended!");
        rb.MovePosition(new Vector3(Mathf.Round(rb.position.x),0,0));
        canMove = true;
    }












}
