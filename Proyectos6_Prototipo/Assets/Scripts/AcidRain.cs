using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidRain : MonoBehaviour
{
    public float damage = 5;
    public bool canDamage = true;


    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.GetComponent<Locomotion>())
        {
            other.gameObject.GetComponent<Life_Base>().receiveDamage(damage);
        }
    }
}
