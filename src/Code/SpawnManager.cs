using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The purpose of this class is to be attached to the SpawnManager object in my game. This class is reponsible for
/// spawning objects based on their weights and the current position of the player.
/// </summary>

public class SpawnManager : MonoBehaviour
{
    public List<CustomObject> objectsList;

    public float startTime;
    public float maxSpawnRatePerSecond;
    public float minSpawnRatePerSecond;
    public float timeToIncrease = 180;

    GameObject playership;
    GameObject score;
    Vector3 positionOfCamera;

    int[] originalWeights;

    int average;

    private void Awake()
    {
        this.positionOfCamera = Camera.main.transform.position;
        this.playership = GameObject.Find("PlayershipMove");
        this.score = GameObject.Find("ScoreText");
    }

    private void Start()
    {
        StartSpawning();
        this.originalWeights = OriginalWeight(objectsList);
        if(PlayerPrefs.GetInt("AverageScore") == 0)
        {
            this.average = 10000;
        }
        else
        {
            this.average = PlayerPrefs.GetInt("AverageScore");
        }
    }

    private void Update()
    {
        AdjustWeights();
    }

    public void StartSpawning()
    {
        //Start spawning at start time.
        Invoke("SpawnObjectOnScreen", this.startTime);

        //Increase the rate every x seconds.
        InvokeRepeating("IncreaseRate", 0f, this.timeToIncrease);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnObjectOnScreen");
        CancelInvoke("IncreaseRate");
    }

    /// <summary>
    /// This function will allow me to increase the difficulty of the game.
    /// The longer the player stays alive, the quicker objects start to spawn.
    /// </summary>
    private void IncreaseRate()
    {
        //When the spawn rate in seconds reaches the minimum rate spawn rate per seconds, stop decremeenting.
        if (this.minSpawnRatePerSecond == this.maxSpawnRatePerSecond)
        {
            CancelInvoke("IncreaseRate");
        }

        //InvokeRepeating uses this condition until the spawn rate gets to minimum spawn rate per seconds.
        //The closer the spawn rate gets to 1, the quicker the objects spawn.
        if (this.minSpawnRatePerSecond < this.maxSpawnRatePerSecond)
        {
            this.maxSpawnRatePerSecond--;
        }
    }

    /// <summary>
    /// This function allows me to determing the time intervals that I want to spawn enemies at.
    /// This is going to allow each enemy to spawn at different time intervals.
    /// If they all spawned at the exact same time this would cause some Enemies to be spawned on top of each other and cause them to overlap.
    /// If two objects overlap they won't be able to move since our collision detection code will just assume that they are constantly colliding.
    /// </summary>
    private void ScheduleSpawn()
    {
        float spawnPerSeconds;

        if (this.minSpawnRatePerSecond < this.maxSpawnRatePerSecond)
        {
            /// <summary>
            /// As the rate of spawns per second decrease, the next time that the enemy should be spawned is at the decremented time.
            /// E.g. lets say the max spawn rate persond is 20 (i.e start spawning every 20 seconds), 
            /// after the next 30 seconds, decrement the max rate by 1 (to increase difficulty).
            /// Now the the new max spawn rate is 19 (i.e. start spawning after every 19 seconds now).
            /// </summary>

            spawnPerSeconds = this.maxSpawnRatePerSecond;
        }

        else
        {
            spawnPerSeconds = this.minSpawnRatePerSecond;
        }

        Invoke("SpawnObjectOnScreen", spawnPerSeconds);
    }

    /// <summary>
    /// This function is picks one object randomly based on the probability of each object.
    /// This is known as Cumilative Distribution. It picks a random number between 0 and the 
    /// total weight and checks if an item has a higher weight than the object chosen.
    /// It chooses the object with the highest weight that is greater than the number generated.
    /// </summary>
    private GameObject ObjectWithBestProbrability()
    {
        int total = 0;
        for (int i = 0; i < objectsList.Count; i++)
        {
            total += objectsList[i].weight;
        }

        int rand = Random.Range(0, total);
        GameObject instanceOfObject = null;
        foreach (CustomObject co in objectsList)
        {
            if (rand < co.weight)
            {
                instanceOfObject = co.customeObject;
                break;
            }
            rand -= co.weight;
        }
        return instanceOfObject;
    }

    /// <summary>
    /// This function is written to collect the original weights of the objects.
    /// </summary>
    public int[] OriginalWeight(List<CustomObject> lst)
    {
        int[] weights = new int[lst.Count];

        for (int i = 0; i < lst.Count; i++)
        {
            weights[i] = lst[i].weight;
        }

        return weights;
    }

    /// <summary>
    /// This function is written to reset the weights of the object when the players number of lives
    /// is greater than 3.
    /// </summary>
    public void ResetWeights()
    {
        for (int i = 0; i < this.objectsList.Count; i++)
        {
            this.objectsList[i].weight = this.originalWeights[i];
        }
    }

    /// <summary>
    /// This function will adjust the weights in the objects list, based on the players health and players score.
    /// </summary>
    public void AdjustWeights()
    {
        int max = objectsList.Max(m => m.weight);
        int maxIndex = 0;
        for(int i = 0; i < objectsList.Count; i++)
        {
            if(objectsList[i].weight == max)
            {
                //save the game object with the highest weight
                maxIndex = i;
            }

            if(playership != null)
            {
                if(playership.GetComponent<HealthPoints>().currentLives < 2 && playership.GetComponent<HealthPoints>().DamageHP < 75)
                {
                    //if the players HP is low, then adjust the weight of the heart collectable, so that it has the highest weight.
                    if(objectsList[i].customeObject.name.Equals("HeartPickUp"))
                    {
                        objectsList[maxIndex].weight = Mathf.Clamp(objectsList[i].weight+1,1,1);
                        objectsList[i].weight = max;
                    }
                }

                if(playership.GetComponent<HealthPoints>().currentLives > 1 && playership.GetComponent<HealthPoints>().DamageHP > 10)
                {
                    ResetWeights();
                }

                if(this.score != null)
                {
                    //If the player gets a very high score, then the next time the weights are reset, 
                    //readjust the weight of the MotherShip so it has more chance of being spawned.
                    if(this.score.GetComponent<PlayerScore>().Score > this.average)
                    {
                        if(objectsList[i].customeObject.name.Equals("MotherShip"))
                        {
                            objectsList[maxIndex].weight = 21;
                            originalWeights[i] = 8;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// I have written this function to spawn objects based on the players position on the x-axis.
    /// It takes the position of the Camera into account so that objects can be spawned from the top of the screen.
    /// For example, if the player is on the left hand side of the screen, then the object will spawn on the left hand side of the screen.
    /// </summary>
    private void SpawnObjectOnScreen()
    {
        //get an object from the objects lists based on weights.
        GameObject obj = ObjectWithBestProbrability();

        //create an instance of a random object from the list of objects
        GameObject instanceOfObject = (GameObject)Instantiate(obj);

        //As long as the player is alive...
        if (this.playership != null)
        {
            //Get the difference between the cameras position on the z axis and the players position on the z-axis.
            float difference = positionOfCamera.z - this.playership.transform.position.z;

            //Find the position of the upper border of the camera.
            Vector3 camToWorld = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, difference));
            if (instanceOfObject.GetComponent<SpawnPoints>() != null)
            {
                //Spawn the object in from of the player based on their position on the x-axis.
                camToWorld.x = instanceOfObject.GetComponent<SpawnPoints>().x1 * this.playership.transform.position.x;
                camToWorld = camToWorld + Vector3.up * instanceOfObject.GetComponent<SpawnPoints>().y1;
                instanceOfObject.transform.position = new Vector3(camToWorld.x, camToWorld.y, camToWorld.z);
            }

            instanceOfObject.transform.parent = transform;
        }
        //spawn the next Enemy
        ScheduleSpawn();
    }
}
