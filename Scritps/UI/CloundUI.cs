using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloundUI : MonoBehaviour
{
    [SerializeField]
    public List<Image> clounds;
    public float speed;
    public float edgeLeft;
    public float edgeRight;
    public float edgeUp;
    public float edgeDown;
    void Start()
    {
        foreach (var item in clounds)
        {
            item.rectTransform.anchoredPosition = new Vector2(edgeRight + Random.Range(0, 2000), Random.Range(edgeDown, edgeUp));
            item.rectTransform.localScale = new Vector2(Random.Range(1, 2), Random.Range(1, 2));
        }
    }

    void Update()
    {
        foreach (var item in clounds)
        {
            item.transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (item.rectTransform.anchoredPosition.x < edgeLeft)
            {
                item.rectTransform.anchoredPosition=new Vector2(edgeRight + Random.Range(0, 500), Random.Range(edgeUp, edgeDown)); ;
                item.rectTransform.localScale = new Vector2(Random.Range(1, 2), Random.Range(1, 2));
            }
        }
    }
}
