using System.Collections;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    [SerializeField] private Animator monsterAnim;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private GameObject player;

    [SerializeField] private BallManager ballManager;
    public int scoreAtk;

    private void Awake()
    {
        scoreAtk = 0;
        StartCoroutine(MoveCycle());
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponentInChildren<Ball>();
        if (ball != null)
        {
            scoreAtk += 1;
            monsterAnim.SetBool("isHurt", true);
            ballManager.ResetPosition(ball);
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
