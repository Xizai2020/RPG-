using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ItemUI currentItemUI;
    private void Awake()
    {
        currentItemUI = GetComponent<ItemUI>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        QuestUI.Instance.tooTip.gameObject.SetActive(true);
        QuestUI.Instance.tooTip.SetupTooTip(currentItemUI.currentItemData,ItemType.Wepon);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        QuestUI.Instance.tooTip.gameObject.SetActive(false);
    }

 
}
