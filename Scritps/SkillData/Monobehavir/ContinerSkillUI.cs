using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinerSkillUI : MonoBehaviour
{
    public SkillHoder[] skillHoders;
    private void Start()
    {
        RefreshUI();
    }
    public void RefreshUI()
    {
        for (int i = 0; i < skillHoders.Length; i++)
        {
            skillHoders[i].index = i;
            skillHoders[i].UpdateSkillUI();
        }
    }
}
