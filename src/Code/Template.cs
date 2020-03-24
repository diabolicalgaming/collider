using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// I created this class so that I can store the values pulled from the database in the child objects of each template
/// object. Each template object has 3 child objects, rank, player and score objects.
/// This class is added to each template component and holds the child objects for each of the templates,
/// e.g. rank, player, and score objects.
/// </summary>

public class Template : MonoBehaviour
{
    public GameObject rank;
    public GameObject player;
    public GameObject score;
}
