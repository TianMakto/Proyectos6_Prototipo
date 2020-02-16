using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [System.NonSerialized] public float damage;
    [SerializeField] float speed = 10;

    private void Start()
    {
        Destroy(this.gameObject, 10);
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Life_Base>().receiveDamage(damage);
        }
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.GetComponent<DestructibleRope>())
            {
                collision.gameObject.GetComponent<DestructibleRope>().BreakRope();
            }
            Destroy(this.gameObject);
        }
    }
}
