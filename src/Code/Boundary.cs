using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I made this class which will be attached the the PlayerShipMove object. It is responsible for setting the player bounderies.
/// I call it in the Playership class and it allows me to restrict the boundary where the playership can move.
/// Bascially, I use it to stop the player from moving out of the screen and also to stop them from being able
/// to me to the top of the screen.
/// </summary>

[System.Serializable]
public class Boundary
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
}
