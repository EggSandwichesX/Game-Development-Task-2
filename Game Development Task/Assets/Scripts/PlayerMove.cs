using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;

    private float speedData;
    public float SpeedData
    {
        get
        {
            return speedData;
        }
    }

    public bool isOnGround = false;

    // get the input values
    private Vector2 direction;

    public Vector2 Direction
    {
        get
        {
            return direction;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isOnGround)
        {
            Move();
        }

    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Ground")
        {
            isOnGround = true;
        }
 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            isOnGround = false;
        }
       
    }

    void Move()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        speedData = Vector3.Distance(Vector3.zero, rb.velocity);

        rb.AddRelativeForce(new Vector3(0, 0, direction.y * 300));
        
        
        if (rb.drag >= 0)
            rb.drag = speedData / 2;
        if (speedData >= 2)
            transform.Rotate(new Vector3(0, direction.x / 2, 0));
        
        //print(rb.velocity);
    }

    
}
