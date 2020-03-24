using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class to move objects down the y-axis. Note that this is not a class provided by Unity's API.
/// </summary>

public class ObjectGravity : MonoBehaviour
{
    public float speed;
    [HideInInspector] public Vector2 objectPosition;

    // Update is called once per frame.
    private void Update()
    {
        this.objectPosition = transform.position;
        //here I call the my PositionComputation function that I used to compute the position of the object.
        transform.position = PositionComputation(this.objectPosition,this.speed);
    }

    /// <summary>
    /// I have written this function to compute the new position of the object.
    /// This function is used to move an object down the y-axis.
    /// </summary>
    /// <returns> The new position of the object. </returns>
    public Vector2 PositionComputation(Vector2 _position, float _speed)
    {
        //Move the object down the y axis.
        _position = new Vector2(_position.x, _position.y - speed * Time.deltaTime);
        return _position;
    }
}
