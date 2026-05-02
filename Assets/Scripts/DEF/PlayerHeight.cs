using UnityEngine;
using Unity.XR.CoreUtils;

public class PlayerHeight : MonoBehaviour
{
    [SerializeField] private GameObject camOff;
    [SerializeField] private GameObject camMain;


    float hOffset;
    public CapsuleCollider playerDef;


    void Awake()
    {
        playerDef = GetComponent<CapsuleCollider>();
        hOffset = camOff.transform.position.y;

    }

    void Update()
    {
        hOffset = camMain.transform.position.y;
        playerDef.height = hOffset;
        playerDef.center = new Vector3(0, -(hOffset / 2), 0);
    }
}