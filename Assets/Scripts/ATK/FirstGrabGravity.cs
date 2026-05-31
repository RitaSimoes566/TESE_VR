using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FirstGrabGravity : MonoBehaviour
{
    Rigidbody rb;
    XRGrabInteractable grab;
    public bool firstGrabDone = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();

        rb.useGravity = false;          // start with no gravity
        rb.isKinematic = true;
        grab.forceGravityOnDetach = true; // make sure gravity is on when dropped
    }

    void OnEnable()
    {
        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        grab.selectEntered.RemoveListener(OnGrab);
        grab.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        firstGrabDone = true;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        if (firstGrabDone)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}
