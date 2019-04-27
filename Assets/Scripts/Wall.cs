using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        // Freeze on collision
        if (col.gameObject.tag == "Block") { 
        col.rigidbody.isKinematic = true;
        print("Collided with wall");
        }
    }
}
