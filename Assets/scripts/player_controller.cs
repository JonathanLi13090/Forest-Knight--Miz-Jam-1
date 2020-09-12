using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem particles;
    public float wall_check_distance = 1f;
    public LayerMask what_is_wall;
    public LayerMask what_is_enemy;
    public float move_distance = 1f;

    public SpriteRenderer spriter_renderer;
    public Sprite playerUp;
    public Sprite playerDown;
    public Sprite playerRight;
    public Sprite playerLeft;

    public Transform forward_attackPoint;
    public Transform backward_attackPoint;
    public Transform right_attackPoint;
    public Transform left_attackPoint;
    public float attackRange;
    public int attack_damage;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Forward();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Backward();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }
    }

    void Forward()
    {

        //spriter_renderer.sprite = playerUp;
        animator.SetInteger("direction", 1);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(forward_attackPoint.position, attackRange, what_is_enemy);

        if(hitEnemies.Length > 0)
        {
            animator.SetTrigger("attacking");
            particles.Play();
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy_damage>().TakeDamage(attack_damage, 1);
            }
        }
        else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, wall_check_distance, what_is_wall);

            if (!hitInfo)
            {
                transform.Translate(0, move_distance, 0);
            }
        }
    }

    void Backward()
    {
        //spriter_renderer.sprite = playerDown;
        animator.SetInteger("direction", 2);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(backward_attackPoint.position, attackRange, what_is_enemy);

        if (hitEnemies.Length > 0)
        {
            animator.SetTrigger("attacking");
            particles.Play();
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy_damage>().TakeDamage(attack_damage, 2);
            }
        }
        else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, wall_check_distance, what_is_wall);

            if (!hitInfo)
            {
                transform.Translate(0, -move_distance, 0);
            }
        }
    }

    void Left()
    {
        //spriter_renderer.sprite = playerLeft;
        animator.SetInteger("direction", 4);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(left_attackPoint.position, attackRange, what_is_enemy);

        if (hitEnemies.Length > 0)
        {
            animator.SetTrigger("attacking");
            particles.Play();
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy_damage>().TakeDamage(attack_damage, 4);
            }
        }
        else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.left, wall_check_distance, what_is_wall);

            if (!hitInfo)
            {
                transform.Translate(-move_distance, 0, 0);
            }
        }
    }

    void Right()
    {
        //spriter_renderer.sprite = playerRight;
        animator.SetInteger("direction", 3);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(right_attackPoint.position, attackRange, what_is_enemy);

        if (hitEnemies.Length > 0)
        {
            animator.SetTrigger("attacking");
            particles.Play();
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy_damage>().TakeDamage(attack_damage, 3);
            }
        }
        else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, wall_check_distance, what_is_wall);

            if (!hitInfo)
            {
                transform.Translate(move_distance, 0, 0);
            }
        }
    }

}


