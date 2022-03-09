using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : Singleton<PlayerSkillManager>
{
    public InvemtorySkillData _skillDatas;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

    }

    public SkillData_SO FindSkillData(int skillID)
    {
        foreach (var item in _skillDatas.skillDatas)
        {
            if (item.skillID == skillID)
            {
                return item;
            }
        }
        return null;

    }
    

}
