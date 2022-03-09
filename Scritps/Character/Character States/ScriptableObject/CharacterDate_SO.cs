using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Date",menuName ="Character States/Date")]
public class CharacterDate_SO : ScriptableObject
{
    [Header("State Info:")]
    public int maxSkillPoint;
    public int currentSkilPoint;
    [Header("Kill")]
    public int killPoint;
    [Header("State Level")]
    public int currentLevel;
    public int maxLevel;
    public int baseExp;
    public int currentExp;
    public float levelBuff;
    [Header("State Point")]
    public int addStr;
    public int addCon;
    public int addDex;
    public int addInt;
    public int addWis;
    public int addPoint;
    public void UpdateExp(int point)
    {
        currentExp += point;
        if (currentExp>=baseExp)
        {

            LevelUp();
            currentExp = 0;
        }
    }
    public float LevelMultiplier
    {
        get { return 1 + (currentLevel - 1) * levelBuff; }
    }
    private void LevelUp()
    {

        currentLevel = Mathf.Clamp(currentLevel + 1, 0, maxLevel);
        baseExp += (int)(baseExp * LevelMultiplier);
        //升级属性增加
        if (GameManager.Instance.playerCharterstate)
        {
            GameManager.Instance.playerCharterstate.characterDate.addPoint += 5;
            GameManager.Instance.playerCharterstate.attackData.str += addStr;
            GameManager.Instance.playerCharterstate.attackData.con += addCon;
            GameManager.Instance.playerCharterstate.attackData.dex += addDex;
            GameManager.Instance.playerCharterstate.attackData.inte += addInt;
            GameManager.Instance.playerCharterstate.attackData.wis += addWis;

            GameManager.Instance.playerCharterstate.baseAttackData.str += addStr;
            GameManager.Instance.playerCharterstate.baseAttackData.con += addCon;
            GameManager.Instance.playerCharterstate.baseAttackData.dex += addDex;
            GameManager.Instance.playerCharterstate.baseAttackData.inte += addInt;
            GameManager.Instance.playerCharterstate.baseAttackData.wis += addWis;
        }
        //升级技能点增加
        if (GameManager.Instance.playerCharterstate != null)
        {
            maxSkillPoint = currentLevel;
            currentSkilPoint++;
            GameManager.Instance.playerCharterstate.CurrentHealth = GameManager.Instance.playerCharterstate.MaxHealth;
            
        }
       // maxHealth = (int)(maxHealth * LevelMultiplier);
      //  currentHealth = maxHealth;

        Debug.Log("LevelUp:" + currentLevel);
    }
}
