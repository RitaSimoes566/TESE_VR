using UnityEngine;
using System.Collections.Generic;

public class ButterflyCluster : MonoBehaviour
{
    public GameObject butterModel;
    //public AudioSource butterSound;

    public float radiusCluster = 15;
    public int butterNumber = 10;
    public List<GameObject> butters = new List<GameObject>();
    [SerializeField] private float butterScale;
    public BeeColor butterColor;
    private bool clusterRed;
    

    private void Awake()
    {
        clusterRed = false;
        butterScale = 0.04f;
    }

    public void SpawnCluster()
    {
        Vector3 parentWorldScale = transform.lossyScale; // cluster's world scale

        for (int i = 0; i < butterNumber; i++)
        {
            // place butterflies inside cluster
            float posx, posy, posz;
            GameObject butterfly = Instantiate(butterModel, Vector3.zero, Quaternion.identity);
            butterfly.transform.localScale = new Vector3(butterScale, butterScale, butterScale);
            butterfly.transform.SetParent(transform);

            butterfly.transform.rotation = Quaternion.Euler(0f, -90f, -40f);

            posx = Random.Range (transform.position.x - radiusCluster,
                transform.position.x + radiusCluster);
            posy = Random.Range(transform.position.y - radiusCluster,
                transform.position.y + radiusCluster);
            posz = Random.Range(transform.position.z - radiusCluster,
                transform.position.z + radiusCluster);

            butterfly.transform.position = new Vector3(posx, posy, posz);

            Vector3 desiredWorldScale = new Vector3(butterScale, butterScale, butterScale);
            butterfly.transform.localScale = new Vector3(
                desiredWorldScale.x / parentWorldScale.x,
                desiredWorldScale.y / parentWorldScale.y,
                desiredWorldScale.z / parentWorldScale.z);
    


            //random delay in animations
            // by starting at different times
                Animator butterAnim = butterfly.GetComponent<Animator>();
            butterAnim.Play(0, 0, Random.Range(0f, 1f));

            butters.Add(butterfly);
        }

    }

    public void DamageCluster()
    {
        foreach (GameObject butterfly in butters)
        {
            BeeColor butterColor = butterfly.GetComponent<BeeColor>();
            butterColor.DamageBee();
        }
    }

    public void UndamageCluster()
    {
        foreach (GameObject butterfly in butters)
        {
            BeeColor butterColor = butterfly.GetComponent<BeeColor>();
            butterColor.UndamageBee();
        }
    }


    public void ChangeCluster()
    {
        // Call the appropriate function then flip state
        if (clusterRed)
        {
            UndamageCluster();
            clusterRed = false;
        }
        else
        {
            DamageCluster();
            clusterRed = true;
        }
    }
}
