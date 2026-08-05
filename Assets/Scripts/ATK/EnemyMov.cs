using System.Collections;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    [SerializeField] private Animator monsterAnim;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private GameObject player;

    [SerializeField] private BallManager ballManager;
    [SerializeField] private ScoreAtk sc;
    [SerializeField] private ParticleSystem hurtPart;
    public int scoreAtk;

    private void Awake()
    {
        scoreAtk = 0;
        hurtPart.Stop();
        //StartCoroutine("MoveCycle");
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            scoreAtk += 10;
            ballManager.ResetPosition(ball);

            monsterAnim.SetBool("isHurt", true);   
            StopCoroutine("MoveCycle");
            hurtPart.Play();
        }
    }

    /*public void MonsterHurt()
    {
        StopCoroutine("MoveCycle");
        scoreAtk += 1;
        monsterAnim.SetBool("isHurt", true);
            
    }*/

    void ReturnWalk()
    {
        monsterAnim.SetBool("isHurt", false);
        monsterAnim.SetBool("isRun", true);
        StartCoroutine("MoveCycle");
    }

    public void ResetEnemy()
    {
        StopAllCoroutines();
        StartCoroutine("MoveCycle");
    }

    public void PauseEnemy()
    {
        if (sc.isPaused)
        {
            StopAllCoroutines();
            monsterAnim.SetBool("isRun", false);
        } else
        {
            StopAllCoroutines();
            ReturnWalk();
        }
    }

    IEnumerator MoveCycle()
    {
        while (true)
        {
            monsterAnim.SetBool("isRun", true);

            Vector3 target = new Vector3(
                Random.Range(-6.0f, 1.0f),
                transform.position.y,
                Random.Range(5.8f, 8.5f)
            );

            while (Vector3.Distance(transform.position, target) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    target,
                    speed * Time.deltaTime
                );
                transform.LookAt(target);
                yield return null;
            }

            monsterAnim.SetBool("isRun", false);
            transform.LookAt(player.transform);

            yield return new WaitForSeconds(waitTime);
        }
    }
}
