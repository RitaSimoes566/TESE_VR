using UnityEngine;

public class ScoreCollision : MonoBehaviour
{
    private Collider[] beesColl;

    void Awake()
    {
        GameObject[] bees = GameObject.FindGameObjectsWithTag("Bee");
        beesColl = new Collider[bees.Length];

        for (int i = 0; i < bees.Length; ++i)
        {
            Physics.IgnoreCollision(beesColl[i], GetComponent<Collider>());
        }
    }

}
