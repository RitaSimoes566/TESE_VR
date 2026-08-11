using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class ButterflySpawn : MonoBehaviour
{
    [SerializeField] int numberCluster = 5;
    public float vel = 7f;

    [SerializeField] float minDelay = 0.2f;
    [SerializeField] float maxDelay = 1.0f;

    public GameObject clusterModel;
    public List<GameObject> buttersClu = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI titleScore;
    [SerializeField] private TextMeshProUGUI titleScore1;
    [SerializeField] private Timer timer;
    public bool isPaused;

    public int score;

    [SerializeField] private AudioManager audioMan;

    //[SerializeField] private BeeColor beeColor;

    private void Awake()
    {
        isPaused = true;
        timer = timer.GetComponent<Timer>();
        textScore = textScore.GetComponent<TextMeshProUGUI>();
        audioMan = audioMan.GetComponent<AudioManager>();
        score = 0;
        WriteScore();
        //beeColor = beeModel.GetComponent<BeeColor>();
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
            for (int i = 0; i < buttersClu.Count; i++)
            {
                MoveBee(buttersClu[i]);
            }
        }

        if (timer.targetTime <= 0)
        {
            EndBees();
            titleScore.SetText("parabéns");
            titleScore1.SetText("parabéns");
        }
    }

    public void setVel( float butterVel)
    {
        vel = butterVel;
    }

    IEnumerator StartSpawnBees()
    {
        for (int i = 0; i < numberCluster; i++)
        {
            SpawnBee();

            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnBee()
    {
        float posx, posy, posz;
        GameObject butterClus = Instantiate(clusterModel);

        ButterflyCluster clusterCode = butterClus.GetComponent<ButterflyCluster>();
        clusterCode.SpawnCluster();

        butterClus.tag = "Bee";

        posx = Random.Range(3.1f , 9.0f);
        posy = Random.Range(0.5f ,2.0f);
        posz = 90;

        butterClus.transform.position = new Vector3 (posx, posy, posz);
        //bee.transform.rotation = Quaternion.Euler (0f , 180f , 0f);

        ParticleSystem bpart = butterClus.GetComponentInChildren<ParticleSystem>();
        bpart.Play();

        audioMan.GetAudioOfBee(butterClus);
        //beeColor.UndamageBee();

        buttersClu.Add(butterClus);
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
            pos.x = Random.Range(3.1f, 9.0f);
            pos.y = Random.Range(0.5f, 2.0f);

            //vel += 0.05f;

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
        /*foreach (GameObject bee in butters)
        {
            beeColor.UndamageBee();
        }*/

            StopAllCoroutines();

        for (int i = 0; i < buttersClu.Count; i++)
        {
            Destroy(buttersClu[i]);
            Destroy(audioMan.beeSource[i]);
        }

        audioMan.beeSource.Clear();
        buttersClu.Clear();

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

        foreach (GameObject butterClus in buttersClu)
        {
            ParticleSystem ps = butterClus.GetComponentInChildren<ParticleSystem>();
            Animator anim = butterClus.GetComponentInChildren<Animator>();

            if (ps != null && anim != null)
            {
                if (isPaused)
                {
                    ps.Stop();
                    anim.enabled = false;
                    textScore.SetText("Pausa");

                } else
                {
                    ps.Play();
                    anim.enabled = true;
                    WriteScore();
                }
            }
        } 
        
    }

    private void EndBees()
    {
        StopAllCoroutines();

        for (int i = 0; i < buttersClu.Count; i++)
        {
            Destroy(buttersClu[i]);
            Destroy(audioMan.beeSource[i]);
        }

        audioMan.beeSource.Clear();
        buttersClu.Clear();
        audioMan.StopBgMusic();
    }

    public void WriteScore()
    {

            if (score < 9)
            {
                textScore.SetText("000" + score.ToString());
            }
            else if (score < 99)
            {
                textScore.SetText("00" + score.ToString());
            }
            else if (score < 999)
            {
                textScore.SetText("0" + score.ToString());
            }
            else
            {
                textScore.SetText(score.ToString());
            }

    }
}
