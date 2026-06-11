using UnityEngine;

public class Ball : MonoBehaviour
{
    //[SerializeField] private GameObject obj;
    private Rigidbody rb;
    private FirstGrabGravity gra;
    public Vector3 CurrentSpawnPoint { get; private set; }

    [SerializeField] private Material mat;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gra = GetComponent<FirstGrabGravity>();
    
    }
    private void Start()
    {
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        gra.firstGrabDone = false;
        //obj.tag = "Ball";
    }

    public void SetCurrentSpawnPoint(Vector3 point)
    {
        CurrentSpawnPoint = point;
    }


    public void SpawnBall (Vector3 position)
    { 

        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        gra.firstGrabDone = false;

        transform.position = position;
       
    }
    
}
