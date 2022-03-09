using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StateButton { str,con,dex,inte,wis}
public class AddPoint : MonoBehaviour
{
    public StateButton stateButton;
    public int currentPoint;
    public Button button;
    private Text text;
    private Text parentText;
    private void Awake()
    {
        button = GetComponent<Button>();
        text = transform.GetChild(0).GetComponent<Text>();
        parentText = transform.parent.GetComponent<Text>();
        button.onClick.AddListener(AddPointCharacter);
    }

    private void AddPointCharacter()
    {
        if (GameManager.Instance.playerCharterstate.characterDate.addPoint > 0)
        {
            switch (stateButton)
            {
                case StateButton.str:
                    GameManager.Instance.playerCharterstate.characterDate.addPoint--;
                    GameManager.Instance.playerCharterstate.attackData.str++;
                    GameManager.Instance.playerCharterstate.baseAttackData.str++;
                    break;
                case StateButton.con:
                    GameManager.Instance.playerCharterstate.characterDate.addPoint--;
                    GameManager.Instance.playerCharterstate.attackData.con++;
                    GameManager.Instance.playerCharterstate.baseAttackData.con++;
                    break;
                case StateButton.dex:
                    GameManager.Instance.playerCharterstate.characterDate.addPoint--;
                    GameManager.Instance.playerCharterstate.attackData.dex++;
                    GameManager.Instance.playerCharterstate.baseAttackData.dex++;
                    break;
                case StateButton.inte:
                    GameManager.Instance.playerCharterstate.characterDate.addPoint--;
                    GameManager.Instance.playerCharterstate.attackData.inte++;
                    GameManager.Instance.playerCharterstate.baseAttackData.inte++;
                    break;
                case StateButton.wis:
                    GameManager.Instance.playerCharterstate.characterDate.addPoint--;
                    GameManager.Instance.playerCharterstate.attackData.wis++;
                    GameManager.Instance.playerCharterstate.baseAttackData.wis++;
                    break;
                default:
                    break;
            }
        }
    }

    void Start()
    {
        if (GameManager.Instance.playerCharterstate)
        {
            currentPoint = GameManager.Instance.playerCharterstate.characterDate.addPoint;
        }
        
    }

    void Update()
    {
        if (GameManager.Instance.playerCharterstate)
        {
            currentPoint = GameManager.Instance.playerCharterstate.characterDate.addPoint;
            text.text = GameManager.Instance.playerCharterstate.characterDate.addPoint.ToString();
            switch (stateButton)
            {
                case StateButton.str:
                    parentText.text = "力量：" + GameManager.Instance.playerCharterstate.attackData.str.ToString();
                    break;
                case StateButton.con:
                    parentText.text = "体质：" + GameManager.Instance.playerCharterstate.attackData.con.ToString();
                    break;
                case StateButton.dex:
                    parentText.text = "敏捷：" + GameManager.Instance.playerCharterstate.attackData.dex.ToString();
                    break;
                case StateButton.inte:
                    parentText.text = "智力：" + GameManager.Instance.playerCharterstate.attackData.inte.ToString();
                    break;
                case StateButton.wis:
                    parentText.text = "精神：" + GameManager.Instance.playerCharterstate.attackData.wis.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
