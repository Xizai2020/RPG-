using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(ItemUI))]
public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
    ItemUI currentItemUI;
    SlotHoder currentHolder;
    SlotHoder targetHolder;
    private void Awake()
    {
        currentItemUI = GetComponent<ItemUI>();
        currentHolder = GetComponentInParent<SlotHoder>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        InventoryManager.Instance.currentDrag = new InventoryManager.DrawData();
        InventoryManager.Instance.currentDrag.originlHoder = GetComponentInParent<SlotHoder>();
        InventoryManager.Instance.currentDrag.originalParent = (RectTransform)transform.parent;
        InventoryManager.Instance.toolTip.gameObject.SetActive(false);
        //记录原始数据

        transform.SetParent(InventoryManager.Instance.drawCanvs.transform, true);
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        
        //跟随鼠标位置移动
        transform.position = eventData.position;

    }
#if UNITY_EDITOR
    public void OnEndDrag(PointerEventData eventData)
    {
        if (Debugtext.Instance)
        {
            Debugtext.Instance.text.text ="<color=red>OnEndDrawg：</color>"+ eventData.ToString();
        }
        
        
        //放下物品，交换数据
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (Debugtext.Instance)
            {
                Debugtext.Instance.text.text = "<color=red>IsPointerOverGameObject()：</color>" + eventData.ToString();
            }
            if (InventoryManager.Instance.CheckInventoryUI(eventData.position) || InventoryManager.Instance.CheckActionUI(eventData.position) ||
                InventoryManager.Instance.CheckEqumentUI(eventData.position)||InventoryManager.Instance.CheckShopUI(eventData.position))
            {
                if (eventData.pointerEnter.gameObject.GetComponent<SlotHoder>())
                {
                    targetHolder = eventData.pointerEnter.gameObject.GetComponent<SlotHoder>();
                    Debug.Log(eventData.pointerEnter.gameObject);
                    if (Debugtext.Instance)
                    {
                       // Debugtext.Instance.text.text = "进入：" + eventData.pointerEnter.gameObject.ToString();
                    }
                }
                else
                {
                    targetHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SlotHoder>();
                }
                //判断目标hoder是否为原来的hoder
                if(targetHolder!=InventoryManager.Instance.currentDrag.originlHoder)
                switch (targetHolder.slotType)
                {
                    case SlotType.Bag:
                            if (currentHolder.slotType == SlotType.Shop&&InventoryManager.Instance.inventoryData.coin.amount>=
                                currentItemUI.currentItemData.buyCount)
                            {
                                InventoryManager.Instance.inventoryData.coin.amount -= currentItemUI.currentItemData.buyCount;
                                InventoryManager.Instance.inventoryData.AddItem(currentItemUI.currentItemData, currentItemUI.currentItemData.itemAmount);
                            }
                            else
                            {
                                SwapItem();
                            }
                            
                            break;
                    case SlotType.Wepon:
                        if (currentItemUI.Bag.items[currentItemUI.Index].ItemData.itemType == ItemType.Wepon)
                            {
                                SwapItem();
                            }    
                        break;
                    case SlotType.Armor:
                        if (currentItemUI.Bag.items[currentItemUI.Index].ItemData.itemType == ItemType.Armor)
                            SwapItem();
                        break;
                    case SlotType.Action:
                        if (currentItemUI.Bag.items[currentItemUI.Index].ItemData.itemType == ItemType.Useable)
                        {
                            SwapItem();
                        }
                        
                        break;
                    case SlotType.Shop:
                            if (currentHolder.slotType == SlotType.Bag)
                            {
                                //InventoryManager.Instance.inventoryData.coin.amount += targetHolder.itemUI.currentItemData.sellCount;
                                InventoryManager.Instance.inventoryData.coin.amount += (currentItemUI.currentItemData.sellCount*
                                    currentItemUI.currentItemData.itemAmount);
                                foreach (var item in InventoryManager.Instance.inventoryData.items)
                                {
                                    if (currentItemUI.currentItemData == item.ItemData)
                                    {
                                        InventoryManager.Instance.inventoryData.DisItem(currentItemUI.currentItemData, currentItemUI.currentItemData.itemAmount);
                                    }
                                }
                            }
                            
                            //SwapItem();
                            break;
                    default:
                            
                        break;
                }
                currentHolder.UpdaateItem();
                targetHolder.UpdaateItem();
            }

        }
        transform.SetParent(InventoryManager.Instance.currentDrag.originalParent);
        RectTransform t = transform as RectTransform;
        t.offsetMax = -Vector2.one * 5;
        t.offsetMin = Vector2.one * 5;
    }
#else
    public void OnEndDrag(PointerEventData eventData)
    {
        if (Debugtext.Instance)
        {
            Debugtext.Instance.text.text ="<color=red>OnEndDrawg：</color>"+ eventData.ToString();
        }
        
        
        //放下物品，交换数据
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            if (Debugtext.Instance)
            {
                Debugtext.Instance.text.text = "<color=red>IsPointerOverGameObject()：</color>" + eventData.ToString();
            }
            if (InventoryManager.Instance.CheckInventoryUI(eventData.position) || InventoryManager.Instance.CheckActionUI(eventData.position) ||
                InventoryManager.Instance.CheckEqumentUI(eventData.position)||InventoryManager.Instance.CheckShopUI(eventData.position))
            {
                if (eventData.pointerEnter.gameObject.GetComponent<SlotHoder>())
                {
                    targetHolder = eventData.pointerEnter.gameObject.GetComponent<SlotHoder>();
                    Debug.Log(eventData.pointerEnter.gameObject);
                    if (Debugtext.Instance)
                    {
                       // Debugtext.Instance.text.text = "进入：" + eventData.pointerEnter.gameObject.ToString();
                    }
                }
                else
                {
                    targetHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SlotHoder>();
                }
                //判断目标hoder是否为原来的hoder
                if(targetHolder!=InventoryManager.Instance.currentDrag.originlHoder)
                switch (targetHolder.slotType)
                {
                    case SlotType.Bag:
                            if (currentHolder.slotType == SlotType.Shop&&InventoryManager.Instance.inventoryData.coin.amount>=
                                currentItemUI.currentItemData.buyCount)
                            {
                                InventoryManager.Instance.inventoryData.coin.amount -= currentItemUI.currentItemData.buyCount;
                                InventoryManager.Instance.inventoryData.AddItem(currentItemUI.currentItemData, currentItemUI.currentItemData.itemAmount);
                            }
                            else
                            {
                                SwapItem();
                            }
                            
                            break;
                    case SlotType.Wepon:
                        if (currentItemUI.Bag.items[currentItemUI.Index].ItemData.itemType == ItemType.Wepon)
                            {
                                SwapItem();
                            }    
                        break;
                    case SlotType.Armor:
                        if (currentItemUI.Bag.items[currentItemUI.Index].ItemData.itemType == ItemType.Armor)
                            SwapItem();
                        break;
                    case SlotType.Action:
                        if (currentItemUI.Bag.items[currentItemUI.Index].ItemData.itemType == ItemType.Useable)
                        {
                            SwapItem();
                        }
                        
                        break;
                    case SlotType.Shop:
                            if (currentHolder.slotType == SlotType.Bag)
                            {
                                //InventoryManager.Instance.inventoryData.coin.amount += targetHolder.itemUI.currentItemData.sellCount;
                                InventoryManager.Instance.inventoryData.coin.amount += (currentItemUI.currentItemData.sellCount*
                                    currentItemUI.currentItemData.itemAmount);
                                foreach (var item in InventoryManager.Instance.inventoryData.items)
                                {
                                    if (currentItemUI.currentItemData == item.ItemData)
                                    {
                                        InventoryManager.Instance.inventoryData.DisItem(currentItemUI.currentItemData, currentItemUI.currentItemData.itemAmount);
                                    }
                                }
                            }
                            
                            //SwapItem();
                            break;
                    default:
                            
                        break;
                }
                currentHolder.UpdaateItem();
                targetHolder.UpdaateItem();
            }

        }
        transform.SetParent(InventoryManager.Instance.currentDrag.originalParent);
        RectTransform t = transform as RectTransform;
        t.offsetMax = -Vector2.one * 5;
        t.offsetMin = Vector2.one * 5;
    }

#endif


    private void SwapItem()
    {
        var targetItem = targetHolder.itemUI.Bag.items[targetHolder.itemUI.Index];
        var tempItem = currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index];
        bool isSameItem = targetItem.ItemData == tempItem.ItemData;
        if (isSameItem && targetItem.ItemData.stackable)
        {
            targetItem.amount += tempItem.amount;
            tempItem.ItemData = null;
            tempItem.amount = 0;
        }
        else
        {
            currentHolder.itemUI.Bag.items[currentHolder.itemUI.Index] = targetItem;
            targetHolder.itemUI.Bag.items[targetHolder.itemUI.Index] = tempItem;
        }
    }

    
}
