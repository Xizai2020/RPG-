using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateInfo : MonoBehaviour
{
    public Text text;
    public Text info;
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.playerCharterstate)
        {
            CharacterStates character = GameManager.Instance.playerCharterstate;
            text.text = "生命：" + character.CurrentHealth + "/" + character.MaxHealth + "\n" +
                "魔力：" + character.CurrentMagic + "/" + character.MaxMagic + "\n" +
                "物理攻击力：" + character.MinAttack + "-" + character.MaxAttack + "\n" +
                "魔法攻击力：" + character.MinMagicAttack + "-" + character.MaxMagicAttack + "\n" +
                "物理防御力：" + character.Defence + "\n" +
                "魔法防御力：" + character.MagicDefence + "\n" +
                "暴击：" + character.CriticalChance + "%" + "\n" +
                "暴击伤害：" + (character.CriticalMultiplier*100).ToString("000") + "%" + "\n" +
                "命中：" + character.Hit + "\n" +
                "闪避：" + character.Miss;
            info.text = "力量：" + character.attackData.str + "\n" +
                "体质：" + character.attackData.con + "\n" +
                "敏捷：" + character.attackData.dex + "\n" +
                "智力：" + character.attackData.inte + "\n" +
                "精神：" + character.attackData.wis;
        }
    }
}
