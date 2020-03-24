using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class, which will be attached to each enemy missile object.
/// This class is responsible for moving the enemy missile object across the screen.
/// </summary>

public class EnemyMissile : MonoBehaviour
{
    public float missileSpeed;
    private Vector2 missileDirection;
    private Vector2 missilePosition;
    private bool isDirectionSet;

    private Vector2 topRight;
    private Vector2 bottomLeft;

    //Awake acts as a constructor.
    private void Awake()
    {
        this.isDirectionSet = false;
    }

    //Start is called before the first frame update.
    private void Start()
    {
        this.missilePosition = transform.position;
        this.topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        this.bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }

    //Update is called once per frame.
    private void Update()
    {
        /// <summary>
        /// Update the missile's position. Next I need to remove the missile from our game if the missile goes outside the screen
        /// </summary>
        if (isDirectionSet)
        {
            transform.position = EnemyMissilePositionComputation();
            DestroyOnExit();
        }
    }

    /// <summary>
    /// I have written this function to compute the missiles position so that it moves.
    /// </summary>
    /// <returns> Returns the missiles new position as a vector. </returns>
    public Vector2 EnemyMissilePositionComputation()
    {
        this.missilePosition += this.missileDirection * this.missileSpeed * Time.deltaTime;
        return this.missilePosition;
    }

    /// <summary>
    /// I have written this function to set the direction of the enemy missile.
    /// The direction is normalized to get a unit vector (A vector between -1 and 1 on the x and y axis).
    /// </summary>
    /// <param name="direction"> The direction that the you want the missile to travel </param>
    public void TravelInDirection(Vector2 direction)
    {
        this.missileDirection = direction.normalized;
        isDirectionSet = true;
    }

    /// <summary>
    /// I have written this function to destroy the enemies when they leave the view of the camera.
    /// Since I want this to be a reusable class, I will destroy the missiles when they leave the screen, 
    /// rather than when they move out of the bottom of the screen like I used to before.
    /// This is because, some of the enemies will have missiles that follow the player, 
    /// so they can exit at any point between the top and bottom of the camera.
    /// </summary>
    private void DestroyOnExit()
    {
        
        if ((transform.position.x > this.topRight.x)|| 
            (transform.position.y > this.topRight.y)|| 
            (transform.position.x < this.bottomLeft.x)||
            (transform.position.y < this.bottomLeft.y))
        {
            Destroy(gameObject);
        }
    }
}
