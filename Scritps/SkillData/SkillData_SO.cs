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
    [Header("���ܵȼ�")]
    public int skillLevel;
    [Header("����")]
    public float conmsum;
    [Header("�˺�����")]
    public float damageMultiplier;
    [Header("�˺�����")]
    public int damageAttach;
    public string AwakeInfo()
    {
        string skillInfo = "�������ƣ�" + skillName + "\n" +
            "����������"+ Des.ToString() + "\n" +
            "���ܵȼ���" + skillLevel + "\n" +
            "��ȴʱ�䣺" + timeCD.ToString() + "��" + "\n" +
            "���ģ�" + conmsum.ToString() + "\n" +
            "�˺����ʣ�" + damageMultiplier.ToString() + "\n" +
            "�����˺���" + damageAttach.ToString();
        return skillInfo;
    }
    public void LevelUpSkill()
    {
        if (GameManager.Instance.playerCharterstate)
        {
            skillLevel++;
            GameManager.Instance.playerCharterstate.characterDate.currentSkilPoint--;
            //����Ч������

        }
        
    }
    public void ResetLevelSkill()
    {
        if (GameManager.Instance.playerCharterstate)
        {
            GameManager.Instance.playerCharterstate.characterDate.currentSkilPoint+=skillLevel;
            skillLevel =0;
            
            //����Ч������

        }
    }
    
}
