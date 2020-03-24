using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I have written this class so that the ring enemies can move in a circular path around their parent object.
/// The parent object will move down the y-axis so the ring is requires to constantly, move in a circular path
/// corresponding to the parents current position.
/// </summary>

public class Ring : MonoBehaviour
{
    [HideInInspector] public Vector2 velocity;
    [SerializeField] private float degree = -90;

    //Start is called before the first frame update.
    private void Start()
    {
        this.velocity = transform.position - transform.parent.position;
    }

    //Update is called once per frame.
    private void Update()
    {
        //Here I make a call to my CirclularMotion function to move the ring in a circular path.
        this.velocity = CircularMotion(this.velocity,this.degree);
        //I then update its position based on the parent, so that it constantly moves in a circular path around the parent object.
        transform.position = transform.parent.position + (Vector3)this.velocity;
    }

    /// <summary>
    /// I have written this function to move in a circular path around the Ring's parent object.
    /// </summary>
    /// <param name="_velocity"> The direction that the ring is travelling. </param>
    /// <param name="_degree"> The number of degrees per second. The higher the degree, the quicker it moves.</param>
    /// <returns></returns>
    public Vector2 CircularMotion(Vector2 _velocity, float _degree)
    {
        _velocity = Quaternion.AngleAxis(_degree * Time.deltaTime, Vector3.forward) * _velocity;
        return _velocity;
    }
}
