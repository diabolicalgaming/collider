using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class so that whenever the enemy ship move out of the screen, it is destroyed in the hierarchy.
/// Destroying objects after they leave the screen is very important. If you don't the objects will still be active in the scene
/// which can cause lag. Since this is an endless runner game, it wouldn't be ideal to keep objects that are not being rendered by
/// the camera alive.
/// </summary>

public class OutOfBounds : MonoBehaviour
{
    private Vector2 bottomLeft;

    // Start is called before the first frame update.
    private void Awake()
    {
        //The bottom point of the screen.
        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }

    // Update is called once per frame.
    private void Update()
    {
        //Here is where I call the function to destroy the enemy when it leaves the screen.
        DestroyOnExit();
    }

    /// <summary>
    /// I have written this function which destroys the enemy object when it leaves the screen.
    /// </summary>
    private void DestroyOnExit()
    {
        //If the game object goes below the bottom of the screen, then destroy it.
        if (bottomLeft.y > gameObject.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
