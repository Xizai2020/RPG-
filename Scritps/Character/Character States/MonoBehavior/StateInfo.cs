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
            text.text = "������" + character.CurrentHealth + "/" + character.MaxHealth + "\n" +
                "ħ����" + character.CurrentMagic + "/" + character.MaxMagic + "\n" +
                "����������" + character.MinAttack + "-" + character.MaxAttack + "\n" +
                "ħ����������" + character.MinMagicAttack + "-" + character.MaxMagicAttack + "\n" +
                "�����������" + character.Defence + "\n" +
                "ħ����������" + character.MagicDefence + "\n" +
                "������" + character.CriticalChance + "%" + "\n" +
                "�����˺���" + (character.CriticalMultiplier*100).ToString("000") + "%" + "\n" +
                "���У�" + character.Hit + "\n" +
                "���ܣ�" + character.Miss;
            info.text = "������" + character.attackData.str + "\n" +
                "���ʣ�" + character.attackData.con + "\n" +
                "���ݣ�" + character.attackData.dex + "\n" +
                "������" + character.attackData.inte + "\n" +
                "����" + character.attackData.wis;
        }
    }
}
