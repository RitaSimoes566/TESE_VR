
using UnityEngine;

public class ScoreDef_2 : MonoBehaviour
{
    //[SerializeField] private BeeSpawn beeCode;
    [SerializeField] private ButterflySpawn butterflyCode;
    [SerializeField] private AudioManager audioM;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bee"))
        {
            other.tag = "HitBee";
            Debug.Log("You have hit a bee :(");

            ButterflyCluster butterClus = other.GetComponent<ButterflyCluster>();
            butterClus.DamageCluster();

            int n = butterflyCode.buttersClu.IndexOf(other.gameObject);
            audioM.HurtBee(n);
            
        }
    }
}
