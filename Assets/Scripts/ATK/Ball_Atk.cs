/*using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;


using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit.Attachment;
using UnityEngine.XR.Interaction.Toolkit.Gaze;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Registration;
using UnityEngine.XR.Interaction.Toolkit;

public class Ball_Atk : MonoBehaviour
{
    //private EnemySpawn enemy;

    public GameObject ballModel;

    //public int score = 0;
    public float speed = 0.3f;

    [SerializeField] private int numberBalls;
    public List<BallData> balls = new List<BallData>();

    public GameObject enemyModel;
    private Animator enemyAnim;

    private void Awake()
    {
        enemyAnim = enemyModel.GetComponent<Animator>();

        for (int i = 0; i < numberBalls ; i++)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(ballModel);

        float px = Random.Range(-5f, 0f);
        float pz = Random.Range(1f, 4f);
        Vector3 startPos = new Vector3(px, 0.19f, pz);
        ball.transform.position = startPos;

        BallData data = new BallData();
        data.obj = ball;
        //data.rb = ball.GetComponent<Rigidbody>();
        //data.gra = ball.GetComponent<FirstGrabGravity>();
        //data.rb.useGravity = false;

        //data.rb.linearVelocity = Vector3.zero;
        //data.rb.angularVelocity = Vector3.zero;

        balls.Add(data);
    }

    /*private IEnumerator MonsterMovement()
    {
        while (true)
        {
            // pick random position 
            posX = Random.Range(-6, 1);
            posZ = Random.Range(6, 9);

            // run to position

            float step = speed * Time.deltaTime;

            moveTarget = new Vector3(posX, 0, posZ);

            enemyModel.transform.position = Vector3.MoveTowards(enemyModel.transform.position, moveTarget, step);
            /*enemyAnim.SetBool("isRun", true);

    // stop running

    // wait while idle
    //}
    //}

    public void ResetBallAtk()
    {
        foreach (BallData data in balls)
        {
            float px = Random.Range(-5f, 0f);
            float pz = Random.Range(4f, 1f);

            Vector3 startPos = new Vector3(px, 0.19f, pz);
            data.obj.transform.position = startPos;

            //data.gra.firstGrabDone = false;
            //data.rb.useGravity = false;
            //data.rb.linearVelocity = Vector3.zero;
            //data.rb.angularVelocity = Vector3.zero;
            
        }
    }
}*/

using UnityEngine;
using System.Collections.Generic;

public class Ball_Atk : MonoBehaviour
{
    public GameObject ballModel;
    [SerializeField] private int numberBalls = 5;

    [System.Serializable]
    public class BallData
    {
        public GameObject obj;
        public Rigidbody rb;
        public FirstGrabGravity gra;
    }

    public List<BallData> balls = new List<BallData>();

    private void Awake()
    {
        for (int i = 0; i < numberBalls; i++)
            SpawnBall();
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(ballModel);

        float px = Random.Range(-5f, 0f);
        float pz = Random.Range(1f, 4f);
        ball.transform.position = new Vector3(px, 0.19f, pz);

        BallData data = new BallData();
        data.obj = ball;
        data.rb = ball.GetComponent<Rigidbody>();
        data.gra = ball.GetComponent<FirstGrabGravity>();

        if (data.rb != null)
        {
            data.rb.useGravity = false;
            data.rb.linearVelocity = Vector3.zero;
            data.rb.angularVelocity = Vector3.zero;
        }

        balls.Add(data);
    }

    public void ResetBallAtk()
    {
        foreach (BallData data in balls)
        {
            if (data.obj == null)
                continue;

            float px = Random.Range(-5f, 0f);
            float pz = Random.Range(1f, 4f);
            data.obj.transform.position = new Vector3(px, 0.19f, pz);

            if (data.gra != null)
                data.gra.firstGrabDone = false;

            if (data.rb != null)
            {
                data.rb.useGravity = false;
                data.rb.linearVelocity = Vector3.zero;
                data.rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
