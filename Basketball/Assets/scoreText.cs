using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    public Text textScore;
    public int playerScore = 0;

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Ball"))
        {
            playerScore += 1;
            textScore.text = playerScore.ToString();
        }
    }
}
