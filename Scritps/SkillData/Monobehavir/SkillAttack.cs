using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    public CenterController centerController;
    public SkillController skillController;
    public StatusController statusController;
    public Animator animator; //¶¯»­
                               // Use this for initialization
    void Start()
    {
        centerController = gameObject.AddComponent<CenterController>();
        skillController = gameObject.AddComponent<SkillController>();
        statusController = gameObject.AddComponent<StatusController>();
        centerController.skillController = skillController;
        centerController.statusController = statusController;
        animator = gameObject.GetComponent<Animator>();
        centerController.animator = animator;
        statusController.centerController = centerController;
        skillController.centercontroller = centerController;
    }

}
