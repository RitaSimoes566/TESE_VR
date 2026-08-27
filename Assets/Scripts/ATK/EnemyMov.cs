using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class EnemyMov : MonoBehaviour
{
    public Animator monsterAnim;
    [SerializeField] private float dinoVel = 2f;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private GameObject player;

    [SerializeField] private BallManager ballManager;
    [SerializeField] private ScoreAtk sc;
    [SerializeField] private ParticleSystem hurtPart;
    [SerializeField] private AudioManagerAtk audioManD;
    [SerializeField] private Slider sliderVel;
    public int scoreAtk;

    [SerializeField] private float[] velDif = new float[3];
    [SerializeField] private float[] waitDif = new float[3];

    private void Awake()
    {
        scoreAtk = 0;
        hurtPart.Stop();
        //StartCoroutine("MoveCycle");
        sliderVel.value = 1; // start at medium dif
        monsterAnim.enabled = false;
    }

    public void setDinoDif()
    {
        int difficulty = Mathf.RoundToInt(sliderVel.value);
        switch (difficulty)
        {
            case 0:
                dinoVel = velDif[0];
                waitTime = waitDif[0];
                break;

            case 1:
                dinoVel = velDif[1];
                waitTime = waitDif[1];
                break;

            case 2:
                dinoVel = velDif[2];
                waitTime = waitDif[2];
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            audioManD.BallAudioHit(ball.ballIndex);
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
        monsterAnim.enabled = true;
        StopAllCoroutines();
        StartCoroutine("MoveCycle");
    }

    public void PauseEnemy()
    {
        if (sc.isPaused)
        {
            StopAllCoroutines();
            monsterAnim.enabled = false;
            monsterAnim.SetBool("isRun", false);
        } else
        {
            StopAllCoroutines();
            monsterAnim.enabled = true;
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
                    dinoVel * Time.deltaTime
                );
                transform.LookAt(target);
                yield return null;
            }

            monsterAnim.SetBool("isRun", false);

            //lock dino rotation
            var adjusted = player.transform.position;
            adjusted.y = 0;
            transform.LookAt(adjusted);
            

            yield return new WaitForSeconds(waitTime);
        }
    }
}
