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
        grab.forceGravityOnDetach = true; // make sure gravity is on when dropped
    }

    void OnEnable()
    {
        grab.selectEntered.AddListener(OnGrab);
    }

    void OnDisable()
    {
        grab.selectEntered.RemoveListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        firstGrabDone = true;
        rb.useGravity = true;           // from now on, gravity stays enabled
    }
}
