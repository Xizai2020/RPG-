using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EuiqState : Singleton<EuiqState>
{
    public AttackDate_SO euiqAttackDate;
    void Start()
    {
        
    }

    void Update()
    {
        if (InventoryManager.Instance.weponentData&&GameManager.Instance.playerCharterstate)
        {


            //传输数据
            /*
            euiqAttackDate.attackRange = GameManager.Instance.playerCharterstate.baseAttackData.attackRange;
            euiqAttackDate.coolDown = GameManager.Instance.playerCharterstate.baseAttackData.coolDown;
            euiqAttackDate.criticalChance = GameManager.Instance.playerCharterstate.baseAttackData.criticalChance;
            euiqAttackDate.criticalMultiplier = GameManager.Instance.playerCharterstate.baseAttackData.criticalMultiplier;
            euiqAttackDate.currentDefence = GameManager.Instance.playerCharterstate.baseAttackData.currentDefence;
            euiqAttackDate.currentHealth = GameManager.Instance.playerCharterstate.baseAttackData.currentHealth;
            euiqAttackDate.maxHealth = GameManager.Instance.playerCharterstate.baseAttackData.maxHealth;
            euiqAttackDate.maxDamage = GameManager.Instance.playerCharterstate.baseAttackData.maxDamage;
            euiqAttackDate.minDamage = GameManager.Instance.playerCharterstate.baseAttackData.minDamage;
            euiqAttackDate.skillRange = GameManager.Instance.playerCharterstate.baseAttackData.skillRange;*/
            euiqAttackDate = Instantiate(GameManager.Instance.playerCharterstate.baseAttackData);
            foreach (var item in InventoryManager.Instance.weponentData.items)
            {
                if (item.ItemData != null)
                {
                    euiqAttackDate.str += item.ItemData.weponData.str;
                    euiqAttackDate.con += item.ItemData.weponData.con;
                    euiqAttackDate.dex += item.ItemData.weponData.dex;
                    euiqAttackDate.inte += item.ItemData.weponData.inte;
                    euiqAttackDate.wis += item.ItemData.weponData.wis;
                    euiqAttackDate.maxHealth += item.ItemData.weponData.maxHealth;
                    euiqAttackDate.maxMagic += item.ItemData.weponData.maxMagic;
                    euiqAttackDate.defence += item.ItemData.weponData.defence;
                    euiqAttackDate.magicDefence += item.ItemData.weponData.magicDefence;
                    euiqAttackDate.hit += euiqAttackDate.hit;
                    euiqAttackDate.miss += euiqAttackDate.miss;
                    euiqAttackDate.criticalChance += item.ItemData.weponData.criticalChance;
                    euiqAttackDate.criticalMultiplier += item.ItemData.weponData.criticalMultiplier;
                if (item.ItemData.itemType == ItemType.Wepon)
                {
                        euiqAttackDate.attackRange = item.ItemData.weponData.attackRange;
                        euiqAttackDate.coolDown = item.ItemData.weponData.coolDown;
                        euiqAttackDate.maxAttack += item.ItemData.weponData.maxAttack;
                        euiqAttackDate.minAttack += item.ItemData.weponData.minAttack;
                        euiqAttackDate.minMagicAttack += item.ItemData.weponData.minMagicAttack;
                        euiqAttackDate.maxMagicAttack += item.ItemData.weponData.maxMagicAttack;

                        //改变玩家武器的造型
                        if (GameManager.Instance.playerCharterstate)
                        {
                            if (item.ItemData == null)
                            {
                                GameObject.FindGameObjectWithTag("WeponLeft").GetComponent<SpriteRenderer>().sprite = null;
                            }
                            else
                            {
                                GameObject.FindGameObjectWithTag("WeponLeft").GetComponent<SpriteRenderer>().sprite = item.ItemData.itemIcon;
                            }
                            
                        }
                }
                    if (item.ItemData.itemType == ItemType.SecondaryWeapon)
                    {

                        euiqAttackDate.maxAttack += item.ItemData.weponData.maxAttack;
                        euiqAttackDate.minAttack += item.ItemData.weponData.minAttack;
                        euiqAttackDate.minMagicAttack += item.ItemData.weponData.minMagicAttack;
                        euiqAttackDate.maxMagicAttack += item.ItemData.weponData.maxMagicAttack;
                        //改变玩家武器的造型
                        if (GameManager.Instance.playerCharterstate)
                        {
                            if (item.ItemData == null)
                            {
                                GameObject.FindGameObjectWithTag("WeponLeft").GetComponent<SpriteRenderer>().sprite = null;
                            }
                            else
                            {
                                GameObject.FindGameObjectWithTag("WeponLeft").GetComponent<SpriteRenderer>().sprite = item.ItemData.itemIcon;
                            }
                                
                        }
                    }
                }
            }
            if (InventoryManager.Instance.weponentData.items[2].ItemData == null)
            {
                GameObject.FindGameObjectWithTag("WeponLeft").GetComponent<SpriteRenderer>().sprite = null;
            }
            if (InventoryManager.Instance.weponentData.items[7].ItemData == null)
            {
                GameObject.FindGameObjectWithTag("WeponRight").GetComponent<SpriteRenderer>().sprite = null;
            }
            if (euiqAttackDate != null)
            {
                GameManager.Instance.playerCharterstate.attackData.ApplyWeponData(euiqAttackDate);
                
            }
            
        }
    }
}
