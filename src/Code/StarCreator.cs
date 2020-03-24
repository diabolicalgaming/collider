using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class in order to create stars on the background so that it looks like the player is really in space.
/// </summary>

public class StarCreator : MonoBehaviour
{
    public GameObject starMove;
    private int maxNumStars;

    private Vector2 bottomLeft;
    private Vector2 topRight;

    //Awake acts as a constructor
    private void Awake()
    {
        this.maxNumStars = 25;

        //Bottom left point of the camera view.
        this.bottomLeft = Camera.main.ViewportToWorldPoint(
            new Vector2(
                gameObject.GetComponent<SpawnPoints>().x1,
                gameObject.GetComponent<SpawnPoints>().y1
                )
            );

        //Top rigth point of the camera view.
        this.topRight = Camera.main.ViewportToWorldPoint(
            new Vector2(
                gameObject.GetComponent<SpawnPoints>().x2,
                gameObject.GetComponent<SpawnPoints>().y2
                )
            );
    }

    //Start is called before the first frame update
    private void Start()
    {
        CreateStar();
    }

    /// <summary>
    /// In space there are over 100 billion stars, so in order to make the player feel as if they are truly travelling through space,
    /// I have written this function so that I can instantiate x number of stars on the screen. It will create maxNumber of stars
    /// in random positions on the screen.
    /// </summary>
    private void CreateStar()
    {
        int num = 0;
        while (num < this.maxNumStars)
        {
            GameObject starObject = (GameObject)Instantiate(this.starMove);

            //create the stars at random x,y positions so that it looks as if the player is really in space
            float randomX = Random.Range(this.bottomLeft.x, this.topRight.x);
            float randomY = Random.Range(this.bottomLeft.y, this.topRight.y);
            starObject.transform.position = new Vector2(randomX, randomY);

            //so that the stars don't clump up together, assign a random speed to each star to make it look more realistic
            starObject.GetComponent<Stars>().StarSpeed = 0.8f + (1f * Random.value);

            //Make the star object a child of the StarCreatorMove object.
            //Since many stars are created at once the hierarchy will look a bit messy.
            //I made it a child so that it doesn't show in the hierarchy unless I click StarCreatorMove object 
            //drop down button in the Unity UI.

            starObject.transform.parent = transform;

            num++;
        }
    }
}
