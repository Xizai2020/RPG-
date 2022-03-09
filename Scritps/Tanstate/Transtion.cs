using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transtion : MonoBehaviour
{
    public enum TranstateType
    {
        SameScene,DiffentScene
    }
    [Header("TranstionInfo")]
    public string sceneName;
    public TranstateType transtateType;
    public TranstionDestion.DestionTag destionTag;
    private bool canTrans;
    private float  coolTime;
    private void Update()
    {
        if (canTrans)
        {
            coolTime += Time.deltaTime;
            //SceneCtrol´«ËÍ£»
            if (coolTime > 1)
            {
                SceneCtroll.Instance.TranstionToDestion(this);
                coolTime = 0;
            }
            
        }
        else
        {
            coolTime = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTrans = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTrans = false;
        }
    }

}
