using UnityEngine;
using System.Collections.Generic;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject ballModel;
    [SerializeField] private int numberBalls = 3;
    [SerializeField] private AudioManagerAtk audioMan;


    public List<GameObject> balls  = new List<GameObject>();
    private Vector3[] spawnPoints = new Vector3[4];
    private List<Vector3> availablePoints = new List<Vector3>();
    

    private void Start()
    {
        spawnPoints[0] = new Vector3(-1.95299995f, 0.294999987f, 2.36800003f);
        spawnPoints[1] = new Vector3(-1.66600001f, 0.163000003f, 3.27699995f);
        spawnPoints[2] = new Vector3(-3.65700006f, 0.317999989f, 2.25f);
        spawnPoints[3] = new Vector3(-4.1329999f, 0.264999986f, 3.22399998f);

        availablePoints = new List<Vector3>(spawnPoints);
    }

    public void StartBalls()
    {
        ClearBalls();
        availablePoints = new List<Vector3>(spawnPoints);
        SpawnBalls(numberBalls);
    }

    private void SpawnBalls (int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (availablePoints.Count == 0)
                availablePoints = new List<Vector3>(spawnPoints);

            GameObject ball = Instantiate(ballModel);
            Ball ballCode = ball.GetComponent<Ball>();

            int r = Random.Range(0, availablePoints.Count);
            Vector3 pos = availablePoints[r];
            availablePoints.RemoveAt(r);

            ballCode.SetCurrentSpawnPoint(pos);
            ballCode.SpawnBall(pos);

            ballCode.ballIndex = i;
            ballCode.audioManB = audioMan;

            audioMan.AddAudioBall(ball);
            balls.Add(ball);
        }
    }

    public void ResetPosition (Ball ball)
    {
        Vector3 oldPoint = ball.CurrentSpawnPoint;

        if (!availablePoints.Contains(oldPoint))
            availablePoints.Add(oldPoint);

        if (availablePoints.Count == 0)
            availablePoints = new List<Vector3>(spawnPoints);

        int r = Random.Range(0, availablePoints.Count);
        Vector3 pos = availablePoints[r];
        availablePoints.RemoveAt(r);

        ball.SetCurrentSpawnPoint(pos);
        ball.SpawnBall(pos);
    }

    public void ClearBalls()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i] != null)
                Destroy(balls[i]);
        }
        
        balls.Clear();
        audioMan.ClearBallAudio();
    }
}
