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

    [SerializeField] private GameObject timerUI;
    [SerializeField] private GameObject scoreUI;

    private TextMeshProUGUI textScore;
    private Timer timer;
    bool isPaused;

    [SerializeField] public int score;

    private void Awake()
    {
        isPaused = true;
        timer = timerUI.GetComponent<Timer>();
        textScore = scoreUI.GetComponent<TextMeshProUGUI>();
        score = 0;
        WriteScore();
    }

    private void Update()
    {
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
            textScore.SetText("Conseguiste \n" + score + "pontos!");
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

        posx = Random.Range(4.0f , 12.0f);
        posy = Random.Range(0.0f ,1.5f);
        posz = 90;

        bee.transform.position = new Vector3 (posx, posy, posz);
        bee.transform.rotation = Quaternion.Euler (0f , 180f , 0f);

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
            pos.x = Random.Range(3.0f, 10.0f);
            pos.y = Random.Range(0.0f, 1.5f);

            vel += 0.05f;

            if (obj.tag == "Bee")
            {
                score += 100;
            } else if (obj.tag == "HitBee")
            {
                obj.tag = "Bee";
            }
            WriteScore();
        }
        obj.transform.position = pos;
    }

    public void RestartBees()
    {

        StopAllCoroutines();

        for (int i = 0; i < bees.Count; i++)
        {
            Destroy(bees[i]);
        }

        bees.Clear();
        score = 0;
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
        }

        bees.Clear();
    }

    public void WriteScore()
    {
        textScore.SetText("Pontuação: \n" + score);
    }
}
