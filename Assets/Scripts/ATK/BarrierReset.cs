using UnityEngine;

public class BarrierReset : MonoBehaviour
{
    [SerializeField] private BallManager ballManager;
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            ballManager.ResetPosition(ball);

        }
    }
}
