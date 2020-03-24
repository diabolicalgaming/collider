using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The purpose of this class is to work with the PlayerController class to seperate my logic from the API.
/// Doing this will allow me to test if the player moves when the user provides input.
/// </summary>

public class HumbleMovement
{
    public float speed;

    public HumbleMovement()
    {
        //Default Constructor.
    }

    public HumbleMovement(float speed)
    {
        this.speed = speed;
    }

    /// <summary>
    /// I have created this function to calculate the players new position when they supply input.
    /// It is called in my PlayerController class.
    /// </summary>
    /// <returns> The players new position as a unit vector. </returns>
    public Vector2 ComputeMovement(float h, float v, float _deltaTime)
    {
        return new Vector2(h, v).normalized * this.speed * _deltaTime;
    }
}
