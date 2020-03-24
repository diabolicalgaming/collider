using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class to move the gunner enemy ship from one side of the screen to the other on the x axis and down the y axis.
/// </summary>

public class Gunner : MonoBehaviour
{
    public float speed;
    public float maxDistance;
    private Vector2 bottomLeft;
    [HideInInspector] public Vector2 gunnerPosition;
    [HideInInspector] public Vector2 nextPosition;

    //Start is called before the first frame update.
    private void Start()
    {
        this.gunnerPosition = transform.position;
        this.nextPosition = transform.position;
    }

    //Update is called once per frame.
    private void Update()
    {
        //Here I call my MoveDown_Y_SideToSide_X function to update the gunners new position.
        transform.position = MoveDown_Y_SideToSide_X();
    }

    /// <summary>
    /// I have written his function to move the gunner on the x-axis from one side of the screen to another.
    /// </summary>
    /// <returns> Returns the new position of the gunner on the x-axis. </returns>
    public float MoveSideToSide(Vector2 _position, float _maxDistance, float _speed)
    {
        _position.x = _position.x + (_maxDistance * Mathf.Sin(Time.time * this.speed));
        return _position.x;
    }

    /// <summary>
    /// I have written his function to move the gunner on the y-axis.
    /// </summary>
    /// <returns> Returns the new position of the gunner on the y-axis. </returns>
    public float MoveDown_Y(Vector2 _position, float _speed)
    {
        _position.y = _position.y - _speed * Time.deltaTime;
        return _position.y;
    }

    /// <summary>
    /// I have written this function which will allow me to compute the current position of the gunner.
    /// Here I make a call to my MoveSideToSide function to move the gunner from one side to the other on the x-axis
    /// and then move it down the y-axis at the same time.
    /// </summary>
    public Vector2 MoveDown_Y_SideToSide_X()
    {
        this.nextPosition.x = MoveSideToSide(this.gunnerPosition,this.maxDistance,this.speed);
        this.gunnerPosition.y = MoveDown_Y(this.gunnerPosition, this.speed);
        transform.position = new Vector2(this.nextPosition.x, this.gunnerPosition.y);
        return transform.position;
    }
}
