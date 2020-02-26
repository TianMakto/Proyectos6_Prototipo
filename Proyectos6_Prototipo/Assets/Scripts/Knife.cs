using System.Collections;
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

    public new float uses
    {
        get => knifeUses;
    }

    private void Awake()
    {
        knifeUses = 1;
    }

    public override void Use()
    {
        if(timer > timeBtwAttacks)
        {
            Physics2D.CircleCast(transform.position, attackRange, Vector2.right, something.NoFilter(), impacts);
            if(impacts.Count > 0)
            {
                for (int i = 0; i < impacts.Count; i++)
                {
                    if(impacts[i].collider.gameObject.tag == "Enemy")
                    {
                        impacts[i].collider.GetComponent<Life_Base>().receiveDamage(damage);
                        Vector2 impulseDir = new Vector2(impacts[i].transform.position.x - this.transform.position.x, 0.5f);
                        impacts[i].collider.GetComponent<Rigidbody2D>().AddForce(impulseDir * 5, ForceMode2D.Impulse);
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
