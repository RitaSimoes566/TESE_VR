using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class BeeSpawn : MonoBehaviour
{
    [SerializeField] int numberBees = 5;
    [SerializeField] float vel = 7f;

    [SerializeField] float minDelay = 0.2f;
    [SerializeField] float maxDelay = 1.0f;

    public GameObject beeModel;
    public List<GameObject> bees = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI titleScore;
    [SerializeField] private TextMeshProUGUI titleScore1;
    [SerializeField] private Timer timer;
    public bool isPaused;

    public int score;

    [SerializeField] private AudioManager audioMan;

    [SerializeField] private BeeColor beeColor;

    private void Awake()
    {
        isPaused = true;
        timer = timer.GetComponent<Timer>();
        textScore = textScore.GetComponent<TextMeshProUGUI>();
        audioMan = audioMan.GetComponent<AudioManager>();
        score = 0;
        WriteScore();
        beeColor = beeModel.GetComponent<BeeColor>();
        titleScore.SetText("Pontuação");
        titleScore1.SetText("Pontuação");
    }

    //float ms,frs;
    private void Update()
    {
        /*
        frs++;
        ms += Time.deltaTime;
        if (ms >= 1.0f)
        {
            print("----- " + frs);
            frs = 0;
            ms = 0;
        }
        */
        if (!isPaused && timer.targetTime >=0)
        {
            for (int i = 0; i < bees.Count; i++)
            {
                MoveBee(bees[i]);
            }
        }

        if (timer.targetTime <= 0)
        {
            EndBees();
            titleScore.SetText("parabéns");
            titleScore1.SetText("parabéns");
        }
    }

    IEnumerator StartSpawnBees()
    {
        for (int i = 0; i < numberBees; i++)
        {
            SpawnBee();

            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnBee()
    {
        float posx, posy, posz;
        GameObject bee = Instantiate(beeModel);
        bee.tag = "Bee";

        posx = Random.Range(4.0f , 14.5f);
        posy = Random.Range(0.0f ,1.5f);
        posz = 90;

        bee.transform.position = new Vector3 (posx, posy, posz);
        bee.transform.rotation = Quaternion.Euler (0f , 180f , 0f);

        ParticleSystem bpart = bee.GetComponentInChildren<ParticleSystem>();
        bpart.Play();

        audioMan.GetAudioOfBee(bee);
        beeColor.UndamageBee();

        bees.Add(bee);
    }

    void MoveBee(GameObject obj)
    {
        Vector3 pos = obj.transform.position;

        if (pos.z >= 10.0f)
        {
            pos.z -= vel * Time.deltaTime;
           
        } else
        {
            pos.z = 90;
            pos.x = Random.Range(3.0f, 14.5f);
            pos.y = Random.Range(0.0f, 1.5f);

            vel += 0.05f;

            if (obj.CompareTag("Bee"))
            {
                score += 10;
            } else if (obj.CompareTag("HitBee"))
            {
                obj.tag = "Bee";
            }
            WriteScore();
        }
        obj.transform.position = pos;
    }



    public void RestartBees()
    {
        foreach (GameObject bee in bees)
        {
            beeColor.UndamageBee();
        }

            StopAllCoroutines();

        for (int i = 0; i < bees.Count; i++)
        {
            Destroy(bees[i]);
            Destroy(audioMan.beeSource[i]);
        }

        audioMan.beeSource.Clear();
        bees.Clear();

        vel = 7f;
        score = 0;
        titleScore.SetText("Pontuação");
        titleScore1.SetText("Pontuação");
        WriteScore();

        isPaused = false;
        StartCoroutine(StartSpawnBees());
        
    }

    public void PauseBees()
    {
        isPaused = !isPaused;

        foreach (GameObject bee in bees)
        {
            ParticleSystem ps = bee.GetComponentInChildren<ParticleSystem>();
            Animator anim = bee.GetComponentInChildren<Animator>();

            if (ps != null && anim != null)
            {
                if (isPaused)
                {
                    ps.Stop();
                    anim.enabled = false;

                } else
                {
                    ps.Play();
                    anim.enabled = true;
                }
            }
        } 
        
    }

    private void EndBees()
    {
        StopAllCoroutines();

        for (int i = 0; i < bees.Count; i++)
        {
            Destroy(bees[i]);
            Destroy(audioMan.beeSource[i]);
        }

        audioMan.beeSource.Clear();
        bees.Clear();
    }

    public void WriteScore()
    {
        if (score < 9)
        {
            textScore.SetText("000" + score.ToString());
        } else if (score < 99)
        {
            textScore.SetText("00" + score.ToString());
        } else if (score < 999)
        {
            textScore.SetText("0" + score.ToString());
        } else
        {
            textScore.SetText(score.ToString());
        }
    }
}
