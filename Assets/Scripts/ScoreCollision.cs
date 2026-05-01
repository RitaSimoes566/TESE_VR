using UnityEngine;

public class ScoreCollision : MonoBehaviour
{
    [SerializeField] private GameObject bees; 
    void Awake()
    {
        Physics.IgnoreCollision(bees.GetComponent<Collider>(), GetComponent<Collider>());
    }

}
