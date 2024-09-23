using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    BallMovement ballMovement;

    Vector3 Direction = new Vector3(0, 1, -1);
    Rigidbody basketBall;
    float force = 0f;


    void Start()
    {
        basketBall = GetComponent<Rigidbody>();
        
        ballMovement = GetComponentInParent<BallMovement>();

        force = ballMovement.force;

        basketBall.velocity += Direction * force;

        Destroy(gameObject, 5);
        
    }

}
