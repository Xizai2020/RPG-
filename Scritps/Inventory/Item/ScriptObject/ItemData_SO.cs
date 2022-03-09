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
            inFo ="���������"+ weponData.defence.ToString() + "\n";
        }
        if (weponData.magicDefence > 0)
        {
            inFo+="ħ��������"+weponData.magicDefence.ToString() + "\n";
        }
        inFo += "�������ԣ�" + "\n";
        //�����ǻ������ԣ����渽�����Ը���
        if (weponData.str > 0)
        {
            inFo += "������" + weponData.str.ToString() + "\n";
        }
        if (weponData.con > 0)
        {
            inFo += "���ʣ�" + weponData.con.ToString() + "\n";
        }
        if (weponData.dex > 0)
        {
            inFo += "���ݣ�" + weponData.dex.ToString() + "\n";
        }
        if (weponData.inte > 0)
        {
            inFo += "������" + weponData.inte.ToString() + "\n";
        }
        if (weponData.wis > 0)
        {
            inFo += "����" + weponData.wis.ToString() + "\n";
        }
        if (weponData.maxHealth > 0)
        {
            inFo+="������"+weponData.maxHealth.ToString() + "\n";
        }
        if (weponData.maxMagic > 0)
        {
            inFo+="ħ����"+weponData.maxMagic.ToString() + "\n";
        }
        if (weponData.hit > 0)
        {
            inFo+="���У�"+weponData.hit.ToString() + "\n";

        }
        if (weponData.miss>0)
        {
            inFo+="���ܣ�"+weponData.miss.ToString() + "\n";
        }
        if (inFo == "�������ԣ�" + "\n")//���û��������ղ���ʾ
        {
            inFo = "";
        }
        return inFo;

    }
    //�����ı�����
    private void OnEnable()
    {
        switch (itemType)
        {
            case ItemType.Useable:
                if (useableData != null)
                {
                    description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�����Ʒ" + "\n" +
                    "�ظ�������" + useableData.healthPoint.ToString();
                }
                break;
            case ItemType.Coin:
                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�����Ʒ" + "\n";
                break;
            case ItemType.Wepon:
                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�����" + "\n" +
                    "����ȼ���" + weponData.needLevel.ToString() + "\n" +
                    "�������ԣ�" + "\n"+
                "����������" + weponData.minAttack.ToString() + "-" + weponData.maxAttack + "\n" +
                    "ħ����������" + weponData.minMagicAttack.ToString() + "-" + weponData.maxMagicAttack + "\n" +
                    GetAttackData();
                break;
            case ItemType.Armor:
                                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�����" + "\n" +
                    "����ȼ���" + weponData.needLevel.ToString() + "\n" +
                    "�������ԣ�" + "\n"+
                    GetAttackData();
                break;
            case ItemType.SecondaryWeapon:
                                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�������" + "\n" +
                    "����ȼ���" + weponData.needLevel.ToString() + "\n" +
                    "�������ԣ�" + "\n"+
                "����������" + weponData.minAttack.ToString() + "-" + weponData.maxAttack + "\n" +
                    "ħ����������" + weponData.minMagicAttack.ToString() + "-" + weponData.maxMagicAttack + "\n" +
                    GetAttackData();
                break;
            case ItemType.Hat:
                                                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�ñ��" + "\n" +
                    "����ȼ���" + weponData.needLevel.ToString() + "\n" +
                    "�������ԣ�" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Necklace:
                                                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�����" + "\n" +
                    "����ȼ���" + weponData.needLevel.ToString() + "\n" +
                    "�������ԣ�" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Ring:
                                                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ���ָ" + "\n" +
                    "����ȼ���" + weponData.needLevel.ToString() + "\n" +
                    "�������ԣ�" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Clock:
                                                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�����" + "\n" +
                    "����ȼ���" + weponData.needLevel.ToString() + "\n" +
                    "�������ԣ�" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Glove:
                                                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�����" + "\n" +
                    "����ȼ���" + weponData.needLevel.ToString() + "\n" +
                    "�������ԣ�" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Shoes:
                                                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�Ь��" + "\n" +
                    "����ȼ���" + weponData.needLevel.ToString() + "\n" +
                    "�������ԣ�" + "\n"+
                    GetAttackData();
                break;
            case ItemType.Belt:
                                                description = "��Ʒ���ƣ�" + itemName + "\n" +
                    "��Ʒ���ͣ�����" + "\n" +
                    "����ȼ���" + weponData.needLevel.ToString() + "\n" +
                    "�������ԣ�" + "\n"+
                    GetAttackData();
                break;
            default:
                break;
        }
    }
    //public AnimatorOverrideController weaponAnimtor;

}
