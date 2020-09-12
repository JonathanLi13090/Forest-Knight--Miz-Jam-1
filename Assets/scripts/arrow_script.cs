using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_script : MonoBehaviour
{
    public float wall_check_distance = 1f;
    public LayerMask what_is_wall;
    public LayerMask what_is_player;
    public float move_distance = 1f;
    public SpriteRenderer sprite_renderer;
    public Sprite faceUp;
    public Sprite faceDown;
    public Sprite faceLeft;
    public Sprite faceRight;
    public int direction;
    private float startTime;
    public float wait_in_seconds = 5f;
    private float bowX;
    private float bowY;

    public Transform forward_attackPoint;
    public Transform backward_attackPoint;
    public Transform right_attackPoint;
    public Transform left_attackPoint;
    public float attackRange;
    public int attack_damage;
    private int moves;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > startTime + wait_in_seconds)
        {
            if (direction == 1)
            {
                sprite_renderer.sprite = faceUp;

                Collider2D[] hitplayer = Physics2D.OverlapCircleAll(forward_attackPoint.position, attackRange, what_is_player);

                foreach (Collider2D player in hitplayer)
                {
                    player.GetComponent<player_take_damage>().TakeDamage(attack_damage, 1);
                    transform.Translate(0, -move_distance * moves, 0);
                    moves = 0;
                }

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.up, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(0, move_distance, 0);
                    moves += 1;
                }
                else
                {
                    transform.Translate(0, -move_distance * moves, 0);
                    moves = 0;
                }
            }
            else if (direction == 2)
            {
                sprite_renderer.sprite = faceDown;

                Collider2D[] hitplayer = Physics2D.OverlapCircleAll(backward_attackPoint.position, attackRange, what_is_player);

                foreach (Collider2D player in hitplayer)
                {
                    player.GetComponent<player_take_damage>().TakeDamage(attack_damage, 2);
                    transform.Translate(0, move_distance * moves, 0);
                    moves = 0;
                }

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.down, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(0, -move_distance, 0);
                    moves += 1;
                }
                else
                {
                    transform.Translate(0, move_distance * moves, 0);
                    moves = 0;
                }
            }
            else if (direction == 3)
            {
                sprite_renderer.sprite = faceRight;

                Collider2D[] hitplayer = Physics2D.OverlapCircleAll(right_attackPoint.position, attackRange, what_is_player);

                foreach (Collider2D player in hitplayer)
                {
                    player.GetComponent<player_take_damage>().TakeDamage(attack_damage, 3);
                    transform.Translate(-move_distance * moves, 0, 0);
                    moves = 0;
                }

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.right, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(move_distance, 0, 0);
                    moves += 1;
                }
                else
                {
                    transform.Translate(-move_distance * moves, 0, 0);
                    moves = 0;
                }
            }
            else if (direction == 4)
            {
                sprite_renderer.sprite = faceLeft;

                Collider2D[] hitplayer = Physics2D.OverlapCircleAll(left_attackPoint.position, attackRange, what_is_player);

                foreach (Collider2D player in hitplayer)
                {
                    player.GetComponent<player_take_damage>().TakeDamage(attack_damage, 4);
                    transform.Translate(move_distance * moves, 0, 0);
                    moves = 0;
                }

                RaycastHit2D wallDetection = Physics2D.Raycast(transform.position, Vector2.left, wall_check_distance, what_is_wall);
                if (!wallDetection)
                {
                    transform.Translate(-move_distance, 0, 0);
                    moves += 1;
                }
                else
                {
                    transform.Translate(move_distance * moves, 0, 0);
                    moves = 0;
                }
            }
            startTime = Time.time;
        }
    }
}
