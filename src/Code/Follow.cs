using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will be attached to the Patrol enemy. It allows the enemy to follow the player 
/// and to always remain in front of the player.
/// </summary>

public class Follow : MonoBehaviour
{
    public float speed;
    [HideInInspector] public bool stopped;

    private GameObject player;
    private Transform stop;
    private float stoppingDistance;

    private void Awake()
    {
        this.stoppingDistance = 0;
        this.stopped = false;
        this.player = GameObject.Find("PlayershipMove");
        if(this.player != null)
        {
            this.stop = this.player.transform.GetChild(3);
        }

        transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
    }

    public void Update()
    {
        StayInFront(this.stoppingDistance, this.speed);
    }

    /// <summary>
    /// I have written this funtion to track the players current position and 
    /// to remain in front of the player at all times regardless of the players position.
    /// </summary>
    private void StayInFront(float _stoppingDistance, float _speed)
    {
        //As long as the player is alive.
        if(this.player != null)
        {
            //Move towards the players stopping position.
            if(Vector2.Distance(transform.position, stop.transform.position) > _stoppingDistance)
            {
                //When the enemy stops at the players stopping position, in order to keep the enemy in front of the player at all times
                //Make the player the parent of the enemy, this enforces that the enemy stays in front of the player regardless of what position the player is at.
                gameObject.transform.parent = stop.transform.parent;
                transform.position = Vector2.MoveTowards(transform.position, stop.transform.position, _speed * Time.deltaTime);
                
                //If the players stopping position is reached, then set its stopped flag to true.
                //This is so that the enemy can start patrolling (Look at Slicer script.)
                if(transform.position.x == stop.position.x)
                {
                    if(transform.childCount != 0)
                    {
                        transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
                    }
                    stopped = true;
                }
            }
        }
    }
}
