using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class which will be attached to the stars and background objects, to control the position at which they spawn.
/// Note: These are not hard coded. The stars and planets spawn at random positions in the background.
/// x1 and y1 indicate the bottom left corner of the screen at position (0,0) and x2 and y2 indicate the top right corner 
/// of the screen at position (1,1). These means that the planets and stars will spawn at a random position between the
/// bottom left corner and top right corner of the screen. This is just to ensure that they always spawn within the camera view.
/// </summary>
public class SpawnPoints : MonoBehaviour
{
    public float x1 = 0;
    public float y1 = 0;
    public float x2 = 1;
    public float y2 = 1;
}
