using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float strength = 0f;
    public float force = 0f;
    float delay = 2f;
    float time = 0;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject shootingSpot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Press();
    }

    // Update is called once per frame
    void Press()
    {
        
        if (Input.GetKey(KeyCode.Space) && time < Time.time)
        {
            
            strength += 0.01f;

            
        }
        if (Input.GetKeyUp(KeyCode.Space) || strength > 6.0)
        {
            GameObject spawnedBall = Instantiate(ballPrefab, shootingSpot.transform.position, Quaternion.identity);
            spawnedBall.transform.parent = transform;

            force = strength;
            //sprinkler effect: strength = 10f
            strength = 0f;
            time = Time.time + delay;
        }



    }
}
