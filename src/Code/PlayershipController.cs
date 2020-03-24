using UnityEngine;

/// <summary>
/// I have written this class to allow the playership to move after it recieves input from the user.
/// Here I make a call to my dependency injector interface IUnityService (derived from the video cited in my IUnityService class). 
/// </summary>
public class PlayershipController : MonoBehaviour
{
    public float playerSpeed;
    [HideInInspector] public Vector2 playerPosition;

    public HumbleMovement humbleMovement;
    public IUnityService unityService;

    // Awake to act as a constructor.
    public void Awake()
    {
        this.playerSpeed = 5f;
        this.playerPosition = transform.position;
    }

    //Start is called before the first frame update.
    private void Start()
    {
        humbleMovement = new HumbleMovement(this.playerSpeed);
        if(unityService == null)
        {
            unityService = new UnityService();
        }
    }

    // Update is called once per frame.
    private void Update()
    {
        /// <summary>
        /// Here I make a call to my HumbleMovement class that will to compute the new position of the player after they supply input.
        /// unityService.GetAxisRaw will return the players new position based on their input (which uses Unity's Input class, which
        /// is called in my HumbleMovement class).
        /// </summary>
        this.playerPosition += humbleMovement.ComputeMovement(
            unityService.GetAxisRaw("Horizontal"),
            unityService.GetAxisRaw("Vertical"),
            unityService.GetDeltaTime());
    }
}
