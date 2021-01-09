using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalenemymovement : MonoBehaviour
{
    public float wall_check_distance = 1f;
    public int damage;
    public LayerMask what_is_wall;
    public LayerMask what_is_player;
    public float move_distance = 1f;
    public SpriteRenderer sprite_renderer;
    public Sprite faceLeft;
    public Sprite faceRight;
    private float startTime;

    public Transform right_attackPoint;
    public Transform left_attackPoint;
    public float attackRange;
    public int attack_damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void move()
    {
        sprite_renderer.sprite = faceRight;

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
        else
        {
            move_distance = move_distance * -1;
            transform.Translate(move_distance, 0, 0);
        }
    }
}
