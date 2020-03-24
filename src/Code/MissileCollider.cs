using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class that will be attached to each enemy missile object. The purpose of this class is to
/// destroy the enemy missile when it collides with the player. This is done just to ensure that objects that are not being
/// used are destroyed so that they no longe draw GPU memory or cause lag.
/// </summary>

public class MissileCollider : MonoBehaviour
{
    /// <summary>
    /// Here I make a call to Unity's physics function OnTriggerEnter2D to detect collision between the enemy missile and
    /// the player ship. Upon collision with the player ship, the enemy missile will be destroyed.
    /// </summary>
    /// <param name="collider"> The other object that collides with the enemy missile object. </param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Destroy the missile if it collides with the playership, rather than just letting it pass throught the playership.
        if (collider.tag == "PlayershipTag")
        {
            Destroy(gameObject);
        }
    }
}
