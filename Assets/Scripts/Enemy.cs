using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject ball;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 startPos = new Vector3(-1, 1, 3);

        if (other.gameObject == enemy)
        {
            Debug.Log("hi");
            ball.transform.position = startPos;
        }
    }
}
