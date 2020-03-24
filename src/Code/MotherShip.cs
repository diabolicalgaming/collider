using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float startWaitTime;
    private float waitTime;
    private int randomPosition;
    private List<Transform> movingPositions = new List<Transform>();
    [HideInInspector] public GameObject[] positionObjects;

    private Transform playerShip;
    private Vector2 direction;
    private float rotationSpeed;

    private Vector2 topRight;
    private Vector2 bottomLeft;

    private GameObject spawnManager;

    //Awake to act as a constructor.
    private void Awake()
    {
        this.speed = 10f;
        this.rotationSpeed = 3f;
        this.startWaitTime = 3f;
        this.topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        this.bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.waitTime = this.startWaitTime;
        //The int value can only be equal to a number between 0 and the length of the array.
        this.randomPosition = Random.Range(0,this.movingPositions.Count);
        this.playerShip = GameObject.FindGameObjectWithTag("PlayershipTag").transform;
        this.spawnManager = GameObject.Find("SpawnManager");
        this.positionObjects = GameObject.FindGameObjectsWithTag("MovingPosition");
        foreach(GameObject go in positionObjects)
        {
            movingPositions.Add(go.transform);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = ComputeMovingPosition(this.speed);
        CheckDistance(transform.position);
        MotherShipHasArrived();
    }

    public Vector2 ComputeMovingPosition(float speed)
    {
        //Move the MotherShip to a random position that is part of the list of potisions.
        transform.position = Vector2.MoveTowards(transform.position, movingPositions[randomPosition].position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtPlayer(), this.rotationSpeed * Time.deltaTime);
        return transform.position;
    }

    //Function to allow MotherShip to look at the players position.
    public Quaternion LookAtPlayer()
    {
        //As long as the playership is not dead...
        if (this.playerShip != null)
        {
            //Find the direction between the Motherships position and the playerships position.
            this.direction = -this.playerShip.position + transform.position;
        }
        //Calculate the angle.
        float angle = Mathf.Atan2(this.direction.y, this.direction.x) * Mathf.Rad2Deg;
        //Create a Quaternion rotation from the angle.
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return rotation;
    }

    /// <summary>
    /// To make an accurate check to see if the MotherShip has reached it desired destination...
    /// Calculate the distance between the MotherShip's current position and its destination.
    /// If the distance is smaller than 0.2f, assume that the MotherShip has reached its goal, and the if statement will become true.
    /// </summary>
    /// <param name="position"> The current position of the MotherShip. </param>
    private void CheckDistance(Vector2 position)
    {
        position = transform.position;
        if (Vector2.Distance(position,movingPositions[randomPosition].position) < 0.2f)
        {
            //Check if it is time for the MotherShip to start moving again to a new random position.
            if (this.waitTime <= 0)
            {
                this.randomPosition = Random.Range(0, this.movingPositions.Count);
                this.waitTime = this.startWaitTime;
            }
            //If it is not, then decrease the wait time. This makes the MotherShip stay idle for x number of seconds.
            else
            {
                this.waitTime -= Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// If the MotherShip has entered the CameraView then stop spawning the other enemies.
    /// If the MotherShip has arrived, then stop spawning the other enemies to make it fair to the player.
    /// But also stop spawning collectables to even the playing field for the MotherShip.
    /// </summary>
    private void MotherShipHasArrived()
    {
        if(transform.position.y < topRight.y && transform.position.y > bottomLeft.y)
        {
            if(this.spawnManager != null)
            {
                this.spawnManager.GetComponent<SpawnManager>().StopSpawning();
            }
        }
    }

    /// <summary>
    /// If the MotherShip has been destroyed...
    /// Because I disable the enemy and boss spawner in my GameManager, if the Mothership is currently alive when the game is over...
    /// Unity will call OnDisable(), which will start spawning the enemies again, to avoid this, when the GameManager is in the GameOver state...
    /// meaning that the enemy,boss, and collectable spawners have been disabled, they are no longer active in the scene, if they aren't active then stop spawning.
    /// </summary>
    private void OnDisable()
    {
        if(this.spawnManager != null)
        {
            if(!this.spawnManager.activeSelf)
            {
                this.spawnManager.GetComponent<SpawnManager>().StopSpawning();
                return;
            }
            this.spawnManager.GetComponent<SpawnManager>().StartSpawning();
        }
    }
}
