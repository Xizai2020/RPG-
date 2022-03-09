using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemTooTip : MonoBehaviour
{
    public Text itemNameText;
    public Text itemInfoText;
    public SlotHoder currentSlot;//物品slot
    public SkillHoder currentSkillSlot;
    public Button buttonUse;
    public Button buttonDis;
    private RectTransform rectTransform;
    private ItemData_SO currentItem;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        buttonUse.onClick.AddListener(UseItem);
        buttonDis.onClick.AddListener(DisItem);
    }

    private void DisItem()
    {
        if (currentSlot != null)
        {
            switch (currentSlot.slotType)
            {
                case SlotType.Bag:
                    currentSlot.DisItem();
                    break;
                case SlotType.Wepon:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.SecondaryWeapon:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.Hat:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.Necklace:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.Ring:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.Clock:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.Glove:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.Shoes:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.Belt:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.Armor:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.Action:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                case SlotType.Shop:
                    InventoryManager.Instance.toolTip.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }

        if (currentSkillSlot != null)
        {
            switch (currentSkillSlot.skillType)
            {
                case SlotSkillType.Player:
                    break;
                case SlotSkillType.UI:
                    //使用/学习技能
                    currentSkillSlot.DiseItem();
                    break;
                case SlotSkillType.SkillEquip:
                    break;
                default:
                    break;
            }
        }
        
        InventoryManager.Instance.inventoryUI.RefreshUI();
        InventoryManager.Instance.continerSkillUI.RefreshUI();
    }

    private void UseItem()
    {
        if (currentSlot != null)
        {
            switch (currentSlot.slotType)
            {
                case SlotType.Bag:
                    currentSlot.UseItem();
                    break;
                case SlotType.Wepon:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);
                        currentSlot.DisItem();
                    }
                    break;
                case SlotType.SecondaryWeapon:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);
                        currentSlot.DisItem();
                    }
                    break;
                case SlotType.Hat:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);
                        currentSlot.DisItem();
                    }
                    break;
                case SlotType.Necklace:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);
                        currentSlot.DisItem();
                    }
                    break;
                case SlotType.Ring:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);
                        currentSlot.DisItem();
                    }
                    break;
                case SlotType.Clock:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);
                        currentSlot.DisItem();
                    }
                    break;
                case SlotType.Glove:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);
                        currentSlot.DisItem();
                    }
                    break;
                case SlotType.Shoes:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);
                        currentSlot.DisItem();
                    }
                    break;
                case SlotType.Belt:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);
                        currentSlot.DisItem();
                    }
                    break;
                case SlotType.Armor:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);
                        currentSlot.DisItem();
                    }
                    break;
                case SlotType.Action:
                    break;
                case SlotType.Shop:
                    if (InventoryManager.Instance.inventoryData.IsFull())
                    {
                        //如果背包满，什么都不做
                    }
                    else
                    {
                        //购物调用
                        if (InventoryManager.Instance.inventoryData.coin.amount >=
                                    currentItem.buyCount)
                        {
                            InventoryManager.Instance.inventoryData.coin.amount -= currentItem.buyCount;
                            InventoryManager.Instance.inventoryData.AddItem(currentSlot.itemUI.GetItem(), 1);

                        }

                    }

                    break;
                default:
                    break;
            }
        }
        if (currentSkillSlot != null)
        {
            switch (currentSkillSlot.skillType)
            {
                case SlotSkillType.Player:
                    break;
                case SlotSkillType.UI:
                    //使用/学习技能
                    currentSkillSlot.UseItem();
                    break;
                case SlotSkillType.SkillEquip:
                    break;
                default:
                    break;
            }
        }
        
        InventoryManager.Instance.inventoryUI.RefreshUI();
        InventoryManager.Instance.continerSkillUI.RefreshUI();
    }

    private void Start()
    {


    }
    public void SetupSkillTip(SkillData_SO skillData_SO)//更新技能文本说明
    {
        switch (currentSkillSlot.skillType)
        {
            case SlotSkillType.Player:
                break;
            case SlotSkillType.UI:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "学习";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "遗忘";
                break;
            case SlotSkillType.SkillEquip:
                break;
            default:
                break;
        }
        itemNameText.text = skillData_SO.skillName;
        itemInfoText.text = skillData_SO.AwakeInfo();
    }
    public void SetupTooTip(ItemData_SO itemData,ItemType itemTypes)//更新物品文本说明
    {
        switch (currentSlot.slotType)
        {
            case SlotType.Bag:
                switch (itemTypes)
                {
                    case ItemType.Useable:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "使用";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    case ItemType.Coin:
                        break;
                    case ItemType.Wepon:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "装备";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    case ItemType.Armor:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "装备";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    case ItemType.SecondaryWeapon:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "装备";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    case ItemType.Hat:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "装备";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    case ItemType.Necklace:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "装备";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    case ItemType.Ring:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "装备";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    case ItemType.Clock:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "装备";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    case ItemType.Glove:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "装备";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    case ItemType.Shoes:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "装备";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    case ItemType.Belt:
                        buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "装备";
                        buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "丢弃";
                        break;
                    default:
                        break;
                }
                break;
            case SlotType.Wepon:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "卸载";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            case SlotType.SecondaryWeapon:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "卸载";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            case SlotType.Hat:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "卸载";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            case SlotType.Necklace:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "卸载";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            case SlotType.Ring:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "卸载";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            case SlotType.Clock:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "卸载";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            case SlotType.Glove:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "卸载";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            case SlotType.Shoes:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "卸载";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            case SlotType.Belt:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "卸载";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            case SlotType.Armor:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "卸载";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            case SlotType.Action:
                break;
            case SlotType.Shop:
                buttonUse.gameObject.transform.GetComponentInChildren<Text>().text = "购买";
                buttonDis.gameObject.transform.GetComponentInChildren<Text>().text = "---";
                break;
            default:
                break;
        }

        currentItem = itemData;
        itemNameText.text = itemData.itemName;
        itemInfoText.text = itemData.description;


    }
    private void OnEnable()
    {

    }
    private void Update()
    { 
    }

    public void UpdatePosition(PointerEventData eventData)
    {
        //Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos = eventData.position;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        float width = corners[3].x - corners[0].x;
        float height = corners[1].y - corners[0].y;
        if (mousePos.y < height)
        {
            rectTransform.position = mousePos + Vector3.up * height * 0.6f;
        }
        else if(Screen.width-mousePos.x>width)
        {
            rectTransform.position = mousePos + Vector3.right * width * 0.6f;
        }
        else
        {
            rectTransform.position = mousePos + Vector3.left * width * 0.6f;
        }
        

    }
}
