using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float forceSpeed = 0.2f;
    [SerializeField] float jumpForce = 5;
    GrapplingHook myHook;
    Rigidbody2D myRB;
    Vector2 movement;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myHook = GetComponent<GrapplingHook>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal") * forceSpeed;

        //if (!myHook.HookActive())
        //{
        //    transform.position += new Vector3(movement.x, 0, 0) * speed;
        //}

        //myRB.MovePosition(movement * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce + myRB.gravityScale));
        }
    }

    private void FixedUpdate()
    {
        if(movement.x != 0 && !myHook.HookActive())
        {
            myRB.velocity = new Vector2(movement.x, myRB.velocity.y);
        }

        if (myHook.HookActive())
        {
            //transform.up = GetComponent<DistanceJoint2D>().connectedAnchor;
            Vector2 anchorPoint = GetComponent<DistanceJoint2D>().connectedBody.transform.position;
            Vector2 anchorPointDir = anchorPoint - (Vector2)this.transform.position;
            Vector2 movementDirection = -Vector2.Perpendicular(anchorPointDir);
            Debug.DrawRay(this.transform.position, movementDirection, Color.red, 0.5f);
            myRB.velocity += movementDirection * movement.x * Time.deltaTime;
        }



        //myRB.MovePosition(myRB.position + movement);
        //myRB.MovePosition((myRB.position + movement) * speed);
        //if (myHook.HookActive())
        //{
            //Vector2 move = myRB.velocity;
            //move.x = (Vector2.right.x * movement.x);
            //print(move.x);
        //}
        //myRB.MovePosition(myRB.position + movement + new Vector2(0, -myRB.gravityScale/10));
    }
}
