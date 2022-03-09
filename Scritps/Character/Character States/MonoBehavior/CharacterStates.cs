using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStates : MonoBehaviour
{
    public event Action<int, int,int> UpdateHealthOnAttack;
    public CharacterDate_SO templateData;
    public CharacterDate_SO characterDate;
    public AttackDate_SO attackData;


    public AttackDate_SO tempAttackDate;
    public AttackDate_SO baseAttackData;
    public ContinerSkillUI continerSkillUI;
    [HideInInspector]
    public bool isCritical;

   // [Header("Wepon")]
    //public Transform weponSlot;
    //private RuntimeAnimatorController baseAnimtor;
    #region Read form Date SO
    public int MaxHealth
    {
        get{if (attackData != null){return attackData.maxHealth+attackData.con*10+attackData.str*5;}else { return 0;}}
    }
    public int CurrentHealth
    {
        get { if (attackData != null) { return attackData.currentHealth; } else { return 0; } }
        set { attackData.currentHealth = value; }
    }
    public int MaxMagic
    {
        get { if (attackData != null) { return attackData.maxMagic + attackData.wis * 10; } else { return 0; } }
    }
    public int CurrentMagic
    {
        get { if (attackData != null) { return attackData.currentMagic; } else { return 0; } }
        set { attackData.currentHealth = value; }
    }
    public int Defence
    {
        get { if (attackData != null) { return attackData.defence+attackData.con; } else { return 0; } }
    }
    public int MagicDefence
    {
        get { if (attackData != null) { return attackData.magicDefence + attackData.inte; } else { return 0; } }
    }
    public int MinAttack
    {
        get { if (attackData != null) { return attackData.minAttack + attackData.str*2; } else { return 0; } }
    }
    public int MaxAttack
    {
        get { if (attackData != null) { return attackData.maxAttack + attackData.str*2; } else { return 0; } }
    }
    public int MaxMagicAttack
    {
        get { if (attackData != null) { return attackData.maxMagicAttack + attackData.inte*2+attackData.wis; } else { return 0; } }
        
    }
    public int MinMagicAttack
    {
        get { if (attackData != null) { return attackData.minMagicAttack + attackData.inte * 2 + attackData.wis; } else { return 0; } }

    }
    public float CriticalMultiplier
    {
        get { if (attackData != null) { return attackData.criticalMultiplier; } else { return 0; } }
    }
    public float CriticalChance
    {
        get { if (attackData != null) { return attackData.criticalChance+attackData.dex; } else { return 0; } }
    }
    public float Hit
    {
        get { if (attackData != null) { return attackData.hit+attackData.dex; } else { return 0; } }
    }
    public float Miss
    {
        get { if (attackData != null) { return attackData.miss + attackData.dex; } else { return 0; } }
    }
    #endregion
    #region Combat
    private void Awake()
    {
        if (templateData != null)
        {
            characterDate = Instantiate(templateData);
        }
        if (tempAttackDate != null)
        {
            if (baseAttackData == null)
            {
                baseAttackData = Instantiate(tempAttackDate);
            }
            if (attackData == null)
            {
                attackData = Instantiate(baseAttackData);
            }
            
        }
        if (transform.gameObject.CompareTag("Player"))
        {
            SaveManager.Instance.LoadPlayerData();
            SaveManager.Instance.SavePlayerData();
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = MaxHealth;
        }
        //baseAnimtor = GetComponent<Animator>().runtimeAnimatorController;
    }
    private void Start()
    {

        //CurrentHealth = MaxHealth;
        //CurrentMagic = MaxMagic;
    }
    private void Update()
    {
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        if (CurrentMagic > MaxMagic)
        {
            CurrentMagic = MaxMagic;
        }
        

    }
    public void TakeDamage(CharacterStates attacker,CharacterStates defender,bool isMagic)
    {
        int damage = 0;
        if (!isMagic)
        {
            damage = Mathf.Max(attacker.CurrentDamage(isMagic) - defender.Defence, 1);
        }
        else
        {
            damage = Mathf.Max(attacker.CurrentDamage(isMagic) - defender.MagicDefence, 1);
        }
        //暴击规则
        if ((attacker.CriticalChance / 100f) > UnityEngine.Random.value)
        {
            damage=(int)(damage* CriticalMultiplier);
        }
        //命中规则
        if ((attacker.Hit - attacker.Miss) >= 0)
        {
            
            if(((attacker.Hit - attacker.Miss) / 100f + 0.9f) <= UnityEngine.Random.value)
            {
                damage = 0;
            }
        }
        else
        {
            if ((0.9f-(attacker.Miss - attacker.Hit) / 100f ) <= UnityEngine.Random.value)
            {
                damage = 0;
            }
        }
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
        //UpDateUI
        UpdateHealthOnAttack?.Invoke(CurrentHealth, MaxHealth,damage);
        //Exp UpDate
        if (CurrentHealth <= 0)
        {
            attacker.characterDate.UpdateExp(characterDate.killPoint);
        }
    }
    public void TakeDamage(int damage,CharacterStates attacker,CharacterStates defencer,bool isMagic) 
    {
        int currentDamage=0;
        if (!isMagic)
        {
            currentDamage = Mathf.Max(damage - defencer.Defence, 1);
        }
        else
        {
            currentDamage = Mathf.Max(damage - defencer.MagicDefence, 1);
        }
        //暴击规则
        if ((attacker.CriticalChance / 100f) > UnityEngine.Random.value)
        {
            currentDamage = (int)(currentDamage * CriticalMultiplier);
        }
        //命中规则
        if ((attacker.Hit - attacker.Miss) >= 0)
        {

            if (((attacker.Hit - attacker.Miss) / 100 +0.9) <= UnityEngine.Random.value)
            {
                damage = 0;
            }
        }
        else
        {
            if ((0.9 - (attacker.Miss - attacker.Hit) / 100) <= UnityEngine.Random.value)
            {
                damage = 0;
            }
        }
        CurrentHealth = Mathf.Max(CurrentHealth - currentDamage, 0);
        UpdateHealthOnAttack?.Invoke(CurrentHealth, MaxHealth,currentDamage);
        if (CurrentHealth <= 0)
        {
            attacker.characterDate.UpdateExp(characterDate.killPoint);
        }
    }

    private int CurrentDamage(bool isMagic)
    {
        float coreDamage = 0;
        if (!isMagic)
        {
            coreDamage = UnityEngine.Random.Range(MinAttack,MaxAttack);
        }
        else
        {
            coreDamage = UnityEngine.Random.Range(MinMagicAttack,MaxMagicAttack);
        }
       
        return (int)coreDamage;
    }
    #endregion
    #region Equit Wepon
    public void ChanceWepon(ItemData_SO wepon)
    {
        UnequipWeapon(wepon);
        EquipWepon(wepon);
    }
    public void EquipWepon(ItemData_SO weapon)
    {
       /* if (weponSlot != null)
        {
            Instantiate(weapon.weponPrefab, weponSlot);
        }*/
        //更新数据
        attackData.ApplyWeponData(weapon.weponData);
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        if (CurrentMagic > MaxMagic)
        {
            CurrentMagic = MaxMagic;
        }
       //-- GetComponent<Animator>().runtimeAnimatorController = weapon.weaponAnimtor;
      //  InventoryManager.Instance.UpdateStatesText(MaxHealth, attackData.minAttack, attackData.maxAttack);
    }
    
    public void UnequipWeapon(ItemData_SO wepon)
    {
        /*
        if (weponSlot.transform.childCount != 0)
        {
            for (int i = 0; i < weponSlot.transform.childCount; i++)
            {
                Destroy(weponSlot.transform.GetChild(i).gameObject);
            }
        }*/
        attackData.ApplyWeponData(baseAttackData);
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        if (CurrentMagic > MaxMagic)
        {
            CurrentMagic = MaxMagic;
        }
        //切换动画
        /*
        GetComponent<Animator>().runtimeAnimatorController = baseAnimtor;
        */
    }
    #endregion
    #region Apply Data Cahange
    public void ApplyHealth(int amount)
    {
        if (amount + CurrentHealth <= MaxHealth)
        {
            CurrentHealth += amount;
        }
        else
        {
            CurrentHealth = MaxHealth;
        }
    }
    #endregion
}
