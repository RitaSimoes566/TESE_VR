using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball : MonoBehaviour
{
    //private EnemySpawn enemy;

    public GameObject ball;
    public GameObject enemyModel;
    public TextMeshProUGUI text;

    private Rigidbody ballRB;
    int score = 0;

    float posX, posZ;
    public HurtParticles particlesHurt;

    private void Awake()
    {
        ballRB = ball.GetComponent<Rigidbody>();
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

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == enemyModel)
        {

            Debug.Log("hi");
            ChangePos(enemyModel);
            particlesHurt.Hurt();

            ResetBall();

            score += 1;
            text.SetText("Pontuação: " + score);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        posX = Random.Range(-6, 1);
        posZ = Random.Range(6, 9);
    }

    public void ResetBall()
    {
        Vector3 startPos = new Vector3(-1, 1, 3);

        ballRB.linearVelocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
        ball.transform.position = startPos;
    }

    public void ChangePos(GameObject enem)
    {
       
        posX = Random.Range(-6, 1);
        posZ = Random.Range(6, 9);
        enem.transform.position = new Vector3(posX, 0, posZ);


    }
}
