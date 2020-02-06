using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 5;
    Rigidbody2D myRB;
    Vector2 movement;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float xInput = Input.GetAxis("Horizontal");
        movement.x = Input.GetAxis("Horizontal");

        //transform.position += new Vector3(xInput, 0, 0) * speed;
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
        myRB.velocity += (Vector2.right * movement.x) * speed;
    }
}
