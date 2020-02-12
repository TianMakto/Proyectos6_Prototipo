using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Base : MonoBehaviour
{
    [SerializeField] float maxHP;
    float currentHP;
    [System.NonSerialized] public bool dead;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void receiveDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            currentHP = 0;
            dead = true;
        }
    }

    public void Heal(float healAmount)
    {
        currentHP += healAmount;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
