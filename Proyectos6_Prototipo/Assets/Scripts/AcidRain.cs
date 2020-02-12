using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidRain : MonoBehaviour
{
    ParticleSystem myPS;
    [SerializeField] float damage = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Life_Base>().receiveDamage(damage);
            print("Dañazo BROOOOO");
        }
        else
        {
            print("he golpeao macho");
        }
    }
}
