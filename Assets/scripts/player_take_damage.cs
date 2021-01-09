using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_take_damage: MonoBehaviour
{
   
    public int max_health;
    public ParticleSystem blood_particles;
    private int current_health;
    public float wall_check_distance = 1f;
    public int knockback_distance = 1;
    public LayerMask what_is_wall;
    public Transform cameraPos;
    public float SpawnPointX;
    public float SpawnPointY;
    public Vector2 SpawnPos;
    public float OffSetX = 11.5f;
    public float OffSetY = 0.5f;

    void Start()
    {
        current_health = max_health;
        SpawnPointX = cameraPos.position.x - OffSetX;
        SpawnPointY = cameraPos.position.y - OffSetY;
        SpawnPos = new Vector2(SpawnPointX, SpawnPointY);
    }

    public void Update()
    {
        SpawnPointX = cameraPos.position.x - OffSetX;
        SpawnPointY = cameraPos.position.y - OffSetY;
        SpawnPos = new Vector2(SpawnPointX, SpawnPointY);
    }

    public void TakeDamage(int damage, int direction)
    {
        current_health -= damage;
        blood_particles.Play();
        if (current_health <= 0)
        {
            FindObjectOfType<AudioHandler>().PlaySound("Player", "player_die");
            Die();
           
        }
        else
        {
            FindObjectOfType<AudioHandler>().PlaySound("Player", "player_hurt");
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
        blood_particles.Play();
        transform.position = SpawnPos;
        current_health = max_health;
    }
}
