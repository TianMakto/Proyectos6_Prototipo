using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Base : MonoBehaviour
{
    [SerializeField] float maxHP;
    float currentHP;
    [System.NonSerialized] public bool dead;

    //enemy
    float whiteTimer;
    bool whiteBool;

    private void Start()
    {
        currentHP = maxHP;
        if (GetComponent<Locomotion>())
        {
            UI_Manager.Instance.setHP();
        }
    }

    public void receiveDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0 && !dead)
        {
            currentHP = 0;
            dead = true;
            if (!GetComponent<Locomotion>())
            {
                Destroy(this.gameObject);
            }
        }
        if (GetComponent<Locomotion>())
        {
            UI_Manager.Instance.setHP();
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            whiteBool = true;
            whiteTimer = 0.5f;
        }
    }

    public void Heal(float healAmount)
    {
        currentHP += healAmount;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        if (GetComponent<Locomotion>())
        {
            UI_Manager.Instance.setHP();
        }
    }

    public float getHP()
    {
        return (currentHP / maxHP);
    }

    private void Update()
    {
        if (whiteBool)
        {
            whiteTimer -= Time.deltaTime;
            if(whiteTimer < 0)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                whiteBool = false;
            }
        }
    }
}
