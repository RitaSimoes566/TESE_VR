using UnityEngine;
using UnityEngine.UI;
using TMPro;


using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit.Attachment;
using UnityEngine.XR.Interaction.Toolkit.Gaze;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Registration;

public class Ball_b : MonoBehaviour
{
    //private EnemySpawn enemy;

    public GameObject ball;
    public GameObject enemyModel;
    public TextMeshProUGUI text;
    public GameObject gFloor;

    private Rigidbody ballRB;
    int score = 0;

    float posX, posZ;
    public HurtParticles particlesHurt;

    private void Awake()
    {
        ballRB = ball.GetComponent<Rigidbody>();
        ballRB.useGravity = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.SetText("Pontuação: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallGravityOn()
    {
        ballRB.useGravity = true;
    }

    public void BallGravityOff()
    {
        ballRB.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == enemyModel)
        {

            Debug.Log("hi");
            ChangePosB(enemyModel);
            particlesHurt.Hurt();

            ResetBallB();

            score += 1;
            text.SetText("Pontuação: " + score);

        }

        if (other.gameObject == gFloor)
        {
            ResetBallB();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        posX = Random.Range(-6, 1);
        posZ = Random.Range(6, 9);
    }

    public void ResetBallB()
    {
        Vector3 startPos = new Vector3(-0.9f, 1.2f, 5.3f);

        ballRB.linearVelocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
        ball.transform.position = startPos;

        BallGravityOff();
        
    }

    public void ChangePosB(GameObject enem)
    {
       
        posX = Random.Range(-6, 1);
        posZ = Random.Range(6, 9);
        enem.transform.position = new Vector3(posX, 0, posZ);


    }
}
