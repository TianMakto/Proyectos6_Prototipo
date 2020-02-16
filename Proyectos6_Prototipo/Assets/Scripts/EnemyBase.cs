using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum enemyState
{
    patrol,
    chase,
    attack
}
public class EnemyBase : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float visionDistance;
    [SerializeField] float attackDistance;
    [SerializeField] float timeBtwAttacks;
    [SerializeField] LayerMask ground;
    bool facingRight;
    float timer;
    GameObject player;
    enemyState myState;
    Rigidbody2D rb;

    private void Start()
    {
        myState = enemyState.patrol;
        player = GameObject.FindGameObjectWithTag("Player");
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(myState == enemyState.patrol)
        {
            Patrol();
        }
        else if(myState == enemyState.chase)
        {
            Chase();
        }
        else
        {
            Attack();
        }

        CheckState();
    }

    private void CheckState()
    {
        float currentDistance = Mathf.Abs(Vector2.Distance(player.transform.position, this.transform.position));
        if (currentDistance > visionDistance)
        {
            myState = enemyState.patrol;
        }
        else if (currentDistance < attackDistance)
        {
            myState = enemyState.attack;
        }
        else if (currentDistance < visionDistance)
        {
            myState = enemyState.chase;
        }
    }

    private void Patrol()
    {
        if (facingRight)
        {
            RaycastHit2D hitRay = Physics2D.Raycast(transform.position, Vector2.right, 1, ground);
            Collider2D frontBlocked = Physics2D.OverlapBox(new Vector2(transform.position.x + 1.5f, transform.position.y), new Vector2(0.5f, 0.5f), 0, ground);
            Collider2D grounded = Physics2D.OverlapBox(new Vector2(transform.position.x + 1, transform.position.y - 1), new Vector2(0.5f, 0.5f), 0, ground);
            if (!frontBlocked && grounded)
            {
                rb.velocity = Vector2.right * speed / 2;
            }
            else if (frontBlocked || !grounded)
            {
                facingRight = false;
                //Flip();
            }
        }

        else if (!facingRight)
        {
            RaycastHit2D hitRay = Physics2D.Raycast(transform.position, Vector2.left, 1, ground);
            Collider2D hitBoxFront = Physics2D.OverlapBox(new Vector2(transform.position.x - 1.5f, transform.position.y), new Vector2(0.5f, 0.5f), 0, ground);
            Collider2D grounded = Physics2D.OverlapBox(new Vector2(transform.position.x - 1, transform.position.y - 1), new Vector2(0.5f, 0.5f), 0, ground);
            if (!hitBoxFront && grounded)
            {
                rb.velocity = Vector2.left * speed / 2;
            }
            else if (hitBoxFront || !grounded)
            {
                facingRight = true;
                //Flip();
            }
        }
    }

    private void Chase()
    {
        if(player.transform.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
    }

    private void Attack()
    {
        timer += Time.deltaTime;
        if(timer >= timeBtwAttacks)
        {
            player.GetComponent<Life_Base>().receiveDamage(5);
            timer = 0;
        }
    }

    private bool checkFalling()
    {
        if (Physics2D.Raycast((Vector2)transform.position + new Vector2(-1, 0), Vector2.down))
        {
            return true;
        }
        else if (Physics2D.Raycast((Vector2)transform.position + new Vector2(1, 0), Vector2.down))
        {
            return true;
        }
        else return false;
    }
}
