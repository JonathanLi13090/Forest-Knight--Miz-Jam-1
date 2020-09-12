using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder_script : MonoBehaviour
{
    public float wall_check_distance = 1f;
    public LayerMask what_is_wall;
    public LayerMask what_is_player;
    public float move_distance = 1f;
    private float startTime;
    public float wait_in_seconds = 5f;
    public Transform attackPoint;
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
            Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, what_is_player);

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
            startTime = Time.time;
        }
    }
}
