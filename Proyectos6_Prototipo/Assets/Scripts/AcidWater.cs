using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidWater : MonoBehaviour
{
    [SerializeField] float baseDamage = 5;
    float timeBtwDamage;
    float timer;
    float currentDamage;
    Rigidbody2D playerRB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRB.gravityScale = 0.3f;
            playerRB.velocity = new Vector2(playerRB.velocity.x, -4);
            currentDamage = baseDamage;
            timeBtwDamage = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Life_Base>() && timer > timeBtwDamage)
        {            
            if(playerRB.velocity.y < 0)
            {
                playerRB.velocity += new Vector2(0, 0.5f) * Time.deltaTime;
            }
            collision.gameObject.GetComponent<Life_Base>().receiveDamage(currentDamage);
            timer = 0;
            currentDamage += currentDamage / 4;
            timeBtwDamage -= 0.2f;
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
