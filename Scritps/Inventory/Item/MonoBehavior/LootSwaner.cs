using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSwaner : MonoBehaviour
{
    [System.Serializable]
    public class LootItem
    {
        public GameObject item;
        [Range(0,1)]
        public float weight;
    }
    public LootItem[] lootItems;
    public void Spawnloot()
    {
        
        for (int i = 0; i < lootItems.Length; i++)
        {
            float currentValue = Random.value;
            if (currentValue <= lootItems[i].weight)
            {
                GameObject obj = Instantiate(lootItems[i].item);
                obj.transform.position = this.transform.position;
            }
        }
    }
}
