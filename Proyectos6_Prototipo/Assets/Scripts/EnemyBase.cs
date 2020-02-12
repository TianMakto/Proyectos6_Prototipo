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
    GameObject player;
    enemyState mystate;

    private void Start()
    {
        mystate = enemyState.patrol;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(mystate == enemyState.patrol)
        {
            Patrol();
        }
        else if(mystate == enemyState.chase)
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
        throw new NotImplementedException();
    }

    private void Patrol()
    {
       
    }

    private void Chase()
    {

    }

    private void Attack()
    {
        
    }
}
