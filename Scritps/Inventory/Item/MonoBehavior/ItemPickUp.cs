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
                //��ӽ��
                InventoryManager.Instance.inventoryData.coin.amount += ItemData.itemAmount;
            }
            else
            {
                InventoryManager.Instance.inventoryData.AddItem(ItemData, ItemData.itemAmount);
                InventoryManager.Instance.inventoryUI.RefreshUI();
                QuestManager.Instance.UpdateQuestProgress(ItemData.itemName, ItemData.itemAmount);
            }
            //����Ʒ��ӵ�����
            
            //װ������
            //GameManager.Instance.playerCharterstate.EquipWepon(ItemData);
            Destroy(gameObject);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider other)
    {
        
    }*/
}
