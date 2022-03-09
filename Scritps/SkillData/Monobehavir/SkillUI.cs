using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public Image icon = null;
    public Text desSkill;
    public SkillData_SO currentSkill;
    
    private void Awake()
    {
        icon = GetComponentInChildren<Image>();
    }
    public void SetUpdata(SkillData_SO skillData_SO)
    {
        if (currentSkill != null)
        {
            icon.sprite = currentSkill.icon;
        }
        if (icon.sprite == null)
        {
            icon.enabled = false;
        }
        else
        {
            icon.enabled = true;
            if (desSkill != null)
            {
                desSkill.text = currentSkill.SkillInfo;
            }
        }

        
    }
    public SkillData_SO GetItem()
{
        return currentSkill;
    }
}
