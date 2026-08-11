
using UnityEngine;

public class ScoreDef_2 : MonoBehaviour
{
    //[SerializeField] private BeeSpawn beeCode;
    [SerializeField] private ButterflySpawn butterflyCode;
    [SerializeField] private AudioManager audioM;
    [SerializeField] private BeeColor beeColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bee"))
        {
            other.tag = "HitBee";
            Debug.Log("You have hit a bee :(");

            int n = butterflyCode.buttersClu.IndexOf(other.gameObject);
            beeColor.DamageBee();
            audioM.HurtBee(n);
            
        }
    }
}
