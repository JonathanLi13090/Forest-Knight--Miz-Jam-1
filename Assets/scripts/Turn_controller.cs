using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_controller : MonoBehaviour
{
    public List<GameObject> turn_queue;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = turn_queue[0];

        turn_queue.RemoveAt(0/*index number*/);
        turn_queue.Add(temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move_stuff()
    {

    }
}
