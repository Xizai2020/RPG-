using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Date", menuName = "Skill States/Date")]
public class SkillData_SO : ScriptableObject
{
    public int skillID;
    public string skillName;
    [TextArea]
    public string Des;
    [HideInInspector]
    public string SkillInfo
    {
        get { return AwakeInfo(); }
    }
    public Sprite icon;
    public float timeCD;
    [Header("技能等级")]
    public int skillLevel;
    [Header("消耗")]
    public float conmsum;
    [Header("伤害倍率")]
    public float damageMultiplier;
    [Header("伤害附加")]
    public int damageAttach;
    public string AwakeInfo()
    {
        string skillInfo = "技能名称：" + skillName + "\n" +
            "技能描述："+ Des.ToString() + "\n" +
            "技能等级：" + skillLevel + "\n" +
            "冷却时间：" + timeCD.ToString() + "秒" + "\n" +
            "消耗：" + conmsum.ToString() + "\n" +
            "伤害倍率：" + damageMultiplier.ToString() + "\n" +
            "附加伤害：" + damageAttach.ToString();
        return skillInfo;
    }
    public void LevelUpSkill()
    {
        if (GameManager.Instance.playerCharterstate)
        {
            skillLevel++;
            GameManager.Instance.playerCharterstate.characterDate.currentSkilPoint--;
            //升级效果待定

        }
        
    }
    public void ResetLevelSkill()
    {
        if (GameManager.Instance.playerCharterstate)
        {
            GameManager.Instance.playerCharterstate.characterDate.currentSkilPoint+=skillLevel;
            skillLevel =0;
            
            //遗忘效果待定

        }
    }
    
}
