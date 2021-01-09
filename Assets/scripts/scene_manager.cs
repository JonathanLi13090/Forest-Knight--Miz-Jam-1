using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    public int scene_number;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(scene_number == 1)
            {
                SceneManager.LoadScene("tutorial");
            }
            else if (scene_number == 2)
            {
                
                SceneManager.LoadScene("end");
                //FindObjectOfType<AudioHandler>().PlaySound("player", "win_sound"); 
            }
            else if (scene_number == 3)
            {
                SceneManager.LoadScene("level-1");
            }
        }
    }
}
