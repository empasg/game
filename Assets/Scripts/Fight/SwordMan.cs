using System.Collections;
using UnityEngine;

public class SwordMan : MonoBehaviour
{

    bool GoToPlayer = false;
    bool Fighting = false;
    private int AttackPhase;
    private float SwordAttackCooldown;

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

        if (GoToPlayer && Vector3.Distance(Player.transform.position,transform.position) >= 1.5f )
        {

            _animator.SetFloat("MovementSpeed", Vector3.Distance(Player.transform.position,transform.position) );

        }
        else if (GoToPlayer && Vector3.Distance(Player.transform.position,transform.position) < 1.5f )
        {

            _animator.SetFloat("MovementSpeed", 0 );
            GoToPlayer = false;
            Fighting = true;

        }

        if (Fighting)
        {
            if (SwordAttackCooldown < Time.time)
                SwordAttack();
        }

    }
    
    void SwordAttack()
    {

        AttackPhase++;
        if (AttackPhase >= 4)
        {
            AttackPhase = 1;
        }

        _animator.SetInteger("AttackPhase",AttackPhase);

        if (AttackPhase == 1)
        {
            StartCoroutine(DamageDelay(7.5f, 0.5f));
        }
        else if (AttackPhase == 2)
        {
            StartCoroutine(DamageDelay(5f, 0.8f));
        }
        else
        {
            StartCoroutine(DamageDelay(2.5f, 0.5f));
        }

        print(AttackPhase);

        SwordAttackCooldown = Time.time + (float)AttackPhase*1.25f - ( (float)AttackPhase/1.5f );

    }

    IEnumerator DamageDelay(float dmg, float time)
    {

        yield return new WaitForSeconds(time);
        _PlayerStats.TakeDamage(dmg,Stats);
        
    }

}
