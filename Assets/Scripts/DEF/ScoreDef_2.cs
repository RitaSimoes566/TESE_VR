
using UnityEngine;

public class ScoreDef_2 : MonoBehaviour
{
    private CapsuleCollider playerCol;
    [SerializeField] private BeeSpawn beeCode;
    [SerializeField] private AudioManager audioM;

    private void Awake()
    {
        playerCol = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bee"))
        {
            other.tag = "HitBee";
            Debug.Log("You have hit a bee :(");

            int n = beeCode.bees.IndexOf(other.gameObject);
            audioM.HurtBee(n);
        }
    }
}
