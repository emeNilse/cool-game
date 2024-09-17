using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Damageable
{
    public Transform player;
    public float moveSpeed;
    

    public UnityEvent<Enemy> OnKilled;

    void Start()
    {
       
        // It did not like this when changing to the new game state, player position is made in enemy manager***********
        // player = FindObjectOfType<Player>().transform;

        // player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void UpdateEnemy()
    {
        //player = FindObjectOfType<Player>().transform;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime); //constantly move enemy towards player

        // a different version of moving towards the player
        //distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.forward;
    }

    public override void Death()
    {
        OnKilled.Invoke(this);
    }
}
