using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is attached to the HeartPickUp object.
/// </summary>

public class HeartCollider : MonoBehaviour
{
    private GameObject playerShip;
    public bool isBlinkable;

    //Start is called before the first frame update.
    private void Start()
    {
        this.playerShip = GameObject.FindGameObjectWithTag("PlayershipTag");
    }

    /// <summary>
    /// Here I make a call to Unity's physics function OnTriggerEnter2D to detect collision between the playership and HeartPickUp object.
    /// If the HeartPickUp collides with the playership...
    /// I call my BlinkObject class to blink the playership green to indicate to the player that they have gained an increase in health points.
    /// Here I call my DamagePoints class to increase the players health points.
    /// Destroy the HeartPickUp when it has been collected by the player.
    /// </summary>
    /// <param name="collider"> The other object that the HeartPickUp has collided with. </param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "PlayershipTag")
        {
            //As long as the playership is alive...
            if(this.playerShip != null)
            {
                if(this.isBlinkable)
                {
                    this.playerShip.GetComponent<BlinkObject>().BlinkColor = Color.green;
                    this.playerShip.GetComponent<BlinkObject>().Blink();
                }
                this.playerShip.GetComponent<HealthPoints>().IncreaseHP(gameObject.GetComponent<DamagePoints>().damagePoints);
            }
            FindObjectOfType<SoundManager>().Play("TakeHealth");
            Destroy(gameObject);
        }
    }
}
