using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemData_SO ItemData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ItemData.itemType == ItemType.Coin)
            {
                //添加金币
                InventoryManager.Instance.inventoryData.coin.amount += ItemData.itemAmount;
            }
            else
            {
                InventoryManager.Instance.inventoryData.AddItem(ItemData, ItemData.itemAmount);
                InventoryManager.Instance.inventoryUI.RefreshUI();
                QuestManager.Instance.UpdateQuestProgress(ItemData.itemName, ItemData.itemAmount);
            }
            //将物品添加到背包
            
            //装备武器
            //GameManager.Instance.playerCharterstate.EquipWepon(ItemData);
            Destroy(gameObject);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider other)
    {
        
    }*/
}
