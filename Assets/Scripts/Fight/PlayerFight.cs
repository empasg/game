using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    private float SwordAttackCooldown;
    private int AttackPhase;

    private int i = 0;

    private float _dmg;

    [HideInInspector] public bool stop = false;

    private bool GoToNearMob = false;
    private bool MobsSorted = true;
    private bool Fighting = false;

    private bool CanStartFight = false;

    private Animator _animator;

    CharacterStats playerStats;

    CharacterStats Stats;

    List<GameObject> mobs = new List<GameObject>();

    private void Start()
    {
        _animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();
    }

    public void StartFight()
    {

        GoToNearMob = true;
        MobsSorted = false;

        GetComponent<Movement>().Stunned = true;

        CanStartFight = true;

    }

    private void Update()
    {
        if (stop)
            return;

        if (!MobsSorted && CanStartFight)
        {
            
            Collider[] colliders = Physics.OverlapSphere(transform.position,1f);
            
            foreach (Collider colider in colliders)
            {

                if (colider.gameObject.name == "Platform")
                {
                    foreach(Transform child in colider.gameObject.transform)
                    {
                        
                        if (child.gameObject.name.Contains("SwordMan") || child.gameObject.name.Contains("ArcherWomen") )
                        {
                            mobs.Add(child.GetChild(0).gameObject);
                            
                        }

                    }

                }
                
            }
            mobs = mobs.OrderBy(x => Vector3.Distance(transform.position, x.transform.position) ).ToList();

            MobsSorted = true;  

        }

        if (GoToNearMob && MobsSorted) 
        {
            transform.LookAt(mobs[i].transform);

            if (Vector3.Distance( transform.position, mobs[i].transform.position) >= 1.5 )
            {

                _animator.SetFloat("MovementSpeed",Vector3.Distance( transform.position, mobs[i].transform.position));
                    
            }
            else
            {
                
                GoToNearMob = false;
                Fighting = true;
                _animator.SetFloat("MovementSpeed",0);
                
            }
        }

        if (Fighting && mobs.Count >=1)
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

        if (AttackPhase == 1)
        {
            _dmg = 7.5f;
        }
        else if (AttackPhase == 2)
        {
            _dmg = 5f;
        }
        else
        {
            _dmg = 2.5f;
        }

        Stats = mobs[i].GetComponent<CharacterStats>();
        
        if (Stats.currentHealth+_dmg <= 0)
        {
            
            if (i+1 < mobs.Count)
            {
                GoToNearMob = true;
                AttackPhase = 0;
            }

            i++;
            
            if (i+1 > mobs.Count)
            {
                
                
                GetComponent<Movement>().Stunned = false;
                Fighting = false;
                CanStartFight = false;
                i = 0;
                return;

            }  

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

        SwordAttackCooldown = Time.time + 0.75f + (float)AttackPhase/3;

    }

    IEnumerator DamageDelay(float dmg, float time)
    {

        yield return new WaitForSeconds(time);
        Stats.TakeDamage( dmg, playerStats );

    }

}
