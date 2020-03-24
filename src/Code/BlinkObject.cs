using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Citation: -http://earthsquadron.blogspot.com/2016/07/unity3d-flash-colour-when-hit.html
/// This code is derived from the above link. I made some minor modifications to it to hide certain variables in the Inpspector because they
/// are default values and do not need to be changed. I also restructured it to meet my design pattern e.g (Awake, Start, Update) and
/// to stick with suitable naming schemes for the variables to describe what the program is doing.
/// </summary>

public class BlinkObject : MonoBehaviour
{
    [HideInInspector] public Color normal;
    [HideInInspector] public Renderer mesh;

    /// <summary>
    /// Want to be able to change this color in the Inspector.
    /// E.g. if player picks up collectable, then blink green.
    /// </summary>
    public Color BlinkColor { get; set; }
    public int amountOfBlinks = 3;

    //Awake to act as a constructor
    private void Awake()
    {
        this.normal = Color.white;
    }

    //Start is called before the first frame update
    private void Start()
    {
        this.mesh = GetComponent<Renderer>();
    }

    public void Blink()
    {
        //Starts a coroutine to blink the object when collision is detected.
        StartCoroutine(OnCollisionEnter());
    }

    /// <summary>
    /// This function is also from the link I have cited. It is called when a collider/rigidbody has begun touching enother collider/rigidbody.
    /// </summary>
    private IEnumerator OnCollisionEnter()
    {
        var renderer = this.mesh;
        if (renderer != null)
        {
            //When collision occurs, blink the object a certain colour x number of times.
            for (int i = 0; i <= this.amountOfBlinks; i++)
            {
                renderer.material.color = this.BlinkColor;
                yield return new WaitForSeconds(0.1f);
                renderer.material.color = this.normal;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
