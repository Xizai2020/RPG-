using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUpdata : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (InventoryManager.Instance.inventoryData)
        {
            text.text = InventoryManager.Instance.inventoryData.coin.amount.ToString();
        }
        
    }
}
