using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class, which will be attached to the Chaser prefab. The chaser moves towards the players last position, 
/// and stops x units (stoppingDistance) away from the players last position. It will then rotate to currently look at the 
/// players current position and fire missiles in the direction that the player is facing.
/// </summary>

public class Chaser : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 3f;
    [SerializeField] private float stoppingDistance = 2f;

    /// <summary>
    /// I will need three fields.
    /// 1. The playerShip field will allow me to access the current position of the playerhsip.
    /// 2. The players last position.
    /// 3. The direction that the chaser is facing.
    /// </summary>
    private Transform playerShip;
    private Vector2 lastPosition;
    private Vector2 direction;

    // Start is called before the first frame update.
    private void Start()
    {
        this.playerShip = GameObject.FindGameObjectWithTag("PlayershipTag").transform;
        this.lastPosition = this.playerShip.position;
    }

    // Update is called once per frame.
    private void Update()
    {
        /// <summary>
        /// Here I make a call to my LookAtPlayer function to allow the chaser to face the players current position.
        /// Rotate the Chaser to constantly look at the playership. I then make a call to the slerp  function from Unity's physics library to gradually rotate the Chaser towards the playership.
        /// You need to rotate towards the players position first before you chase them.
        /// </summary>
        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtPlayer(), this.rotationSpeed * Time.deltaTime);
        Chase();
    }

    /// <summary>
    /// I have written this function to allow the chaser to constantly face towards the players position.
    /// </summary>
    /// <returns> It returns a Quaternion rotation from the angle. </returns>
    public Quaternion LookAtPlayer()
    {
        //As long as the playership is not dead...
        if(this.playerShip != null)
        {
            //Find the direction between the Chasers position and the playerships position.
            this.direction = -this.playerShip.position + transform.position;
        }
        //Calculate the angle.
        float angle = Mathf.Atan2(this.direction.y, this.direction.x) * Mathf.Rad2Deg;
        //Create a Quaternion rotation from the angle.
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return rotation;
    }

    /// <summary>
    /// I wrote this function to force the Chaser to move towards the playerships last position before the next frame update.
    /// </summary>
    public void Chase()
    {
        if(this.playerShip != null)
        {
            //If the distance between the players last position and the Chaser is greater than the stopping distance...
            if (Vector2.Distance(transform.position, this.lastPosition) > this.stoppingDistance)
            {
                //Move the chaser towards the last position that the player was at.
                transform.position = Vector2.MoveTowards(transform.position, this.lastPosition, speed * Time.deltaTime);
            }
            //If the distance between the playerships position and Chaser position is less than the stopping distance...
            else if (Vector2.Distance(transform.position, this.playerShip.position) < this.stoppingDistance)
            {
                //Then stop moving the Chaser.
                //It is compared to the player's position so that It does not chase the player.
                transform.position = this.transform.position;
            }
        }
    }
}
