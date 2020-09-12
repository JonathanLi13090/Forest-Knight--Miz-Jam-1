using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public float changeX;
    public float changeY;
    public float half_width;
    public float half_height;
    public Transform PlayerPos;
    private float current_camera_X;
    private float current_camera_Y;
    private float current_player_X;
    private float current_player_Y;

    // Update is called once per frame
    void Update()
    {
        current_camera_X = transform.position.x;
        current_camera_Y = transform.position.y;
        current_player_X = PlayerPos.position.x;
        current_player_Y = PlayerPos.position.y;

        if(current_player_X > current_camera_X + half_width)
        {
            transform.Translate(changeX, 0, 0);
        }
        else if(current_player_X < current_camera_X - half_width)
        {
            transform.Translate(-changeX, 0, 0);
        }
        else if(current_player_Y > current_camera_Y + half_height)
        {
            transform.Translate(0, changeY, 0);
        }
        else if(current_player_Y < current_camera_Y - half_height)
        {
            transform.Translate(0, -changeY, 0);
        }
    }
}
