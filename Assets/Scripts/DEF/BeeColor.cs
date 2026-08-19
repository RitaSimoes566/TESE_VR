using System.Collections;
using UnityEngine;

public class BeeColor : MonoBehaviour
{
    [SerializeField] private bool isRed;
    public SkinnedMeshRenderer rend;

    // Change this if your shader uses a different property (e.g. "_BaseColor")
    [SerializeField] private string colorPropertyName = "_BaseColor";
    int colorId;

    public Color hitColor = Color.red;
    [Range(0f, 1f)] public float hitStrength = 0.85f;

    MaterialPropertyBlock block;
    Color[] originalColors;

    void Awake()
    {
        colorId = Shader.PropertyToID(colorPropertyName);
        if (rend == null) rend = GetComponentInChildren<SkinnedMeshRenderer>();
        if (rend == null)
        {
            Debug.LogError("BeeColor: No SkinnedMeshRenderer found.", this);
            return;
        }

        var mats = rend.sharedMaterials;
        originalColors = new Color[mats.Length];

        for (int i = 0; i < mats.Length; i++)
        {
            if (mats[i] != null && mats[i].HasProperty(colorId))
                originalColors[i] = mats[i].GetColor(colorId);
            else
                originalColors[i] = Color.white;
        }

        block = new MaterialPropertyBlock();
        isRed = false;
    }

    public void DamageBee()
    {
        if (rend == null) return;
        for (int i = 0; i < originalColors.Length; i++)
        {
            rend.GetPropertyBlock(block, i);
            if (rend.sharedMaterials[i] != null && rend.sharedMaterials[i].HasProperty(colorId))
            {
                Color target = Color.Lerp(originalColors[i], hitColor, Mathf.Clamp01(hitStrength));
                block.SetColor(colorId, target);
                rend.SetPropertyBlock(block, i);
            }
        }
    }

    public void UndamageBee()
    {
        if (rend == null) return;
        for (int i = 0; i < originalColors.Length; i++)
        {
            rend.GetPropertyBlock(block, i);
            if (rend.sharedMaterials[i] != null && rend.sharedMaterials[i].HasProperty(colorId))
            {
                block.SetColor(colorId, originalColors[i]);
                rend.SetPropertyBlock(block, i);
            }
        }
    }

    public void ChangeBee()
    {
        // Call the appropriate function then flip state
        if (isRed)
        {
            UndamageBee();
            isRed = false;
        }
        else
        {
            DamageBee();
            isRed = true;
        }
    }
}