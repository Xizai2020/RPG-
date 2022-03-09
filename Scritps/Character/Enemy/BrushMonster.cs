using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushMonster : MonoBehaviour
{
    [Header("Setting")]
    public int maxCount;
    public float brushRange;
    public float brushCD;
    private float coolTime;
    public List<GameObject> enemys;
    void Start()
    {
        coolTime = brushCD;
    }

    void Update()
    {
        coolTime -= Time.deltaTime;
        if (coolTime <= 0)
        {
            CheckEnemy();
            coolTime = brushCD;
        }
    }
    void CheckEnemy()
    {
        if (GetComponentsInChildren<CharacterStates>().Length < maxCount)
        {
            if (enemys != null)
            {
                
                float randomX = UnityEngine.Random.Range(-brushRange, brushRange);
                float randomy = UnityEngine.Random.Range(-brushRange, brushRange);
                Vector3 randomPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomy, 0);
                Instantiate(enemys[(int)Random.Range(0, enemys.Count)], randomPoint,Quaternion.identity,transform);
            }

            
        }
    }
}
