using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    public bool canMove=true;
    public Vector3 moveSpd;

    void Start()
    {
        // Store reference to attached Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDrag()
    {
        moveSpd = (Vector3.right * .1f);

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
    }
    
    void OnCollisionEnter(Collision col)
    {
        // Freeze on collision       
        canMove = false;        
    }
    void Update()
    {

    }
    void OnMouseUp()
    {      
        //Snapping by rounding float values of x and y
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
    }
    void OnMouseDown()
    {
        canMove = true;
    }
 












}
