using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherWomen : MonoBehaviour
{
    bool GoToPlayer = false;
    bool Fighting = false;
    private int AttackPhase;
    private float RangeAttackCooldown;
    private float MeleeAttackCooldown;

    [SerializeField] private GameObject Player;

    Vector3 vel = Vector3.zero;

    private Animator _animator;

    private CharacterStats Stats;
    private PlayerStats _PlayerStats;

    [HideInInspector] public bool stop = false;

    void Start()
    {

        _animator = GetComponent<Animator>();

        Stats = GetComponent<CharacterStats>();
        _PlayerStats = Player.GetComponent<PlayerStats>();

    }

    public void StartFight()
    {

        GoToPlayer = true;
        
        
    }

    void Update()
    {
        if (stop)
        {
            _animator.SetInteger("AttackPhase",0);
            return;
        }
            
        transform.LookAt(Player.transform);

        if (GoToPlayer && Vector3.Distance(Player.transform.position,transform.position) >= 4.5f )
        {

            _animator.SetFloat("MovementSpeed", Vector3.Distance(Player.transform.position,transform.position) );

        }
        else if (GoToPlayer && Vector3.Distance(Player.transform.position,transform.position) < 4.5f )
        {

            _animator.SetFloat("MovementSpeed", 0 );
            GoToPlayer = false;
            Fighting = true;

        }

        if (Fighting)
        {
            if (RangeAttackCooldown < Time.time && Vector3.Distance(Player.transform.position,transform.position) > 2.5f)
                RangeAttack();
            else if (MeleeAttackCooldown < Time.time && Vector3.Distance(Player.transform.position,transform.position) <= 2.5f)
                MeleeAttack();
        }

    }
    
    void RangeAttack()
    {

        AttackPhase++;
        if (AttackPhase >= 2)
        {
            AttackPhase = 0;
        }

        _animator.SetInteger("AttackPhase",AttackPhase);

        if (AttackPhase == 1)
        {
            StartCoroutine(DamageDelay(3.5f, 1f));
        }

        RangeAttackCooldown = Time.time + 1f;

    }

    void MeleeAttack()
    {

        AttackPhase++;
        if (AttackPhase == 1)
        {
            AttackPhase = 2;
        }
        else if (AttackPhase >= 3)
        {
            AttackPhase = 0;
        }

        _animator.SetInteger("AttackPhase",AttackPhase);

        if (AttackPhase == 2)
        {
            StartCoroutine(DamageDelay(1.5f, 1f));
        }

        MeleeAttackCooldown = Time.time + 1f;

    }

    IEnumerator DamageDelay(float dmg, float time)
    {

        yield return new WaitForSeconds(time);
        _PlayerStats.TakeDamage(dmg,Stats);
        
    }

}
