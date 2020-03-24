using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is written to move the Enemy side to side, based on the players position.
/// </summary>

public class Slicer : MonoBehaviour
{
    public float patrolSpeed;
    public Transform gizmo;
    private bool barrierDetected;
    private RaycastHit2D info;

    private void Awake()
    {
        this.barrierDetected = true;
    }

    private void Update()
    {
        Patrol();
    }

    /// <summary>
    /// I have written this function to move the enemy to the right.
    /// </summary>
    private void Move()
    {
        transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
    }

    /// <summary>
    /// I have written this function to allow the slicer to change its direction.
    /// </summary>
    /// <param name="degree"></param>
    private void Euler(float degree)
    {
        transform.eulerAngles = new Vector3(0, degree, 0);
    }

    /// <summary>
    /// I have written this function to shoot a raycast (a line) downwards.
    /// This raycast will act as a barrier, when the enemy hits this barrier,
    /// when the enemy hits the barrier, it will then move in the opposite direction.
    /// </summary>
    /// <param name="_barrier"> Is the object that holds the raycast. </param>
    /// <param name="_ray"> An imaginary line (raycast). </param>
    /// <returns></returns>
    private RaycastHit2D ShootRaycast(Transform _barrier, RaycastHit2D _ray)
    {
        _ray = Physics2D.Raycast(_barrier.position, Vector2.down, 2f);
        return _ray;
    }

    /// <summary>
    /// I have written this function to check when the barrier has been reached.
    /// </summary>
    private void DetectBarrarier()
    {
        // When the enemy reaches the barrier it should rotate and move in the opposite direction.
        if(barrierDetected == true)
        {
            // Denoted by Euler(-180), which means move back the opposite way.
            Euler(-180);
            barrierDetected = false;
        }
        else
        {
            //If it has reached the barrier on the other side, then set its degree to 0, which means
            //go back from where you came from (it came from the barrier on the right side).
            Euler(0);
            barrierDetected = true;
        }
    }

    private void Patrol()
    {
        if(transform.parent.GetComponent<Follow>() != null)
        {
            //When the parent has stopped moving.
            if (transform.parent.GetComponent<Follow>().stopped == true)
            {
                //Start to Patrol between the barriers.
                Move();
                this.info = ShootRaycast(this.gizmo, info);
                if (info.collider == false)
                {
                    DetectBarrarier();
                }
            }
        }
    }
}
