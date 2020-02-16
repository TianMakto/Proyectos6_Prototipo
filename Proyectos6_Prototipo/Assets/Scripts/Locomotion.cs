using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Locomotion : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float forceSpeed = 0.2f;
    [SerializeField] float forceWalkingSpeed = 5;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform feet;
    [SerializeField] LayerMask Ground;
    Life_Base mylife;
    GrapplingHook myHook;
    Rigidbody2D myRB;
    Vector2 movement;
    bool isGrounded;
    float jumpCounter;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myHook = GetComponent<GrapplingHook>();
        mylife = GetComponent<Life_Base>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal") ;

        //if (!myHook.HookActive())
        //{
        //    transform.position += new Vector3(movement.x, 0, 0) * speed;
        //}

        //myRB.MovePosition(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && !mylife.dead)
        {
            if (isGrounded)
            {
                jumpCounter = 1;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce + myRB.gravityScale));
            }
            else if(jumpCounter < 2)
            {
                jumpCounter++;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce + myRB.gravityScale));
            }

        }

        isGrounded = Physics2D.OverlapBox(feet.position, new Vector2(0.4f, 0.3f), 0, Ground);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        if (!mylife.dead)
        {
            if(movement.x != 0 && !myHook.HookActive())
            {
                //if (isGrounded)
                {
                    //myRB.velocity = new Vector2(movement.x * forceWalkingSpeed, myRB.velocity.y);
                    transform.position += transform.right * movement.x * speed;
                }
                //else
                //{
                //    float addedForce = movement.x * (forceWalkingSpeed / 10);
                //    //myRB.velocity = new Vector2(Mathf.Clamp(myRB.velocity.x + movement.x * (forceWalkingSpeed/10), -10, 10), myRB.velocity.y); 
                //    myRB.velocity += new Vector2(Mathf.Clamp(movement.x * (forceWalkingSpeed / 10), -10, 10), 0);
                //}
            }

            if (myHook.HookActive())
            {
                //transform.up = GetComponent<DistanceJoint2D>().connectedAnchor;
                Vector2 anchorPoint = GetComponent<DistanceJoint2D>().connectedBody.transform.position;
                Vector2 anchorPointDir = anchorPoint - (Vector2)this.transform.position;
                Vector2 movementDirection = -Vector2.Perpendicular(anchorPointDir);
                Debug.DrawRay(this.transform.position, movementDirection, Color.red, 0.5f);
                myRB.velocity += movementDirection * movement.x * forceSpeed * Time.deltaTime;
            }
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

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.GetComponent<AcidRain>())
        {
            GetComponent<Life_Base>().receiveDamage(other.GetComponent<AcidRain>().damage);
        }
    }
}
