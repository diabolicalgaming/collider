using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have made this class, which will be attached to all of the enemies and to the heart pick up object.
/// This class is used to determine how much damage and increase in health the player will take to their health points
/// depending on whether they collide with an enemy ship or with the heart pick up. This class allows me to assign different
/// damage points to each enemy and their missiles, i.e collision with a normal enemy ship should take less damage 
/// than collision with the mothership (boss) and collision with enemy missiles should take less damage than the collision with
/// an enemy ship or mothership.
/// </summary>

[System.Serializable]
public class DamagePoints : MonoBehaviour
{
    public float damagePoints;
}
