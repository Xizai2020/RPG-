using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDeadState : MonoBehaviour
{
    private CharacterStates characterStates;
    private List<CompositeCollider2D> collider2Ds;
    private LootSwaner lootSwaner;//物品掉落及控制
    public bool isDead;
    private void Awake()
    {
        isDead = false;
    }
    void Start()
    {
        lootSwaner = GetComponent<LootSwaner>();
        characterStates = GetComponent<CharacterStates>();
        
        foreach (var item in GetComponents<CompositeCollider2D>())
        {
            collider2Ds.Add(item);
        }
        foreach (var item in GetComponentsInChildren<CompositeCollider2D>())
        {
            collider2Ds.Add(item);
        }
        characterStates = GetComponent<CharacterStates>();    
    }

    void Update()
    {
        if (characterStates.CurrentHealth <= 0)
        {
            if (isDead == false)
            {
                Disenble();
            }
        }
    }
    private  void  Disenble()
    {
        lootSwaner.Spawnloot();
        Destroy(gameObject.transform.parent.gameObject, 0.1f);
        isDead = true;
        if (QuestManager.IsInitialized && isDead)
        {
            QuestManager.Instance.UpdateQuestProgress(this.name, 1);
        }
    }
}
