using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum SlotSkillType {Player,UI,SkillEquip} 
public class SkillHoder : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public SkillUI skillUI;
    public SkillHoder thisSkillHoder;
    public int index;
    public SlotSkillType skillType;

    public void OnPointerClick(PointerEventData eventData)
    {
        thisSkillHoder = this;
        InventoryManager.Instance.toolTip.currentSkillSlot = thisSkillHoder;
        if (eventData.clickCount % 2 == 1&&thisSkillHoder.skillType==SlotSkillType.UI)
        {
            if (skillUI.GetItem())
            {
                //InventoryManager.Instance.toolTip.SetupTooTip(skillUI.GetItem(), skillUI.GetItem().itemType);
                //FIX
                InventoryManager.Instance.toolTip.SetupSkillTip(skillUI.GetItem());
                InventoryManager.Instance.toolTip.gameObject.SetActive(true);
                InventoryManager.Instance.toolTip.UpdatePosition(eventData);
            }
        }
        if (eventData.clickCount % 2 == 0)
        {
            InventoryManager.Instance.toolTip.gameObject.SetActive(false);
        }
    }
    public void UseItem()
    {
        if (skillUI.GetItem() != null)
        {
            if (GameManager.Instance.playerCharterstate.characterDate.currentSkilPoint >= 1)
            {

                skillUI.GetItem().LevelUpSkill();
                
            }
            else
            {
                
            }
        }
        InventoryManager.Instance.toolTip.gameObject.SetActive(false);
    }
    public void DiseItem()
    {
        if (skillUI.GetItem() != null)
        {
            skillUI.GetItem().ResetLevelSkill();
        }
        InventoryManager.Instance.toolTip.gameObject.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void UpdateSkillUI()
    {
        //根据不同的技能数据Slot类型，更新各个背包显示
        switch (skillType)
        {
            case SlotSkillType.Player:
                for (int i = 0; i < PlayerSkillManager.Instance._skillDatas.skillDatas.Count; i++)
                {
                    if (i == index)
                    {
                        skillUI.currentSkill = PlayerSkillManager.Instance._skillDatas.skillDatas[i];
                        skillUI.SetUpdata(PlayerSkillManager.Instance._skillDatas.skillDatas[i]);
                    }
                }
                break;
            case SlotSkillType.UI:
                for (int i = 0; i < InventoryManager.Instance.invemtorySkillData.skillDatas.Count; i++)
                {
                    if (i == index)
                    {
                        skillUI.currentSkill = InventoryManager.Instance.invemtorySkillData.skillDatas[i];
                        skillUI.SetUpdata(InventoryManager.Instance.invemtorySkillData.skillDatas[i]);
                    }
                }
                break;
            default:
                break;
        }
        //skillUI.currentSkill=PlayerSkillManager.Instance._skillDatas.Add

    }

}
