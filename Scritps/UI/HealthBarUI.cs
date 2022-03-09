using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public GameObject healthBarUI;
    public Transform barPoint;
    public bool alwaysVisable;
    public float VisableTime;
    private float timeLive;
    [Header("DamageUI")]
    public GameObject damageUI;
    public Image healthSlider;
    Transform UIbar;
    Transform cam;
    CharacterStates currenSates;
    private void Awake()
    {
        currenSates = GetComponent<CharacterStates>();
        currenSates.UpdateHealthOnAttack += UpdateHealthBar;
        
    }
    private void OnEnable()
    {
        cam = Camera.main.transform;
        foreach (var canvs in FindObjectsOfType<Canvas>())
        {
            if (canvs.renderMode == RenderMode.WorldSpace&&canvs.CompareTag("HealthUI"))
            {
                UIbar = Instantiate(healthBarUI, canvs.transform).transform;
                healthSlider = UIbar.GetChild(0).GetComponent<Image>();

                UIbar.gameObject.SetActive(alwaysVisable);
            }
        }
        
    }
    private void Start()
    {
        
    }
    private void UpdateHealthBar(int currentHealth, int maxHealth,int damage)
    {


        

        if (damageUI != null)
        {
            if (damage == 0)
            {
                damageUI.GetComponent<Text>().text = "Î´ÃüÖÐ";
                Instantiate(damageUI, UIbar);
            }
            else
            {
                damageUI.GetComponent<Text>().text = damage.ToString();
                Instantiate(damageUI, UIbar);
            }   
        }
        if (currentHealth <= 0)
        {
            Destroy(UIbar.gameObject,0.1f);
        }
        else
        {
            UIbar.gameObject.SetActive(true);
            timeLive = VisableTime;
            float sliderPercent = (float)currentHealth / maxHealth;
            healthSlider.fillAmount = sliderPercent;
        }

    }
    private void Update()
    {
        if (GameManager.Instance.playerCharterstate != null&&this.gameObject.CompareTag("Player"))
        {
            float sliderPrecent = (float)GameManager.Instance.playerCharterstate.CurrentHealth / GameManager.Instance.playerCharterstate.MaxHealth;
            healthSlider.fillAmount = sliderPrecent;
        }
    }
    private void LateUpdate()
    {
        if (UIbar != null)
        {
            UIbar.position = barPoint.position;
            UIbar.forward = -cam.forward;
            if (timeLive <= 0 && !alwaysVisable)
            {
                UIbar.gameObject.SetActive(false);
            }
            else
            {
                timeLive -= Time.deltaTime;
            }

        }
    }
}
