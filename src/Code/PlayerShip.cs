using System.Collections;
using UnityEngine;

/// <summary>
/// Citation: -https://answers.unity.com/questions/190905/reload-tutorial.html, commented by @PaxNemesis.
/// The above link allowed me to understand how to allow the player to reload.
/// I added a Couritine so that it works effeciently.
/// </summary>

public class PlayerShip : MonoBehaviour
{
    public GameObject playerShipMissileMovement;
    public GameObject playerMissilePosition1;
    public GameObject playerMissilePosition2;
    public GameObject playerExplosionAnimationObject;

    public Boundary boundary;

    /// <summary>
    /// I will limit the amount of times the player can fire missiles.
    /// Allowing the player to fire as much as they want is not ideal.
    /// It can cause the performance of the game to load because so many missiles prefabs will be created.
    /// </summary>

    private int maxNumMissiles;
    private int currentNumMissiles;
    private float reloadTime;

    /// <summary>
    /// //Every frame where the player runs out of missiles, the coroutine is started.
    /// This is very inefficient. It should only start once.
    /// Explanaition continued on line 155.
    /// </summary>

    private bool isReloading;

    //Awake acts as a constructor.
    private void Awake()
    {
        this.maxNumMissiles = 5;
        this.reloadTime = 0.5f;
        this.isReloading = false;
    }

    private void Start()
    {
        this.currentNumMissiles = this.maxNumMissiles;
    }

    private void Update()
    {
        FireMissiles();
        MoveInDirection();
    }

    /// <summary>
    /// I have written this function to allow the player to stay within the screen. Here I make a call to my
    /// Boundary class to enforce the players boundaries in the camera. This function also ensures that the player
    /// cannot access the top of the screen where enemies are spawning.
    /// </summary>

    private void MoveInDirection()
    {
        Vector2 position = FindObjectOfType<PlayershipController>().playerPosition;

        float ratio = (float)Screen.width / (float)Screen.height;
        float orthographicWidth = ratio * Camera.main.orthographicSize;

        if(position.x + this.boundary.xMax > orthographicWidth)
        {
            position.x = orthographicWidth - this.boundary.xMax;
        }

        if(position.x - this.boundary.xMin < -orthographicWidth)
        {
            position.x = -orthographicWidth + this.boundary.xMin;
        }

        if(position.y + this.boundary.yMax > Camera.main.orthographicSize)
        {
            position.y = Camera.main.orthographicSize - this.boundary.yMax;
        }

        if(position.y - this.boundary.yMin < -Camera.main.orthographicSize)
        {
            position.y = -Camera.main.orthographicSize + this.boundary.yMin;
        }

        //now we update the position of the player
        transform.position = position;
    }

    /// <summary>
    /// Here I make a call to Unity's physics function OnTriggerEnter2D to detect collision between the player and enemy ships
    /// or enemy missiles. I then specify the actions that should take place as explained below.
    /// </summary>
    /// <param name="collider"> The other object that the player collides with. </param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Detect collision of playership with the enemy or enemy missiles
        if(collider.tag == "EnemyTag" || collider.tag == "EnemyMissileTag")
        {
            //Each enemy or enemy missile has a Serializable class called DamagePoints.
            //This class allows me to decrement the players life by different values, depending on the value that each enemy has.
            //For example, enemy missiles cause less damage to the player than the player making direct contact with the enemy.
            if(collider.gameObject.GetComponent<DamagePoints>() != null)
            {
                FindObjectOfType<HealthPoints>().DecreaseHP(FindObjectOfType<DamagePoints>().damagePoints);
            }
            if(FindObjectOfType<HealthPoints>().currentLives == 0)
            {
                Destroy(gameObject);
                PlayershipExplosion();
                FindObjectOfType<SoundManager>().Play("PlayerDies");
                FindObjectOfType<GameManager>().GameOver();
            }
            //Blink red to show that the player has taken damage.
            //Play sound so that player knows that they have taken damage.
            if(collider.gameObject.GetComponent<DamagePoints>() != null)
            {
                gameObject.GetComponent<BlinkObject>().BlinkColor = Color.red;
                gameObject.GetComponent<BlinkObject>().Blink();
                FindObjectOfType<SoundManager>().Play("PlayerDamage");
            }
        }
    }

    /// <summary>
    /// I have written this function to play the playership explosion animation.
    /// </summary>
    private void PlayershipExplosion()
    {
        GameObject instanceOfExplosion = (GameObject)Instantiate(playerExplosionAnimationObject);

        //the explosion animation should play at the position where the playership was destroyed
        instanceOfExplosion.transform.position = transform.position;
    }

    /// <summary>
    /// When the player runs out of missiles, I have written this function which is called to reload the number 
    /// of missiles they have after x number of seconds.
    /// </summary>
    private IEnumerator ReloadNumMissiles()
    {
        //Set isReloading to true to begin reloading.
        this.isReloading = true;

        //wait for a certain amount of time before you reload the number of missiles the player has.
        yield return new WaitForSeconds(this.reloadTime);
        this.currentNumMissiles = this.maxNumMissiles;

        //After the missiles have all been reloaded, you set isReloading to false;
        this.isReloading = false;
    }

    /// <summary>
    /// Here I have written a function that will call my ReloadingNumMussiles function when the player runs out of missiles.
    /// It is also responsible for firing the missiles when the player presses the space button.
    /// </summary>
    private void FireMissiles()
    {
        //You will need to check if the player is reloading.
        //If they are currently reloading, then you don't have to execute any of
        //other actions in this method.
        if(this.isReloading)
        {
            return;
        }

        if(this.currentNumMissiles <= 0)
        {
            StartCoroutine(ReloadNumMissiles());
            //I don't want to check for input and then fire, so return.
            return;
        }

        //Fire the missiles when the space button is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !GameMenu.Paused)
        {
            //Play a sound when the player shoots.
            FindObjectOfType<SoundManager>().Play("PlayerShoots");

            //Decrement the number of missiles that the player currently has.
            this.currentNumMissiles--;

            //instantiate position1 missile
            GameObject missileAtPosition1 = (GameObject)Instantiate(this.playerShipMissileMovement);
            //initial position of missile
            missileAtPosition1.transform.position = this.playerMissilePosition1.transform.position;

            //make the missile at position 1 a child of the PlayershipMove
            missileAtPosition1.transform.parent = transform;

            //instantiate position2 missile
            GameObject missileAtPosition2 = (GameObject)Instantiate(this.playerShipMissileMovement);
            //initial position of missile
            missileAtPosition2.transform.position = this.playerMissilePosition2.transform.position;

            //make the missile at position 2 a child of the PlayershipMove
            missileAtPosition2.transform.parent = transform;
        }
    }
}
