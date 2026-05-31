using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    private Rigidbody rb;
    private FirstGrabGravity gra;

    [SerializeField] private Material mat;

    private void Awake()
    {
        rb = obj.GetComponent<Rigidbody>();
        gra = obj.GetComponent<FirstGrabGravity>();
    
    }
    private void Start()
    {
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        gra.firstGrabDone = false;
        obj.tag = "Ball";
    }

    public void SpawnBall (float px, float pz)
    { 

        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        gra.firstGrabDone = false;

        obj.transform.position = new Vector3(px, 0.5f, pz);
       
    }
    
}
