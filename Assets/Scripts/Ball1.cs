using UnityEngine;
using UnityEngine.UI;
using TMPro;


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

public class Ball_b : MonoBehaviour
{
    //private EnemySpawn enemy;

    public GameObject ball;
    public GameObject enemyModel;
    public TextMeshProUGUI text;
    //public GameObject gFloor;

    private Rigidbody ballRB;
    private FirstGrabGravity ballGra;

    int score = 0;

    float posX, posZ;
    public HurtParticles particlesHurt;

    private void Awake()
    {
        ballRB = ball.GetComponent<Rigidbody>();
        ballRB.useGravity = false;

        ballGra = ball.GetComponent<FirstGrabGravity>();

        float rx = Random.Range(-5, 0);
        Vector3 startPos = new Vector3(rx, 1.44f, 5);
        ball.transform.position = startPos;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.SetText("Pontuação: " + score);
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

        /*if (other.gameObject == gFloor)
        {
            ResetBallB();
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        posX = Random.Range(-6, 1);
        posZ = Random.Range(6, 9);
    }

    public void ResetBallB()
    {
        float rx = Random.Range(-5, 0);
        Vector3 startPos = new Vector3(rx, 1.44f, 5);

        ballGra.firstGrabDone = false;
        ballRB.useGravity = false;
        ballRB.linearVelocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
        ball.transform.position = startPos;
        
    }

    public void ChangePosB(GameObject enem)
    {
       
        posX = Random.Range(-6, 1);
        posZ = Random.Range(6, 9);
        enem.transform.position = new Vector3(posX, 0, posZ);

    }

}
