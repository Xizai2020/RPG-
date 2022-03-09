using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Date",menuName ="Attack/Attack Data")]
public class AttackDate_SO : ScriptableObject
{
    private void Awake()
    {
        currentHealth = maxHealth+str*5+con*10;
        currentMagic = maxMagic+wis*10;
    }
    [Header("需求等级")]
    public int needLevel;
    [Header("基础属性")]
    public int str;
    public int con;
    public int dex;
    public int inte;
    public int wis;
    [Header("attack")]
    public int maxHealth;
    public int currentHealth;
    public int maxMagic;
    public int currentMagic;
    public int defence;
    public int magicDefence;
    public float attackRange;
    public float skillRange;
    public float coolDown;
    public int minAttack;
    public int maxAttack;
    public int minMagicAttack;
    public int maxMagicAttack;
    public float criticalMultiplier;
    public float criticalChance;
    public int hit;
    public int miss;
    public void ApplyWeponData(AttackDate_SO weapon)
    {
        str = weapon.str;
        con = weapon.con;
        dex = weapon.dex;
        inte = weapon.inte;
        wis = weapon.wis;
        maxHealth = weapon.maxHealth;
        defence = weapon.defence;
        magicDefence = weapon.magicDefence;
        criticalMultiplier = weapon.criticalMultiplier;
        criticalChance = weapon.criticalChance;
        attackRange = weapon.attackRange;
        skillRange = weapon.skillRange;
        coolDown = weapon.coolDown;
        minAttack = weapon.minAttack;
        maxAttack = weapon.maxAttack;
        minMagicAttack = weapon.minMagicAttack;
        maxMagicAttack = weapon.maxMagicAttack;
        hit = weapon.hit;
        miss = weapon.miss;
    }

}

