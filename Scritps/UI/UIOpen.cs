using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIOpen : MonoBehaviour
{
    private Button button;
    public bool isOpen;
    public GameObject UI;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    void Start()
    {
        isOpen = false;
        button.onClick.AddListener(OpenUI);
    }

    private void OpenUI()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            InventoryManager.Instance.inventoryUI.RefreshUI();
            InventoryManager.Instance.shopInventoryUI.RefreshUI();
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            isOpen = !isOpen;
        UI.gameObject.SetActive(isOpen);
    }
}
