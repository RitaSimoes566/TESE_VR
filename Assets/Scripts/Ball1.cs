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
    private Animator enemyAnim;
    public TextMeshProUGUI text;
    //public GameObject gFloor;
    
    private Rigidbody ballRB;
    private FirstGrabGravity ballGra;

    int score = 0;
    public float speed = 0.3f;

    float posX, posZ;
    public HurtParticles particlesHurt;

    private bool startTimer= false;
    public float hurtDuration = 0.5f;   // length of hurt anim (seconds)
    private bool isMoving = false;
    private Vector3 moveTarget;

    private void Awake()
    {
        enemyAnim = enemyModel.GetComponent<Animator>();
        ballRB = ball.GetComponent<Rigidbody>();
        ballRB.useGravity = false;

        ballGra = ball.GetComponent<FirstGrabGravity>();

        // get random ball position
        float rx = Random.Range(-5, 0);
        Vector3 startPos = new Vector3(rx, 1.44f, 5);
        ball.transform.position = startPos;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.SetText("Pontuação: " + score);
    }

    private void Update()
    {
        if (hurtDuration > 0f && startTimer)
        {
            hurtDuration -= Time.deltaTime;
            Debug.Log("im preparing to run");

        }
        if (hurtDuration <= 0)
        {
            Debug.Log("i will now run");
            startTimer = false;

            isMoving = true;
        }

        if (isMoving)
        {
            
            hurtDuration = 0.3f;
            RunToTarget();
            
        }
            Debug.Log(hurtDuration);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemyModel)
        {
            Debug.Log("hi");
            startTimer = true;

            enemyAnim.SetBool("isHurt", true);

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

        //enemyAnim.SetBool("isHurt", false);


    }

    public void RunToTarget()
    {
        float step = speed * Time.deltaTime;

        moveTarget = new Vector3(posX, 0, posZ);

        enemyModel.transform.position =
                Vector3.MoveTowards(enemyModel.transform.position, moveTarget, step);
        enemyAnim.SetBool("isRun", true);

        // reached destination?
        if (Vector3.Distance(enemyModel.transform.position, moveTarget) < 0.01f)
            {
                isMoving = false;
            enemyAnim.SetBool("isHurt", false); // go back to idle
            enemyAnim.SetBool("isRun", false); // go back to idle

            }
    }

    

}
