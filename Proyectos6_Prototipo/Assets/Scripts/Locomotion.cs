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
        movement.x = Input.GetAxis("Horizontal");

        if (!myHook.HookActive())
        {
            transform.position += new Vector3(movement.x, 0, 0) * speed;
        }

        //myRB.MovePosition(movement * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    private void FixedUpdate()
    {
        //myRB.MovePosition(myRB.position + movement);
        //myRB.MovePosition((myRB.position + movement) * speed);
        if (myHook.HookActive())
        {
            myRB.velocity += (Vector2.right * movement.x) * forceSpeed;
        }
            
    }
}
