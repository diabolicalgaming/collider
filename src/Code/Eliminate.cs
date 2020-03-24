using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class to remove the last frame of any animation.
/// </summary>
public class Eliminate : MonoBehaviour
{
    /// <summary>
    /// For example, when the explosion animation plays, it leaves the last frame.
    /// I have written this function which will be added to the last frame of the animation to destroy it.
    /// I can check the last frame in the Unity UI because an animation is just multiple sprite images.
    /// The last frame contains the last sprite image.
    /// </summary>
    private void EliminateObject()
    {
        Destroy(gameObject);
    }
}
