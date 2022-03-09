using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawSkill : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    SkillUI currentSkillUI;
    SkillHoder currentHoder;
    SkillHoder targetHolder;
    private void Awake()
    {
        currentSkillUI = GetComponent<SkillUI>();
        currentHoder = GetComponentInParent<SkillHoder>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        InventoryManager.Instance.currentSkillDrag = new InventoryManager.DrawSkillData();
        InventoryManager.Instance.currentSkillDrag.originlHoder = GetComponentInParent<SkillHoder>();
        InventoryManager.Instance.currentSkillDrag.originalParent = (RectTransform)transform.parent;
        //记录原始数据

        transform.SetParent(InventoryManager.Instance.drawCanvs.transform, true);

        //开始拖动，关闭tootip
        InventoryManager.Instance.toolTip.gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentSkillUI.currentSkill.skillLevel <= 0)
        {
            return;
        }
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //放下物品，交换数据
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (InventoryManager.Instance.CheckActionSkillUI(eventData.position))
            {
                if (eventData.pointerEnter.gameObject.GetComponent<SlotHoder>())
                {
                    targetHolder = eventData.pointerEnter.gameObject.GetComponent<SkillHoder>();
                    Debug.Log(eventData.pointerEnter.gameObject);
                }
                else
                {
                    targetHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SkillHoder>();
                }
                //判断目标hoder是否为原来的hoder
                if (targetHolder != InventoryManager.Instance.currentSkillDrag.originlHoder)
                    switch (targetHolder.skillType)
                    {
                        case SlotSkillType.Player:
                            SwapSkill();
                            break;
                        case SlotSkillType.UI:
                            break;
                        default:

                            break;
                    }
                currentHoder.UpdateSkillUI();

                targetHolder.UpdateSkillUI();
                if (GameManager.Instance.playerCharterstate.continerSkillUI)
                {
                    GameManager.Instance.playerCharterstate.continerSkillUI.RefreshUI();
                }
            }

        }
        transform.SetParent(InventoryManager.Instance.currentSkillDrag.originalParent);
        InventoryManager.Instance.continerSkillUI.RefreshUI();
        InventoryManager.Instance.continerActionUI.RefreshUI();
        RectTransform t = transform as RectTransform;
        t.offsetMax = -Vector2.one * 5;
        t.offsetMin = Vector2.one * 5;
    }
    private bool IsSameSkill()
    {
        foreach (var item in PlayerSkillManager.Instance._skillDatas.skillDatas)
        {
            if (item == this.currentSkillUI.currentSkill)
            {
                return true;
            }
        }
        return false;
    }
    private void SwapSkill()
    {
        var targetSkill = targetHolder.skillUI.currentSkill;
        var tempSkill = currentHoder.skillUI.currentSkill;
        bool isSameSkill = targetSkill == tempSkill;
        if (isSameSkill)
        {

        }
        else
        {
            if (IsSameSkill())
            {

            }
            else
            {
                targetHolder.skillUI.currentSkill = tempSkill;
                PlayerSkillManager.Instance._skillDatas.skillDatas[targetHolder.index] = tempSkill;
            }
            
        }
        //var targetItem = targetHolder.itemUI.Bag.items[targetHolder.itemUI.Index];
        //var tempItem = currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index];
        //bool isSameItem = targetItem.ItemData == tempItem.ItemData;
        /*if (isSameItem && targetItem.ItemData.stackable)
        {
            targetItem.amount += tempItem.amount;
            tempItem.ItemData = null;
            tempItem.amount = 0;
        }
        else
        {
            currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index] = targetItem;
            targetHolder.itemUI.Bag.items[targetHolder.itemUI.Index] = tempItem;
        }*/
    }

}
