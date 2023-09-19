using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseDifficulty : MonoBehaviour
{
    public int ScoreToRaiseDifficulty = 5;
    private float speedToRaise = 0.5f;
    private float intervalToDecrease = 0.25f;
    public float maxObstacleSpeed = 15f;
    public float minObstacleInterval = 1f;

    private void Update()
    {
        if (GameManager.Instance.scoreToRaiseDifficultyController != ScoreToRaiseDifficulty) { return; }

        GameManager.Instance.scoreToRaiseDifficultyController = 0;

        if(GameManager.Instance.obstacleSpeed < maxObstacleSpeed)
        {
            GameManager.Instance.obstacleSpeed += speedToRaise;
        }

        if(GameManager.Instance.obstacleInterval > minObstacleInterval)
        {
            GameManager.Instance.obstacleInterval -= intervalToDecrease;
        }
    } 
}
