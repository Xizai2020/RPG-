using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour
{
    Text levelText;
    Image healthHolder;
    Image magicHoder;
    Image expHolder;
    private void Awake()
    {
        levelText = transform.GetChild(2).GetComponent<Text>();
        healthHolder = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        magicHoder= transform.GetChild(3).GetChild(0).GetComponent<Image>();
        expHolder = transform.GetChild(1).GetChild(0).GetComponent<Image>();
    }
    void UpDateHealthUI()
    {
        if (GameManager.Instance.playerCharterstate!=null)
        {
            float sliderPrecent = (float)GameManager.Instance.playerCharterstate.CurrentHealth / GameManager.Instance.playerCharterstate.MaxHealth;
            healthHolder.fillAmount = sliderPrecent;
            
        }
    }
    void UpDateMagicUI()
    {
        if (GameManager.Instance.playerCharterstate != null)
        {
            float sliderPrecent = (float)GameManager.Instance.playerCharterstate.CurrentMagic / GameManager.Instance.playerCharterstate.MaxMagic;
            magicHoder.fillAmount = sliderPrecent;

        }
    }
    void UpDateExpUI()
    {
        if (GameManager.Instance.playerCharterstate!=null)
        {
            float sliderPrecent = (float)GameManager.Instance.playerCharterstate.characterDate.currentExp / GameManager.Instance.playerCharterstate.characterDate.baseExp;
            expHolder.fillAmount = sliderPrecent;
        }
    }
    private void Update()
    {
        if (GameManager.Instance.playerCharterstate != null)
        {
            UpDateExpUI();
            UpDateHealthUI();
            UpDateMagicUI();
            levelText.text = "Level  " + GameManager.Instance.playerCharterstate.characterDate.currentLevel.ToString("00");
        }
            
    }
}
