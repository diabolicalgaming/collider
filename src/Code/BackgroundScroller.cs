using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Citation: -https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-scrolling-backgrounds.
/// This code is derived from Unity's background tutorial. I modified it a bit to follow the design principles (Awake, Start, Update)
/// and to stick with suitable naming schemes for the variables to describe what the program is doing.
/// </summary>

public class BackgroundScroller : MonoBehaviour
{
    /// <summary>
    /// Since I am offsetting the asset, I need to maintain the value I want without having to put it in the code.
    /// I will also need to reset the background to where it started from when the player exits the game.
    /// That value will be stored in begin.
    /// </summary>

    public float speed;
    private Vector2 begin;
    private Vector2 offset;
    private float moveX;

    // Start is called before the first frame update.
    private void Start()
    {
        this.begin = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame.
    private void Update()
    {
        //moveX loops so that the x position is never greater than 1.
        //This is what is going to move the image on the Quad.
        //It is set to 1 because it is offset by one whole value.
        this.moveX = Mathf.Repeat(Time.time * this.speed, 1);

        this.offset = new Vector2(this.moveX, this.begin.y);

        //I then grabbed the materiel/sprite I added to the Quad and set it to its main texture.
        //This basically wraps the material around the Quad so it looks as if it is moving.
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", this.offset);
    }

    /// <summary>
    /// This function is a call to Unity's OnDisable function, which will reset the value back to the saved offset 
    /// (this is the initial position of the sprite on the Quad).
    /// </summary>
    private void OnDisable()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", this.begin);
    }
}
