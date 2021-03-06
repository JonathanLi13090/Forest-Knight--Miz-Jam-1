﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_damage : MonoBehaviour
{
    public int max_health;
    private int current_health;
    public int knockback_distance = 1;
    public float wall_check_distance = 1f;
    public LayerMask what_is_wall;

    void Start()
    {
        current_health = max_health;
    }

    public void TakeDamage(int damage, int direction)
    {
        current_health -= damage;

        if(current_health <= 0)
        {
            Die();
        }
        else
        {
            if (direction == 1)
            {

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.up, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(0, knockback_distance, 0);
                }
            }
            else if (direction == 2)
            {

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.down, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(0, -knockback_distance, 0);
                }
            }
            else if (direction == 3)
            {

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.right, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(knockback_distance, 0, 0);
                }
            }
            else if (direction == 4)
            {

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.left, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(-knockback_distance, 0, 0);
                }
            }
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
}
