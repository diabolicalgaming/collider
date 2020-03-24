using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have created this class to implement object pooling. There will be background objects that move in the game, such as planets so that the player looks like they 
/// are traveling through space. The idea of a pooling system is to reuse objects that have already been initialised rather than destroying them on demand.
/// </summary>

public class BackgroundObjectPooler : MonoBehaviour
{
    /// <summary>
    /// I will be using a queue because it is computationally inexpensive.
    /// This will allow me to add as many back ground objects as I want without causing too much lag.
    /// </summary>

    private Queue<GameObject> queueForBackgroundObjects;
    public GameObject[] arrayForBackgroundObjects;

    //Start is called before the first frame update
    private void Start()
    {
        BuildQueue();

        //Call the DequeueStationaryObjects function every 25 seconds
        InvokeRepeating("DequeueStationaryObjects", 0,25f);
    }

    /// <summary>
    /// I have written this function to build a queue of backgound objects (e.g. planets). This will take the background objects that I have added in the list of background objects
    /// and enqueue them to a queue.
    /// </summary>
    private Queue<GameObject> BuildQueue()
    {
        queueForBackgroundObjects = new Queue<GameObject>();

        for (int i = 0; i < arrayForBackgroundObjects.Length; i++)
        {
            queueForBackgroundObjects.Enqueue(arrayForBackgroundObjects[i]);
        }

        return queueForBackgroundObjects;
    }

    /// <summary>
    /// I have written this function to put the background objects that have stopped moving back on the queue.
    /// As the background objects move down the y axis towards the bottom of the screen,
    /// they will reach a point where they become stationary again.
    /// This function will enqueue those stationary background objects.
    /// </summary>
    private void EnqueueStationaryObjects()
    {
        int i = 0;
        while (i < arrayForBackgroundObjects.Length)
        {
            if ((!arrayForBackgroundObjects[i].GetComponent<BackgroundObject>().IsNotStationary) && (0 > arrayForBackgroundObjects[i].transform.position.y))
            {
                //Set the background object to a random x,y position before adding it back to the queue.
                //This is so that the player doesn't feel as if they are moving in circles, making it look more realistic.
                arrayForBackgroundObjects[i].GetComponent<BackgroundObject>().RetransformBOPosition();
                queueForBackgroundObjects.Enqueue(arrayForBackgroundObjects[i]);
            }
            i++;
        }
    }

    /// <summary>
    /// I written this function to dequeue the background objects from the queue so that they can move down the screen.
    /// Whenever the background objects move out of the screen, they become stationary.
    /// This function is going to check if the background objects are not moving (meaning they have left the screen).
    /// Add them back to the queue if they reach the bottom, to mimic the effect of travelling through space.
    /// This is the effect of pooling because I am reusing the objects that have already been initialised.
    /// </summary>
    private void DequeueStationaryObjects()
    {
        //Here I add the objects that are not moving back to the queue.
        //This is again just to make it look as if they player is really moving through space.
        EnqueueStationaryObjects();

        if(queueForBackgroundObjects.Count != 0)
        {
            //Dequeue a background object, which will then be selected background object to move down the screen.
            GameObject instanceOfBO = queueForBackgroundObjects.Dequeue();

            //I then make the selected background object IsNotStationary value to true so that it starts moving
            instanceOfBO.GetComponent<BackgroundObject>().IsNotStationary = true;
        }
        
        //If the queue that holds the background objects is empty, then return.
        else if(queueForBackgroundObjects.Count == 0)
        {
            return;
        }
    }
}
