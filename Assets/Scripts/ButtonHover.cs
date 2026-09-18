using UnityEngine;
using UnityEngine.EventSystems;


public class UIHoverPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject panel;


    private void Awake()
    {
        panel.SetActive(false);
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"[UIHoverPanel] Enter on {gameObject.name}", this);
        panel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log($"[UIHoverPanel] Exit on {gameObject.name}", this);
        panel.SetActive(false);
    }
}