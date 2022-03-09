using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Inventory",menuName ="Inventory/Inventory Data")]
public class InventoryData_SO : ScriptableObject
{
    public List<InventoryItem> items = new List<InventoryItem>();
    public Coin coin = new Coin();
    public void AddItem(ItemData_SO newItemData,int amount)
    {
        bool found=false;
        if (newItemData.stackable)
        {
            foreach (var  item in items)
            {
                if (item.ItemData == newItemData)
                {
                    item.amount += amount;
                    found = true;
                    break;
                }
            }
        }
        for (int i = 0; i <items.Count; i++)
        {
            if (items[i].ItemData == null && !found)
            {
                items[i].ItemData = newItemData;
                items[i].amount = amount;
                break;
            }
        }
    }
    public void DisItem(ItemData_SO newItemDate,int amount)
    {
        foreach (var item in items)
        {
            if (newItemDate == item.ItemData)
            {
                if (amount >= item.amount)
                {
                    item.amount -= amount;
                }
                else
                {
                    item.amount = 0;
                }
            }
        }
    }
    public bool IsFull()
    {
        bool isFull = true;
        foreach (var item in items)
        {
            if (item.ItemData == null)
            {
                isFull = false;
            }
        }
        return isFull;
    }
}

[System.Serializable]
public class InventoryItem
{
    public ItemData_SO ItemData;
    public int amount;
}

[System.Serializable]
public class Coin
{
    public int amount;
}
