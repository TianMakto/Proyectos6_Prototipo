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
    bool once;

    public float GetJumpforce()
    {
        return jumpForce + myRB.gravityScale;
    }

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
        movement.y = Input.GetAxis("Vertical");
        isGrounded = Physics2D.OverlapBox(feet.position, new Vector2(0.4f, 0.3f), 0, Ground);

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
                //GetComponent<Rigidbody2D>().
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce + myRB.gravityScale));
            }

        }


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
                transform.position += transform.right * movement.x * speed;
            }

            if (myHook.HookActive())
            {
                Vector2 anchorPoint = GetComponent<DistanceJoint2D>().connectedBody.transform.position;
                Vector2 anchorPointDir = anchorPoint - (Vector2)this.transform.position;
                Vector2 movementDirection = -Vector2.Perpendicular(anchorPointDir);
                Debug.DrawRay(this.transform.position, movementDirection, Color.red, 0.5f);
                myRB.velocity += movementDirection * movement.x * forceSpeed * Time.deltaTime;
            }

            if(movement.y < 0)
            {
                if (!once)
                {
                    print("PEDO");
                    myRB.velocity += new Vector2(0, -Mathf.Abs(myRB.velocity.y) * 2);
                    once = true;
                }
            }
            else if(isGrounded)
            {
                once = false;
            }
        }
    }
}
