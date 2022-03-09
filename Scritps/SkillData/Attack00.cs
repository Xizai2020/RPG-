using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack00 : MonoBehaviour
{
    public string targetTag;
    public bool isMagic;
    public CharacterStates currentCharacter;
    public int skillID;
    public SkillData_SO skillData;
    private void Awake()
    {
        
    }
    void Start()
    {
        currentCharacter = GetComponentInParent<CharacterStates>();
        if (transform.parent.gameObject.CompareTag("Player"))
        {
            skillData = PlayerSkillManager.Instance.FindSkillData(skillID);
            targetTag = "Enemy";
        }
        if (transform.parent.gameObject.CompareTag("Enemy"))
        {
            skillData = EnemySkillManager.Instance.FindSkillData(skillID);//挂载Enemy上的技能管理器
            targetTag = "Player";
        }
            
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            int coreDamage =(int)(Random.Range(currentCharacter.attackData.maxAttack, currentCharacter.attackData.minAttack) * skillData.damageMultiplier)+skillData.damageAttach;
            collision.GetComponent<CharacterStates>().TakeDamage(currentCharacter, collision.GetComponent<CharacterStates>(),isMagic);
            
        }
        
    }
}
