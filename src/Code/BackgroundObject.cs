using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The purpose of this class is to be attached to the objects moving in the backgroud. (i.e. planets etc)
/// </summary>

public class BackgroundObject : MonoBehaviour
{
    private Vector2 backgroundObjectPosition;
    private float backgroundObjectSpeed;
    public bool IsNotStationary { get; set; }

    private Vector2 bottomLeft;
    private Vector2 topRight;

    //Awake acts as a constructor.
    private void Awake()
    {
        this.backgroundObjectSpeed = 0.4f;
        this.bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(-0.5f, -0.5f));
        this.IsNotStationary = false;
    }

    // Update is called once per frame.
    private void Update()
    {
        StopMoving();
    }

    /// <summary>
    /// I have written this function to compute the position of each background object.
    /// </summary>
    /// <returns> The current Vector position of the object in 2D space. </returns>
    public Vector2 BOPositionComputation(Vector2 _position, float _speed)
    {
        //incrememnt the background objects position down the y axis.
        _position = new Vector2(_position.x, _position.y - _speed * Time.deltaTime);
        return _position;
    }

    /// <summary>
    /// I have created this function to allow me to set the background objects back to a random x,y position.
    /// Since I want to look as if the player is moving past background objects,
    /// rather than set each background objects to the same position, I will set it to a random x,y position of the screen.
    /// I have added my SpawnPoints class as a component to each background game object.
    /// I make a call to my SpawnPoints class, which will allow me to control the points at which each of the background game objects spawn.
    /// </summary>
    public void RetransformBOPosition()
    {
        Vector2 retTopRight = Camera.main.ViewportToWorldPoint(
            new Vector2(
                gameObject.GetComponent<SpawnPoints>().x2,
                gameObject.GetComponent<SpawnPoints>().y2
                )
            );

        Vector2 retBottomLeft = Camera.main.ViewportToWorldPoint(
            new Vector2(
                gameObject.GetComponent<SpawnPoints>().x1,
                gameObject.GetComponent<SpawnPoints>().y1
                )
            );

        transform.position = new Vector2(Random.Range(retBottomLeft.x, retTopRight.x), retTopRight.y);
    }

    /// <summary>
    /// I have written this function to stop background objects from moving when they move below the screen.
    /// When the background objects move out of the bottom of the screen, there is no point of them moving anymore.
    /// I wrote this function to stop the background objects from moving when they leave the screen.
    /// </summary>
    private void StopMoving()
    {
        if(!this.IsNotStationary)
        {
            return;
        }

        //I will need to get each background objects current position.
        this.backgroundObjectPosition = transform.position;
        transform.position = BOPositionComputation(this.backgroundObjectPosition, this.backgroundObjectSpeed);

        //when the background objects get to the bottom of the screen,
        //set the background objects IsNotStationary to false to make it stationary.
        if(this.bottomLeft.y > transform.position.y)
        {
            this.IsNotStationary = false;
        }
    }
}
