using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class ButterflySpawn : MonoBehaviour
{

    [SerializeField] private int numberCluster;
    public float vel;
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;

    public GameObject clusterModel;
    public List<GameObject> buttersClu = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI titleScore;
    [SerializeField] private TextMeshProUGUI titleScore1;
    [SerializeField] private Timer timer;
    [SerializeField] private SettingsDef setDef;
    public bool isPaused;
    public bool isEnd;

    public int score;

    [SerializeField] private AudioManager audioMan;
    [SerializeField] private Slider velSlider;

    [SerializeField] private BeeColor beeColor;

    private void Awake()
    {
        isPaused = true;
        isEnd = false;
        timer = timer.GetComponent<Timer>();
        textScore = textScore.GetComponent<TextMeshProUGUI>();
        audioMan = audioMan.GetComponent<AudioManager>();
        score = 0;
        WriteScore();
        //beeColor = beeModel.GetComponent<BeeColor>();
        titleScore.SetText("Pontuação");
        titleScore1.SetText("Pontuação");
        velSlider.value = 2;
        SetDiffDef();
        numberCluster = 7;
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
            if ( isPaused && setDef.isStart && !isEnd)
            {
                textScore.SetText("Pausa");
            }
        

        if (timer.targetTime <= 0)
        {
            isEnd = true;
            EndBees();
            titleScore.SetText("parabéns");
            titleScore1.SetText("parabéns");
        }
    }

    public void SetDiffDef()
    {
        switch (velSlider.value)
        {
            case 1:
                minDelay = 1f;
                maxDelay = 20f;
                vel = 3f;
                break;

            case 2:
                minDelay = 0.2f;
                maxDelay = 5.0f;
                vel = 5f;
                break;

            case 3:
                minDelay = 0.2f;
                maxDelay = 5.0f;
                vel = 6f;
                break;
        }
    }

    /*public void setSlideVel ()
    {
        vel = velSlider.value;
    }*/

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
        posy = Random.Range(0.6f ,2.5f);
        posz = 90;

        butterClus.transform.position = new Vector3 (posx, posy, posz);
        //bee.transform.rotation = Quaternion.Euler (0f , 180f , 0f);

        ParticleSystem bpart = butterClus.GetComponentInChildren<ParticleSystem>();
        bpart.Play();

        audioMan.GetAudioOfBee(butterClus);
        clusterCode.UndamageCluster();

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

                ButterflyCluster butterClus = obj.GetComponent<ButterflyCluster>();
                butterClus.UndamageCluster();

            }
            WriteScore();
        }
        obj.transform.position = pos;
    }



    public void RestartBees()
    {
        isEnd = false;
        foreach (GameObject cluster in buttersClu)
        {
            ButterflyCluster clusterCode = cluster.GetComponent<ButterflyCluster>();
            clusterCode.UndamageCluster();
        }

            StopAllCoroutines();

        for (int i = 0; i < buttersClu.Count; i++)
        {
            Destroy(buttersClu[i]);
            Destroy(audioMan.beeSource[i]);
        }

        audioMan.beeSource.Clear();
        buttersClu.Clear();

        //setSlideVel();
        SetDiffDef();
        score = 0;
        titleScore.SetText("Pontuação");
        titleScore1.SetText("Pontuação");
        WriteScore();

        isPaused = false;
        StartCoroutine(StartSpawnBees());
        setDef.ResetPauseBtn();

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
        setDef.ChangePauseSprite();
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
