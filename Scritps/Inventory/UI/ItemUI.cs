using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image icon = null;
    public Text amount = null;
    public ItemData_SO currentItemData;
    public InventoryData_SO Bag { get; set; }
    [SerializeField]
    public int Index { get; set; } = -1;
    public int number;

    public void SetUpItemUI(ItemData_SO item,int itemAmount)
    {
        number = Index;
        if (itemAmount == 0)
        {
            Bag.items[Index].ItemData = null;
            icon.gameObject.SetActive(false);
            return;
        }
        if (itemAmount < 0)
        {
            item = null;
        }
        if (item != null)
        {
            /*
            if (itemAmount <= 0)
            {
                Bag.items[Index].ItemData = null;
            }*/
            
            {
                currentItemData = item;
                icon.sprite = item.itemIcon;
                amount.text = itemAmount.ToString("00");
                icon.gameObject.SetActive(true);
            }
            
        }
        else
        {
            icon.gameObject.SetActive(false);
        }
    }
    public ItemData_SO GetItem()
    {
        return Bag.items[Index].ItemData;
    }
}
