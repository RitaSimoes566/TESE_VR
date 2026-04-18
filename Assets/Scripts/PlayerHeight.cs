using UnityEngine;
using Unity.XR.CoreUtils;

[RequireComponent(typeof(CharacterController))]
public class PlayerHeight : MonoBehaviour
{
    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private float minHeight = 1.0f;
    [SerializeField] private float maxHeight = 2.5f;

    private CharacterController control;

    void Awake()
    {

        control = GetComponent<CharacterController>();
        if (xrOrigin == null) return;

    }

    void Update()
    {

        float height = Mathf.Clamp(xrOrigin.CameraYOffset, minHeight, maxHeight);

        control.height = height;
        control.center = new Vector3(0f, height/ 2f, 0f);

    }
}