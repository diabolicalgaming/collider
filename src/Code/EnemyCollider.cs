using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class which will be attached to each enemy ship. Each enemy will have a kill score, which is the 
/// score that the player gets for killing the enemy. Some enemies will have a higher kill score than other enemies 
/// i.e. the mothership. Each enemy will also have health points (enemyMaxHp).
/// </summary>

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] private int killScore = 100;
    [SerializeField] private int enemyMaxHP = 10;
    private int damage;
    private bool collisionDetected;
    private GameObject scoreText;
    public GameObject explosionAnimationObject;
    public bool isBlinkable;

    //Awake to act as a constructor.
    private void Awake()
    {
        this.damage = 10;
        this.collisionDetected = false;
        scoreText = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    /// <summary>
    /// Here is where I make a call to Unity's Physics function OnTriggerEnter2D, which will detect collision between
    /// the enemy and other game objects. I then specify the actions that should take place upon collision with playership missile.
    /// Each enemy has my BlinkObject class attached to them as a component, so that they blink red upon collision with the player missiles.
    /// This is to notify the player that they have caused damaged to the enemy ship when they fire missiles.
    /// When the enemy's health points reach 0, the enemy is destroyed and the players score is incremented.
    /// </summary>
    /// <param name="collider"> The other object that the enemy ship collides with. </param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Detect collision with playership missiles
        if (collider.gameObject.tag == "PlayershipMissileTag")
        {
            //I noticed a bug in my program that caused the player score to double whenever two Missiles collide with the enemy.
            //To fix check if a collision has not already occured, then increment the player score.
            if (this.collisionDetected == false)
            {
                this.collisionDetected = true;
                this.enemyMaxHP -= this.damage;
                if(this.isBlinkable)
                {
                    gameObject.GetComponent<BlinkObject>().BlinkColor = Color.red;
                    gameObject.GetComponent<BlinkObject>().Blink();
                }
                if(enemyMaxHP <= 0)
                {
                    EnemyExplosion(); //play chaser explosion animation
                    FindObjectOfType<SoundManager>().Play("EnemyExplosion");
                    Destroy(gameObject);
                    scoreText.GetComponent<PlayerScore>().Score += this.killScore;
                }
                return;
            }
            this.collisionDetected = false;
        }
    }

    /// <summary>
    /// I have written this function to play the enemy explosion animation when the enemy ship is destroyed.
    /// It is called inside the OnTriggerEnter2D function.
    /// </summary>
    private void EnemyExplosion()
    {
        //Create an instance of the explosion animation.
        GameObject instanceOfExplosion = (GameObject)Instantiate(explosionAnimationObject);

        //The explosion animation should play at the position where the enemy ship was destroyed.
        instanceOfExplosion.transform.position = gameObject.transform.position;
    }
}
