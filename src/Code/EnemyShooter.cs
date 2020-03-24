using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I created this class so that it can be attached to each enemy ships shooter object.
/// Each enemy has a a child object, named enemyName_Shooter (e.g. the chaser enemy has a child object called ChaserShooter).
/// This class is responsible for firing the missiles in the direction of the player.
/// </summary>
/// 
[System.Serializable]
public class EnemyShooter : MonoBehaviour
{
    public GameObject enemyMissile;
    private Transform playerShip;
    private Vector2 direction;
    public float startTime;
    public float repeatTime;

    // Start is called before the first frame update
    private void Start()
    {
        //Get the players current position before the next frame update.
        this.playerShip = GameObject.FindGameObjectWithTag("PlayershipTag").transform;
        //Here is where I call the FireEnemyMissile function. It starts to fire at the player after
        //x seconds have past and repeats every y seconds.
        InvokeRepeating("FireEnemyMissile", this.startTime, this.repeatTime);
    }

    /// <summary>
    /// I have written this function to fire the enemy missiles in the direction of the player.
    /// As long as the player is alive, keep firing the missiles.
    /// Play the shooting sound whenever a missile is fired.
    /// Get the current position of the missile.
    /// To move the missile towards the players position, decrement it from the players current position.
    /// Normalize the distance, so that the missile does not move too fast.
    /// This sets the orthographic width and height of the camera view to 1.
    /// Make each instance of the missile a child of the Shooter Object of each Enemy parent object.
    /// </summary>
    public void FireEnemyMissile()
    {
        if(this.playerShip != null)
        {
            GameObject instanceOfMissile = (GameObject)Instantiate(enemyMissile);
            FindObjectOfType<SoundManager>().Play("EnemyShoots");
            instanceOfMissile.transform.position = transform.position;
            this.direction = this.playerShip.transform.position - instanceOfMissile.transform.position;
            instanceOfMissile.GetComponent<EnemyMissile>().TravelInDirection(this.direction);
            instanceOfMissile.transform.parent = transform;
        }
    }
}
