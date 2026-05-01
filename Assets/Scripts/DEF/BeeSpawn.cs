using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BeeSpawn : MonoBehaviour
{
    [SerializeField] int numberBees = 5;
    [SerializeField] float vel = 7f;

    [SerializeField] float minDelay = 0.2f;
    [SerializeField] float maxDelay = 1.0f;

    public GameObject beeModel;
    private List<GameObject> bees = new List<GameObject>();

    private void Awake()
    {
        StartCoroutine(StartSpawnBees());
    }

    private void Update()
    {
        for (int i = 0; i < bees.Count; i++)
        {
            MoveBee(bees[i]);
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

        posx = Random.Range(3.0f , 10.0f);
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
        }
        obj.transform.position = pos;
    }
}
