using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class is to destroy the parent object if all of its children have been destroyed.
/// For example, the RingParent has 8 ring child objects attached to it. When its child objects are destroyed,
/// the RingParent stays active in the scene. Overtime as more enemies are spawned, this can be come GPU intensive.
/// So this code detects if all child objects are destroyed before destroying the RingParent object.
/// </summary>

public class DestroyParent : MonoBehaviour
{
    private void Update()
    {
        if(gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
