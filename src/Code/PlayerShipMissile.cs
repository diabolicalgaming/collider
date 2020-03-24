using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class to allow the players missiles to move up the y axis and to destroy the missiles when they leave the screen
/// (to avoid lag and drawing more power from the GPU).
/// </summary>

public class PlayerShipMissile : MonoBehaviour
{
    private float missileSpeed;
    Vector2 missilePosition;

    private void Awake()
    {
        this.missileSpeed = 8f;
    }

    // Start is called before the first frame update.
    private void Start()
    {
        //to begin, get the current (x,y) position of the missile
        this.missilePosition = transform.position;
    }

    // Update is called once per frame.
    private void Update()
    {
        this.missilePosition = MissilePositionComputation(this.missilePosition, this.missileSpeed);

        transform.position = this.missilePosition;

        DestroyMissileOnExit();
    }

    /// <summary>
    /// I have written this function to move the player missiles up the y axis.
    /// Since the front of the ship is facing the y axis, I will need to increment the missile position up the y-axis.
    /// </summary>
    /// <param name="position"> The position of the missile. </param>
    /// <param name="speed"> The speed of the missile. </param>
    /// <returns> The new position of the missile on the y-axis. </returns>
    public Vector2 MissilePositionComputation(Vector2 position, float speed)
    {
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        return position;
    }

    /// <summary>
    /// Here I make a call to Unity's physics function OnTriggerEnter2D to detect collision between the missile and the enemy ship.
    /// This function will trigger when there is a collision of game objects. On collision with the enemy ship, I will destroy
    /// the players missiles, otherwise it will just pass through the enemy ship (which will look unrealistic).
    /// </summary>
    /// <param name="collider"> The other object that the missile collides with. </param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "EnemyTag")
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// I have written this function to destroy the players missile when it moves past the top of the screen.
    /// What happens in games is that unused objects tend to cause memory leaks
    /// When the missile leaves the screen, it will still be used by memory.
    /// This obviously isn't efficient since this game is an "endless runner game".
    /// So I need to destroy it.
    /// </summary>
    private void DestroyMissileOnExit()
    {
        //here the value top is the very top-right of the screen
        Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //whenever the missile leaves the player screen destroy it
        if (topRight.y < transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
