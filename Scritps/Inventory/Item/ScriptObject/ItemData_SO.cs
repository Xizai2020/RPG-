using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public enum ItemType { Useable,Coin,Wepon,Armor, SecondaryWeapon, Hat, Necklace, Ring, Clock, Glove, Shoes, Belt, }
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item Data")]
public class ItemData_SO : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemIcon;
    public int itemAmount;
    public int buyCount;
    public int sellCount;
    [TextArea]
    public string description = "";
    public bool stackable;
    [Header("Wepon")]
    public AttackDate_SO weponData;
    [Header("Useable Item")]
    [HideInInspector]
    public UseableItem_SO useableData;

    private string GetAttackData()
    {

        string inFo ="";
        if (weponData.defence > 0)
        {
            inFo ="物理防御："+ weponData.defence.ToString() + "\n";
        }
        if (weponData.magicDefence > 0)
        {
            inFo+="魔法防御："+weponData.magicDefence.ToString() + "\n";
        }
        inFo += "附加属性：" + "\n";
        //上面是基础属性，下面附加属性更新
        if (weponData.str > 0)
        {
            inFo += "力量：" + weponData.str.ToString() + "\n";
        }
        if (weponData.con > 0)
        {
            inFo += "体质：" + weponData.con.ToString() + "\n";
        }
        if (weponData.dex > 0)
        {
            inFo += "敏捷：" + weponData.dex.ToString() + "\n";
        }
        if (weponData.inte > 0)
        {
            inFo += "智力：" + weponData.inte.ToString() + "\n";
        }
        if (weponData.wis > 0)
        {
            inFo += "精神：" + weponData.wis.ToString() + "\n";
        }
        if (weponData.maxHealth > 0)
        {
            inFo+="体力："+weponData.maxHealth.ToString() + "\n";
        }
        if (weponData.maxMagic > 0)
        {
            inFo+="魔力："+weponData.maxMagic.ToString() + "\n";
        }
        if (weponData.hit > 0)
        {
            inFo+="命中："+weponData.hit.ToString() + "\n";

        }
        if (weponData.miss>0)
        {
            inFo+="闪避："+weponData.miss.ToString() + "\n";
        }
        if (inFo == "附加属性：" + "\n")//如果没有数据清空不显示
        {
            inFo = "";
        }
        return inFo;

    }
    //更新文本描述
    private void OnEnable()
    {
        switch (itemType)
        {
            case ItemType.Useable:
                if (useableData != null)
                {
                    description = "物品名称：" + itemName + "\n" +
                    "物品类型：消耗品" + "\n" +
                    "回复体力：" + useableData.healthPoint.ToString();
                }
                break;
            case ItemType.Coin:
                description = "物品名称：" + itemName + "\n" +
                    "物品类型：消耗品" + "\n";
                break;
            case ItemType.Wepon:
                description = "物品名称：" + itemName + "\n" +
                    "物品类型：武器" + "\n" +
                    "需求等级：" + weponData.needLevel.ToString() + "\n" +
                    "基本属性：" + "\n"+
                "物理攻击力：" + weponData.minAttack.ToString() + "-" + weponData.maxAttack + "\n" +
                    "魔法攻击力：" + weponData.minMagicAttack.ToString() + "-" + weponData.maxMagicAttack + "\n" +
                    GetAttackData();
                break;
            case ItemType.Armor:
                                description = "物品名称：" + itemName + "\n" +
                    "物品类型：上衣" + "\n" +
                    "需求等级：" + weponData.needLevel.ToString() + "\n" +
                    "基本属性：" + "\n"+
                    GetAttackData();
                break;
            case ItemType.SecondaryWeapon:
                                description = "物品名称：" + itemName + "\n" +
                    "物品类型：副武器" + "\n" +
                    "需求等级：" + weponData.needLevel.ToString() + "\n" +
                    "基本属性：" + "\n"+
                "物理攻击力：" + weponData.minAttack.ToString() + "-" + weponData.maxAttack + "\n" +
                    "魔法攻击力：" + weponData.minMagicAttack.ToString() + "-" + weponData.maxMagicAttack + "\n" +
                    GetAttackData();
                break;
            case ItemType.Hat:
                                                description = "物品名称：" + itemName + "\n" +
                    "物品类型：帽子" + "\n" +
                    "需求等级：" + weponData.needLevel.ToString() + "\n" +
                    "基本属性：" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Necklace:
                                                description = "物品名称：" + itemName + "\n" +
                    "物品类型：项链" + "\n" +
                    "需求等级：" + weponData.needLevel.ToString() + "\n" +
                    "基本属性：" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Ring:
                                                description = "物品名称：" + itemName + "\n" +
                    "物品类型：戒指" + "\n" +
                    "需求等级：" + weponData.needLevel.ToString() + "\n" +
                    "基本属性：" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Clock:
                                                description = "物品名称：" + itemName + "\n" +
                    "物品类型：披风" + "\n" +
                    "需求等级：" + weponData.needLevel.ToString() + "\n" +
                    "基本属性：" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Glove:
                                                description = "物品名称：" + itemName + "\n" +
                    "物品类型：手套" + "\n" +
                    "需求等级：" + weponData.needLevel.ToString() + "\n" +
                    "基本属性：" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Shoes:
                                                description = "物品名称：" + itemName + "\n" +
                    "物品类型：鞋子" + "\n" +
                    "需求等级：" + weponData.needLevel.ToString() + "\n" +
                    "基本属性：" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Belt:
                                                description = "物品名称：" + itemName + "\n" +
                    "物品类型：腰带" + "\n" +
                    "需求等级：" + weponData.needLevel.ToString() + "\n" +
                    "基本属性：" + "\n"+
                    GetAttackData();
                break;
            default:
                break;
        }
    }
    //public AnimatorOverrideController weaponAnimtor;

}
