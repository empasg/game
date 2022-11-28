using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{

    public GameObject Player;

    private bool CanStartFight = false;

    private void Start()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player").transform.GetChild(0).gameObject;
        }     
        foreach (Transform child in transform.parent)
        {
            if (child.gameObject.name.Contains("SwordMan"))
                CanStartFight = true;
            else if (child.gameObject.name.Contains("ArcherWomen"))
                CanStartFight = true;
        } 
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject == Player && CanStartFight)
        {
            
            foreach (Transform child in transform.parent)
            {
                if (child.gameObject.name.Contains("SwordMan"))
                    child.GetChild(0).GetComponent<SwordMan>().StartFight();
                else if (child.gameObject.name.Contains("ArcherWomen"))
                    child.GetChild(0).GetComponent<ArcherWomen>().StartFight();
            }
            Player.GetComponent<PlayerFight>().StartFight();
            CanStartFight = false;
        }
    
    }

}
