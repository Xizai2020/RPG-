using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : Singleton<InventoryManager>
{
    [System.Serializable]
    public class DrawData
    {
        public SlotHoder originlHoder;
        public RectTransform originalParent;
    }
    [System.Serializable]
    public class DrawSkillData
    {
        public SkillHoder originlHoder;
        public RectTransform originalParent;
    }
    //最后添加模板用来保存数据
    [Header("Inventory Data")]
    public InventoryData_SO inventoryTemplate;
    public InventoryData_SO inventoryData;
    public InventoryData_SO actionTemplate;
    public InventoryData_SO actionData;
    public InventoryData_SO weponTemplate;
    public InventoryData_SO weponentData;

    [Header("Shop")]
    public InventoryData_SO shop;
    [Header("SkillData")]
    public InvemtorySkillData invemtorySkillData;
    public InvemtorySkillData tempinvemtorySkillData;
    
    [Header("ContanierS")]
    public ContinerUI inventoryUI;
    public ContinerUI shopInventoryUI;//商店交易背包
    public ContinerUI actionUI;
    public ContinerUI equipmentUI;
    public ContinerSkillUI continerSkillUI;
    public ContinerSkillUI continerActionUI;
    //商店背包
    public ContinerUI ShopUI;
    [Header("DrawCanvs")]
    public Canvas drawCanvs;
    public DrawData currentDrag;
    public DrawSkillData currentSkillDrag;
    [Header("UI Panel")]
    public GameObject bagPanel;
    public GameObject statePanel;
    public GameObject ShopPanel;
    //private bool isOpen = false;
    [Header("TooTip")]
    public ItemTooTip toolTip;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        if (inventoryTemplate != null)
        {
            inventoryData = Instantiate(inventoryTemplate);
        }
        if (actionTemplate != null)
        {
            actionData = Instantiate(actionTemplate);
        }
        if (weponTemplate != null)
        {
            weponentData = Instantiate(weponTemplate);
        }
        if (tempinvemtorySkillData != null&&invemtorySkillData==null)
        {
            invemtorySkillData = Instantiate(tempinvemtorySkillData);
        }
        
    }
    private void Start()
    {
        LoadData();
        
        inventoryUI.RefreshUI();
        actionUI.RefreshUI();
        equipmentUI.RefreshUI();
        continerSkillUI.RefreshUI();
        continerActionUI.RefreshUI();

        shopInventoryUI.RefreshUI();
        if (shop != null)
        {
            ShopUI.RefreshUI();
        }
    }

    public void SaveData()
    {
        SaveManager.Instance.Save(inventoryData, inventoryData.name);
        SaveManager.Instance.Save(actionData, actionData.name);
        SaveManager.Instance.Save(weponentData, weponentData.name);
        SaveManager.Instance.Save(invemtorySkillData, invemtorySkillData.name);
    }
    public void LoadData()
    {
        SaveManager.Instance.Load(inventoryData, inventoryData.name);
        SaveManager.Instance.Load(actionData, actionData.name);
        SaveManager.Instance.Load(weponentData, weponentData.name);
        SaveManager.Instance.Load(invemtorySkillData, invemtorySkillData.name);


    }
    #region 检查物品是否在格子内

    public bool CheckInventoryUI(Vector3 position)
    {
        for (int i = 0; i < inventoryUI.slotHoders.Length; i++)
        {
            RectTransform t = inventoryUI.slotHoders[i].transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckActionUI(Vector3 position)
    {
        for (int i = 0; i < actionUI.slotHoders.Length; i++)
        {
            RectTransform t = actionUI.slotHoders[i].transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckEqumentUI(Vector3 position)
    {
        for (int i = 0; i < equipmentUI.slotHoders.Length; i++)
        {
            RectTransform t = equipmentUI.slotHoders[i].transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckShopUI(Vector3 position)
    {
        for (int i = 0; i < ShopUI.slotHoders.Length; i++)
        {
            RectTransform t = ShopUI.slotHoders[i].transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckSkillUI(Vector3 position)
    {
        for (int i = 0; i < continerSkillUI.skillHoders.Length; i++)
        {
            RectTransform t = continerSkillUI.skillHoders[i].transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckActionSkillUI(Vector3 position)
    {
        for (int i = 0; i < continerActionUI.skillHoders.Length; i++)
        {
            RectTransform t = continerActionUI.skillHoders[i].transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
            {
                return true;
            }
        }
        return false;
    }
    #endregion
    #region 检测任务物品
    public void CheckQuestItemInBag(string questName)
    {
        foreach (var item in inventoryData.items)
        {
            if (item.ItemData != null)
            {
                if (item.ItemData.itemName == questName)
                {
                    QuestManager.Instance.UpdateQuestProgress(item.ItemData.itemName, item.amount);
                }
            }
        }
        foreach (var item in actionData.items)
        {
            if (item.ItemData != null)
            {
                if (item.ItemData.itemName == questName)
                {
                    QuestManager.Instance.UpdateQuestProgress(item.ItemData.itemName, item.amount);
                }
            }
        }
    }
    #endregion
    public InventoryItem QuestItemInBag(ItemData_SO questItem)
    {
        return inventoryData.items.Find(i => i.ItemData == questItem);
    }
    public InventoryItem QuestItemInAction(ItemData_SO questItem)
    {
        return actionData.items.Find(i => i.ItemData == questItem);
    }

}
