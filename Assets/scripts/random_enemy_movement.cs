using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_enemy_movement: MonoBehaviour
{
    public float wall_check_distance = 1f;
    public int damage;
    public LayerMask what_is_wall;
    public LayerMask what_is_player;
    public float move_distance = 1f;
    public SpriteRenderer spriter_renderer;
    public Sprite faceUp;
    public Sprite faceDown;
    public Sprite faceLeft;
    public Sprite faceRight;
    private int random_direction;
    private float startTime;
    public float wait_in_seconds = 5f;
    public float new_wait_in_seconds = 1f;

    public Transform forward_attackPoint;
    public Transform backward_attackPoint;
    public Transform right_attackPoint;
    public Transform left_attackPoint;
    public float attackRange;
    public int attack_damage;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > startTime + wait_in_seconds)
        {
            //move randomly
            random_direction = Random.Range(1, 5);

            if(random_direction == 1)
            {
                spriter_renderer.sprite = faceUp;

                Collider2D[] hitplayer = Physics2D.OverlapCircleAll(forward_attackPoint.position, attackRange, what_is_player);

                foreach(Collider2D player in hitplayer)
                {
                    player.GetComponent<player_take_damage>().TakeDamage(attack_damage, 1);
                }

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.up, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(0, move_distance, 0);
                }
            }
            else if(random_direction == 2)
            {
                spriter_renderer.sprite = faceDown;

                Collider2D[] hitplayer = Physics2D.OverlapCircleAll(backward_attackPoint.position, attackRange, what_is_player);

                foreach (Collider2D player in hitplayer)
                {
                    player.GetComponent<player_take_damage>().TakeDamage(attack_damage, 2);
                }

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.down, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(0, -move_distance, 0);
                }
            }
            else if(random_direction == 3)
            {
                spriter_renderer.sprite = faceRight;

                Collider2D[] hitplayer = Physics2D.OverlapCircleAll(right_attackPoint.position, attackRange, what_is_player);

                foreach (Collider2D player in hitplayer)
                {
                    player.GetComponent<player_take_damage>().TakeDamage(attack_damage, 3);
                }

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.right, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {  
                    transform.Translate(move_distance, 0, 0);
                }
            }
            else if(random_direction == 4)
            {
                spriter_renderer.sprite = faceLeft;

                Collider2D[] hitplayer = Physics2D.OverlapCircleAll(left_attackPoint.position, attackRange, what_is_player);

                foreach (Collider2D player in hitplayer)
                {
                    player.GetComponent<player_take_damage>().TakeDamage(attack_damage, 4);
                }

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.left, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(-move_distance, 0, 0);
                }
            }
            else if(random_direction == 5)
            {
                wait_in_seconds = new_wait_in_seconds;
            }
            startTime = Time.time;
        }
    }
}
