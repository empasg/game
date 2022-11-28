using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterStats : MonoBehaviour
{

    public HealthBar healthBar;

    public float maxHealth = 100;
    public float currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    [HideInInspector] public bool DeadStatus;

    void Awake()
    {

        currentHealth = maxHealth;

        if (healthBar != null)
            {healthBar.SetMaxHealth((float)maxHealth);}

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
            TakeDamage(15,null);

    }

    public void TakeDamage ( float dmg, CharacterStats stats )
    {
        if (stats != null)
            {dmg += stats.damage.GetValue();}

        dmg -= armor.GetValue();
        dmg = Mathf.Clamp(dmg,0,float.MaxValue);

        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Die();
        }

        if (healthBar != null)
            {healthBar.SetHealth((float)currentHealth);}

    }

    public virtual void Die()
    {
        
        GetComponent<Animator>().Play("Base Layer.Die");
        healthBar.gameObject.SetActive(false);
        if (transform.parent.gameObject.name.Contains("SwordMan"))
            gameObject.GetComponent<SwordMan>().stop = true;

        if (transform.parent.gameObject.name.Contains("ArcherWomen"))
            gameObject.GetComponent<ArcherWomen>().stop = true;

        if (transform.parent.gameObject.name.Contains("Player"))
        {
            gameObject.GetComponent<PlayerFight>().stop = true;

            GameObject[] allObjects = Object.FindObjectsOfType<GameObject>() ;

            foreach ( GameObject obj in allObjects )
            {
                if (obj.transform.parent != null)
                {

                    if (obj.transform.parent.gameObject.name.Contains("ArcherWomen"))
                        obj.GetComponent<ArcherWomen>().stop = true;

                    if (obj.transform.parent.gameObject.name.Contains("SwordMan"))
                        obj.GetComponent<SwordMan>().stop = true;

                }

                if (obj.GetComponent<RectTransform>() != null)
                {
                    if (obj.name != "DeadScreen" && obj.name != "DeadImage" && obj.name != "ResetButton" && obj.name != "Canvas" && obj.name != "ExitButton")
                    {
                        obj.SetActive(false);
                    }
                }

            } 

            DeathScreen.instance.DoDeathScreen();

        }        

    }



}
