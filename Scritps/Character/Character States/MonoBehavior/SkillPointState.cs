using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointState : MonoBehaviour
{
    private Text skillPoint;
    private void Awake()
    {
        skillPoint = GetComponentInChildren<Text>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        skillPoint.text = GameManager.Instance.playerCharterstate.characterDate.currentSkilPoint.ToString("00");
    }
}
