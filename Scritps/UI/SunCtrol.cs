using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunCtrol : MonoBehaviour
{
    public float alphSpeed;
    public float minAlph;
    private Image image;
    public  float alph;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        alph += Time.deltaTime*alphSpeed;
        image.color = new Color(image.color.r, image.color.g, image.color.b,( Mathf.Sin(alph))*(1-minAlph)+minAlph);
    }
}
