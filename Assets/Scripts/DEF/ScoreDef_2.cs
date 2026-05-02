
using UnityEngine;

public class ScoreDef_2 : MonoBehaviour
{
    private CapsuleCollider playerCol;

    private void Awake()
    {
        playerCol = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bee")
        {
            other.tag = "HitBee";
            Debug.Log("You have hit a bee :(");
        }
    }
}
