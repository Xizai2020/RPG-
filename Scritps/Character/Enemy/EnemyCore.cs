using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState { GUARD, PATROL, CHASE, DEAD }
public class EnemyCore : MonoBehaviour
{
    public EnemyState enemyState;
    private Rigidbody2D rb;
    private Animator animator;
    protected CharacterStates characterStates;
    [Header("Bsae Setting:")]
    public float speed;
    public float sighrRadius;
    public bool isGuard;
    public float lookAtTime;
    private float remainLookTime;
    private float lastAttackTime;
    private Quaternion guardRotation;
    [Header("Patrol State:")]
    public float patrolRange;
    public float stopDistance;
    public Vector3 wayPoint;
    private Vector3 guardPos;
    
    protected GameObject attackTarget;

    bool isDead;

    private void Awake()
    {
        isDead = true;
        characterStates = GetComponent<CharacterStates>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        guardRotation = GetComponent<Transform>().rotation;
        guardPos = this.transform.position;
    }
    private void Start()
    {
        if (isGuard)
        {
            enemyState = EnemyState.GUARD;
        }
        else
        {
            enemyState = EnemyState.PATROL;
        }
        GetNewPoint();
    }
    void Update()
    {

        isDead = characterStates.CurrentHealth <= 0;

            SwitchEnemyState();
            SwitchAnimation();
            lastAttackTime -= Time.deltaTime;

    }
    private void OnDisable()
    {
        if (!GameManager.IsInitialized)
            return;
        if (GetComponent<LootSwaner>() && isDead)
        {
            GetComponent<LootSwaner>().Spawnloot();
        }
        if (QuestManager.IsInitialized && isDead)
        {
            QuestManager.Instance.UpdateQuestProgress(this.name, 1);
        }
    }
    private void SwitchAnimation()
    {
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }

    private void SwitchEnemyState()
    {
        if (isDead)
        {

            enemyState = EnemyState.DEAD;
        }
        //Èç¹û·¢ÏÖPlayerÇÐ»»Chaess
        else if (FindPlayer())
        {
            enemyState = EnemyState.CHASE;

        }
        switch (enemyState)
        {
            case EnemyState.GUARD:
                if (transform.position != guardPos)
                {
                    MoveTarget(guardPos);
                    if (Vector3.Distance(guardPos, transform.position) <= stopDistance)
                    {
                        transform.rotation = Quaternion.Lerp(transform.rotation, guardRotation, 0.1f);
                    }
                }

                break;
            case EnemyState.PATROL:

                if (Vector3.Distance(wayPoint, transform.position) <= stopDistance)
                {
                    if (remainLookTime > 0)
                    {
                        remainLookTime -= Time.deltaTime;
                    }
                    else
                    {
                        GetNewPoint();
                        remainLookTime = lookAtTime;
                    }

                }
                else
                {
                    MoveTarget(wayPoint);
                    //agent.isStopped = false;
                    //agent.destination = wayPoint;
                }
                break;
            case EnemyState.CHASE:
                //agent.speed = speed;
                if (!FindPlayer())
                {


                    if (remainLookTime > 0)
                    {
                        MoveTarget(transform.position);
                        //agent.destination = transform.position;
                        remainLookTime -= Time.deltaTime;
                    }
                    else if (isGuard)
                    {
                        enemyState = EnemyState.GUARD;
                    }
                    else
                    {
                        enemyState = EnemyState.PATROL;
                    }

                }
                else
                {
                    MoveTarget(attackTarget.transform.position);
                    // agent.isStopped = false;
                    // agent.destination = attackTarget.transform.position;

                }
                if (TargetInAttackRAnge() || TargetInSkillRange())
                {
                    // agent.isStopped = true;
                    if (lastAttackTime <= 0)
                    {
                        lastAttackTime = characterStates.attackData.coolDown;
                        //±©»÷ÅÐ¶Ï
                        characterStates.isCritical = UnityEngine.Random.value < characterStates.attackData.criticalChance;
                        //Ö´ÐÐ¹¥»÷
                        Attack();
                    }
                }
                break;
            case EnemyState.DEAD:
                //coll.enabled = false;
                //agent.radius = 0;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(gameObject.gameObject);
                break;
        }
    }
    private void MoveTarget(Vector2 target)
    {
        if (Vector3.Distance(target, transform.position) >= stopDistance)
        {
            rb.velocity = new Vector2(target.x - this.transform.position.x,
            target.y - this.transform.position.y).normalized * speed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (target.x > this.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (target.x < this.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
    private void Attack()
    {
        
        if (TargetInAttackRAnge())
        {
            //½üÉí¹¥»÷¶¯»­
            animator.SetTrigger("Attack");
        }
        if (TargetInSkillRange())
        {
            //animator.SetTrigger("Skill");
            //Ô¶³Ì¹¥»÷¶¯»­
        }
    }
    bool FindPlayer()
    {
        transform.GetChild(0).gameObject.GetComponent<Enemt_CheckRange>().range = patrolRange;
        var target = transform.GetChild(0).gameObject.GetComponent<Enemt_CheckRange>().target;
        //var collilders = Physics2D.OverlapCircleAll(transform.position, sighrRadius);
            //OverlapSphere(transform.position, sighrRadius);
         if (target!=null)
            {
                attackTarget = target.gameObject;
                
                return true;
            }
        
        attackTarget = null;
        return false;
    }
    void GetNewPoint()
    {
        remainLookTime = lookAtTime;
        float randomX = UnityEngine.Random.Range(-patrolRange, patrolRange);
        float randomy = UnityEngine.Random.Range(-patrolRange, patrolRange);
        Vector3 randomPoint = new Vector3(guardPos.x + randomX,  guardPos.y + randomy,0);
        wayPoint = randomPoint;
    }
    bool TargetInAttackRAnge()
    {
        if (attackTarget != null)
        {
            return Vector3.Distance(attackTarget.transform.position, transform.position) <= characterStates.attackData.attackRange;
        }
        else
        {
            return false;
        }

    }
    bool TargetInSkillRange()
    {
        if (attackTarget != null)
        {
            return Vector3.Distance(attackTarget.transform.position, transform.position) <= characterStates.attackData.skillRange;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, sighrRadius);
    }
}
