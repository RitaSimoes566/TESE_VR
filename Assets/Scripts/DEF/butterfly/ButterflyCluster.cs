using UnityEngine;
using System.Collections.Generic;

public class ButterflyCluster : MonoBehaviour
{
    //public float butterVel;
    public GameObject butterModel;
    //public AudioSource butterSound;

    //public float pX, pY, pZ;
    public float radiusCluster = 15;
    public int butterNumber = 10;
    //public ParticleSystem butterParticle;
    public List<GameObject> butters = new List<GameObject>();
    [SerializeField] private float butterScale = 0.1f;

    /*private void Awake()
    {
        SpawnCluster();
    }*/

    public void SpawnCluster()
    {
        for (int i = 0; i < butterNumber; i++)
        {
            // place butterflies inside vluster

            float posx, posy, posz;
            GameObject butterfly = Instantiate(butterModel , transform);

            posx = Random.Range (transform.position.x - radiusCluster,
                transform.position.x + radiusCluster);
            posy = Random.Range(transform.position.y - radiusCluster,
                transform.position.y + radiusCluster);
            posz = Random.Range(transform.position.z - radiusCluster,
                transform.position.z + radiusCluster);

            butterfly.transform.position = new Vector3(posx, posy, posz);
            butterfly.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            butterfly.transform.localScale = new Vector3 (butterScale, butterScale, butterScale);

            //random delay in animations
            // by starting at different times
            Animator butterAnim = butterfly.GetComponent<Animator>();
            butterAnim.Play(0, 0, Random.Range(0f, 1f));

            butters.Add(butterfly);
        }

        //ParticleSystem bpart = bee.GetComponentInChildren<ParticleSystem>();

    }

}
