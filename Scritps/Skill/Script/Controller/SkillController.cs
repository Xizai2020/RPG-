using UnityEngine;
using System.Collections;

public class SkillController : MonoBehaviour {
    public CenterController centercontroller;
    private Skill _curSkill; //当前使用的技能
    //public Transform haverTr;
	// Use this for initialization
	void Start () 
    {
       // haverTr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (_curSkill == null)
        {
            return;
        }

        _curSkill.Update();
	}

    //根据id使用技能
    public bool UseSkillById(int skillId)
    {
        _curSkill = SkillManager.Instance.CreateSkill(skillId);
        _curSkill.centerController = centercontroller;
        if (_curSkill == null)
        {
            return false;
        }
        if(!_curSkill._isExecute)
        {
           // _curSkill.haverTr = haverTr;
            _curSkill.Use();
        }
        
        return true;
    }
}
