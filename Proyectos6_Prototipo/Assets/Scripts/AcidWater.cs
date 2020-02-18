using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidWater : MonoBehaviour
{
    float timer;
    Rigidbody2D playerRB;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRB.gravityScale = 0.3f;
            playerRB.velocity = new Vector2(playerRB.velocity.x, -4);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Life_Base>() && timer > 1)
        {            
            if(playerRB.velocity.y < 0)
            {
                playerRB.velocity += new Vector2(0, 0.5f) * Time.deltaTime;
            }
            collision.gameObject.GetComponent<Life_Base>().receiveDamage(5);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerRB.gravityScale = 1;
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            playerRB.AddForce(new Vector2(playerRB.velocity.x, collision.gameObject.GetComponent<Locomotion>().GetJumpforce()));
        }
    }
}
