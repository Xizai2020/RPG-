using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SlotType { Bag,Wepon, SecondaryWeapon,Hat, Necklace,Ring,Clock,Glove,Shoes,Belt,Armor, Action,Shop}
public class SlotHoder : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public SlotHoder thisSlotHoder;
    public SlotType slotType; 
    public ItemUI itemUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        thisSlotHoder = this;
        InventoryManager.Instance.toolTip.currentSlot = thisSlotHoder;
        if (eventData.clickCount%2 == 1)
        {
            if (itemUI.GetItem())
            {
                InventoryManager.Instance.toolTip.SetupTooTip(itemUI.GetItem(),itemUI.GetItem().itemType);
                
                InventoryManager.Instance.toolTip.gameObject.SetActive(true);
                InventoryManager.Instance.toolTip.UpdatePosition(eventData);
            }
        }
        if (eventData.clickCount % 2 == 0)
        {
            UseItem();
            InventoryManager.Instance.toolTip.gameObject.SetActive(false);
        }
    }

    public void UseItem()
    {
        if (itemUI.GetItem() != null)
        {

            switch (itemUI.GetItem().itemType)
            {
                case ItemType.Useable:
                    if (itemUI.GetItem().itemType == ItemType.Useable && itemUI.Bag.items[itemUI.Index].amount > 0)
                    {
                        GameManager.Instance.playerCharterstate.ApplyHealth(itemUI.GetItem().useableData.healthPoint);
                        itemUI.Bag.items[itemUI.Index].amount -= 1;
                        QuestManager.Instance.UpdateQuestProgress(itemUI.GetItem().itemName, -1);
                    }
                    break;
                case ItemType.Coin:
                    break;
                case ItemType.Wepon:
                    UseItemEuiqNum(2);
                    break;
                case ItemType.Armor:
                    UseItemEuiqNum(7);
                    break;
                case ItemType.SecondaryWeapon:
                    UseItemEuiqNum(9);
                    break;
                case ItemType.Hat:
                    UseItemEuiqNum(0);
                    break;
                case ItemType.Necklace:
                    UseItemEuiqNum(8);
                    break;
                case ItemType.Ring:
                    UseItemEuiqNum(1);
                    break;
                case ItemType.Clock:
                    UseItemEuiqNum(6);
                    break;
                case ItemType.Glove:
                    UseItemEuiqNum(3);
                    break;
                case ItemType.Shoes:
                    UseItemEuiqNum(4);
                    break;
                case ItemType.Belt:
                    UseItemEuiqNum(5);
                    break;
                default:
                    break;
            }

        }
        InventoryManager.Instance.toolTip.gameObject.SetActive(false);
        UpdaateItem();
    }
    public void DisItem()
    {
        if (itemUI.Bag.items[itemUI.Index].amount > 0)
        {
            
            itemUI.Bag.items[itemUI.Index].amount -= 1;
            QuestManager.Instance.UpdateQuestProgress(itemUI.GetItem().itemName, -1);
            InventoryManager.Instance.toolTip.gameObject.SetActive(false);
            UpdaateItem();
        }
    }

    public void UpdaateItem()
    {
        switch (slotType)
        {
            case SlotType.Bag:
                itemUI.Bag = InventoryManager.Instance.inventoryData;
                break;
            case SlotType.Wepon:
                itemUI.Bag = InventoryManager.Instance.weponentData;
                //装备武器
                /*
                if (itemUI.Bag.items[itemUI.Index].ItemData != null)
                {
                    GameManager.Instance.playerCharterstate.ChanceWepon(itemUI.Bag.items[itemUI.Index].ItemData);
                }
                else
                {
                    GameManager.Instance.playerCharterstate.UnequipWeapon(itemUI.Bag.items[itemUI.Index].ItemData);
                }
                */
                break;
            case SlotType.Armor:
                itemUI.Bag = InventoryManager.Instance.weponentData;
                break;
            case SlotType.Belt:
                itemUI.Bag = InventoryManager.Instance.weponentData;
                break;
            case SlotType.Clock:
                itemUI.Bag = InventoryManager.Instance.weponentData;
                break;
            case SlotType.Glove:
                itemUI.Bag = InventoryManager.Instance.weponentData;
                break;
            case SlotType.Hat:
                itemUI.Bag = InventoryManager.Instance.weponentData;
                break;
            case SlotType.Necklace:
                itemUI.Bag = InventoryManager.Instance.weponentData;
                break;
            case SlotType.Ring:
                itemUI.Bag = InventoryManager.Instance.weponentData;
                break;
            case SlotType.SecondaryWeapon:
                itemUI.Bag = InventoryManager.Instance.weponentData;
                break;
            case SlotType.Shoes:
                itemUI.Bag = InventoryManager.Instance.weponentData;
                break; 
            case SlotType.Action:
                itemUI.Bag = InventoryManager.Instance.actionData;
                break;
            case SlotType.Shop:
                itemUI.Bag = InventoryManager.Instance.shop;
                break;
            default:
                break;
        }
        var item = itemUI.Bag.items[itemUI.Index];
        itemUI.SetUpItemUI(item.ItemData,item.amount) ;
    }


    private void UseItemEuiqNum(int num)//根据UI面板序号使用对应的物品
    {
        if (itemUI.GetItem().weponData.needLevel <= GameManager.Instance.playerCharterstate.characterDate.currentLevel)
        {
            if (InventoryManager.Instance.weponentData.items[num].ItemData != null)
            {
                ItemData_SO temp = itemUI.GetItem();
                itemUI.Bag.items[itemUI.Index].ItemData = InventoryManager.Instance.weponentData.items[num].ItemData;
                itemUI.Bag.items[itemUI.Index].amount = 1;
                InventoryManager.Instance.weponentData.items[num].ItemData = temp;
                InventoryManager.Instance.weponentData.items[num].amount = 1;
            }
            else
            {
                InventoryManager.Instance.weponentData.items[num].ItemData = itemUI.GetItem();
                InventoryManager.Instance.weponentData.items[num].amount = 1;
                itemUI.Bag.items[itemUI.Index].amount -= 1;
                QuestManager.Instance.UpdateQuestProgress(itemUI.GetItem().itemName, -1);
            }
        }
        
        InventoryManager.Instance.equipmentUI.RefreshUI();
        InventoryManager.Instance.shopInventoryUI.RefreshUI();
                
        if (InventoryManager.Instance.shop != null)
        {
            InventoryManager.Instance.ShopUI.RefreshUI();
        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        /*
        if (itemUI.GetItem())
        {
            InventoryManager.Instance.toolTip.SetupTooTip(itemUI.GetItem());
            InventoryManager.Instance.toolTip.gameObject.SetActive(true);
        }
        */
    }
    public void OnPointerExit(PointerEventData eventData)
    {
     /*   
        InventoryManager.Instance.toolTip.gameObject.SetActive(false);
        */
    }
    
    private void OnDisable()
    {
        InventoryManager.Instance.toolTip.gameObject.SetActive(false);
    }


}
