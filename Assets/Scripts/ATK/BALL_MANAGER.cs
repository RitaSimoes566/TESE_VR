using UnityEngine;
using System.Collections.Generic;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject ballModel;
    [SerializeField] private int numberBalls = 5;

    public List<GameObject> balls  = new List<GameObject>();
    

    private void Start()
    {
        SpawnBalls(numberBalls);
        
    }

    public void SpawnBalls (int n)
    {
        for (int i = 0; i < n; i++)
        {
            GameObject ball = Instantiate(ballModel);
            Ball ballCode = ball.GetComponentInChildren<Ball>();

            float rx = Random.Range (-5.0f, 0.0f);
            float rz = Random.Range(2.0f, 4.5f);

            ballCode.SpawnBall(rx, rz);
            balls.Add(ball);
        }
    }

    public void ResetPosition (Ball ball)
    {

        float rx = Random.Range(-5.0f, 0.0f);
        float rz = Random.Range(2.0f, 4.5f);

        ball.SpawnBall(rx,rz);
    }
}
