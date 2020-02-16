﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : InventoryItem
{
    [SerializeField] float attackRange;
    [SerializeField] float timeBtwAttacks;
    [SerializeField] float damage;
    List<RaycastHit2D> impacts = new List<RaycastHit2D>();
    float timer;
    ContactFilter2D something;

    private void Start()
    {
        uses = 1;
    }

    public override void Use()
    {
        if(timer > timeBtwAttacks)
        {
            print("Ataco");
            Physics2D.CircleCast(transform.position, attackRange, Vector2.right, something.NoFilter(), impacts);
            if(impacts.Count > 0)
            {
                for (int i = 0; i < impacts.Count; i++)
                {
                    if(impacts[i].collider.gameObject.tag == "Enemy")
                    {
                        impacts[i].collider.GetComponent<Life_Base>().receiveDamage(damage);
                    }
                }
            }
            impacts.Clear();
            timer = 0;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
}