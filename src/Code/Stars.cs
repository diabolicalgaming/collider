using UnityEngine;

/// <summary>
/// I have written this class that will be attached to the star objects in the background.
/// The purpose of this class is to allow the stars to move.
/// </summary>

public class Stars : MonoBehaviour
{
    public float StarSpeed { get; set; }
    public Vector2 starPosition;

    private Vector2 bottomLeft;
    private Vector2 topRight;

    //Awake is used as a constructor.
    private void Awake()
    {
        this.StarSpeed = 0.5f;

        //Top right point of the camera view.
        this.topRight = Camera.main.ViewportToWorldPoint(
            new Vector2(
                gameObject.GetComponent<SpawnPoints>().x2,
                gameObject.GetComponent<SpawnPoints>().y2
                )
            );

        //Bottom left point of the camera view.
        this.bottomLeft = Camera.main.ViewportToWorldPoint(
            new Vector2(
                gameObject.GetComponent<SpawnPoints>().x1,
                gameObject.GetComponent<SpawnPoints>().y1
                )
            );
    }

    //Update is called once per frame.
    private void Update()
    {
        //reset the stars position
        ResetStarPosition();
    }

    /// <summary>
    /// I have written this function to compute the current position of each star, so that they move down the y-axis.
    /// Here I make a call to my HumbleMovement class so that the stars can move down the screen on the y-axis.
    /// </summary>
    /// <returns> It returns the new position of a particular star. </returns>
    public Vector2 StarPositionComputation(Vector2 _position, float speed)
    {
        //Move the stars down the y axis.
        _position = new Vector2(_position.x, _position.y - speed * Time.deltaTime);
        return _position;
    }

    /// <summary>
    /// I have written this function because the stars created will start to leave the camera view as they start to move down
    /// the y-axis. This function resets the position of the star to a random point on the top edge of the camera view and will
    /// position them on a random point on the left and right side of the camara view. This makes it look as if the player is really
    /// in space.
    /// </summary>
    private void ResetStarPosition()
    {
        //Get the current position of the star.
        this.starPosition = transform.position;

        transform.position = StarPositionComputation(this.starPosition,this.StarSpeed);

        if(this.bottomLeft.y > transform.position.y)
        {
            transform.position = new Vector2(Random.Range(this.bottomLeft.x, this.topRight.x), this.topRight.y);
        }
    }
}
