using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSkillButton : MonoBehaviour
{
    //¼¼ÄÜ°´¼üÀäÈ´

    public TestSkill testSkill;
    public float CDspeed;
    private Image image;
    private Button button;
    private float amount;
    public  SkillData_SO skill;
    private void Awake()
    {
        button = GetComponent<Button>();
        testSkill = GetComponentInParent<TestSkill>();
        skill = GetComponentInChildren<SkillUI>().currentSkill;
        image = GetComponent<Image>();
    }
    private void Start()
    {
        testSkill.skillactionEvent += UpdateActionButton;
    }

    private void UpdateActionButton(int arg1, SkillData_SO arg2)
    {
        if (arg1 == GetComponent<SkillHoder>().index)
        {
            image.fillAmount = 0;
            amount = 0;
            skill = arg2;
        }
    }

    private void Update()
    {
        if (image.fillAmount < 1)
        {
            amount += Time.deltaTime / skill.timeCD;
            image.fillAmount = Mathf.Min(amount, 1);
            button.enabled = false;
            
        }
        if (image.fillAmount == 1)
        {
            button.enabled = true;
        }
        
        
    }
}
