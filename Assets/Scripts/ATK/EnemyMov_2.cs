using UnityEngine;

public class Dino : MonoBehaviour
{
    bool isPlay;
    bool isHit;
    Animator dinoAnim;
    [SerializeField] private float speed = 0.5f;
    private BallManager ballManager;

    private void Awake()
    {
        isHit = false;
        dinoAnim = GetComponent<Animator>();
        transform.position = new Vector3(0f ,0f ,8.5f); // start pos
    }

    private void Update()
    {
        if (!isHit)
        {
            if (transform.position.x > -6.0f) //dino is not in final pos
            {
                DinoMove(); // walk to hive
            }
            else
            {
                DinoChomp(); //damage hive
            }
        } else
        {
            DinoKnockBack();
            dinoAnim.SetBool("isRun", true);
            dinoAnim.SetBool("isHurt", false);

        }

    }

    private void DinoMove()
    {
        Vector3 target = new Vector3( -6f, 0f, 8.5f); 
        dinoAnim.SetBool("isRun", true);

        transform.position = Vector3.MoveTowards(
                    transform.position,
                    target,
                    speed * Time.deltaTime
                );
        transform.LookAt(target);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponentInChildren<Ball>();
        if (ball != null)
        {
            ballManager.ResetPosition(ball);
            isHit = true;
        }
    }

    public void DinoHurt()
    {
        isHit = true;
    }

    void DinoKnockBack()
    {
        dinoAnim.SetBool("isHurt", true);

        Vector3 target = new Vector3 (
            transform.position.x + 0.5f, 
            transform.position.y, 
            transform.position.z
            );

        transform.position = target;

        transform.LookAt(target);
        isHit = false;

    }

    void DinoChomp()
    {
        dinoAnim.SetBool("isRun", false);
    }

    // victory/ defeat pose
}
