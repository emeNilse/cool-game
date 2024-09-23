using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float strength = 0f;
    public float force = 0f;
    float delay = 0f;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject shootingSpot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Press();
        delay -= Time.deltaTime;
    }

    // Update is called once per frame
    void Press()
    {
        
        if (Input.GetKey(KeyCode.Space) && delay <= 0)
        {
            
            strength += 0.1f;
        }
        if (Input.GetKeyUp(KeyCode.Space) || strength >= 6.5)
        {
            GameObject spawnedBall = Instantiate(ballPrefab, shootingSpot.transform.position, Quaternion.identity);
            spawnedBall.transform.parent = transform;
            
            force = strength;
         
            strength = 0f;
            delay = 1;
        }
       


    }
}
