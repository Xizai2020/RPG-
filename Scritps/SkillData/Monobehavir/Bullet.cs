using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string targetTag;

    public float speed;
    private Rigidbody2D rb;
    public CharacterStates currentCharacter;
    public int skillID;
    public SkillData_SO skillData;
    public bool isMagic;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        currentCharacter = GetComponentInParent<CharacterStates>();
        if (transform.parent.gameObject.CompareTag("Player"))
        {
            skillData = PlayerSkillManager.Instance.FindSkillData(skillID);

        }
        if (transform.parent.gameObject.CompareTag("Enemy"))
        {
            skillData = EnemySkillManager.Instance.FindSkillData(skillID);
        }
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            this.transform.parent = transform.parent.parent;
            rb.velocity = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x - this.transform.position.x,
            GameObject.FindGameObjectWithTag("Player").transform.position.y - this.transform.position.y).normalized * speed;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            int coreDamage = (int)(Random.Range(currentCharacter.attackData.maxAttack, currentCharacter.attackData.minAttack) * skillData.damageMultiplier) + skillData.damageAttach;
            collision.GetComponent<CharacterStates>().TakeDamage(currentCharacter, collision.GetComponent<CharacterStates>(),isMagic);

        }

    }
}
