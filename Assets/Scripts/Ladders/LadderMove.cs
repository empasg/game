using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class LadderMove : MonoBehaviour
{
    public GameObject ladder1;
    public GameObject ladder2;

    [SerializeField] private GameObject Player;

    [SerializeField] private bool ladder1active = true;
    [SerializeField] private bool ladder2active = true;

    [SerializeField] private bool canActivate = true;

    private Vector3 velocity = Vector3.zero;
    private Vector3 velocity1 = Vector3.down*100;
    private Vector3 velocity2 = Vector3.down*100;
    private Vector3 velocity3 = Vector3.down*100;
    private Vector3 velocity4 = Vector3.down*100;

    private Vector3 SmoothPositon;
    private Vector3 SmoothPositon1;
    private Vector3 SmoothPositon2;
    private Vector3 SmoothPositon3;
    private Vector3 SmoothPositon4;
    private Vector3 SmoothPositon5;

    private Vector3 OpenPos;
    private Vector3 OpenPos1;
    private Vector3 OpenPos2;
    private Vector3 OpenPos3;
    private Vector3 OpenPos4;
    private Vector3 OpenPos5;

    private void Awake()
    {

        if (Player == null)
        {
            Player = GameObject.Find("Player").transform.GetChild(0).gameObject;
        }

    }

    private void SetPositions()
    {

        float zpos = 0f;
        foreach(Transform child in transform)
        {

            if (zpos == 0f)
            {
                OpenPos1 = child.position + ( child.forward+ Vector3.up/3 ) * zpos;
            }
            else if (zpos == (float)1.75f)
            {
                OpenPos2 = child.position + ( child.forward+ Vector3.up/3 ) * zpos;
            }
            else if (zpos == (float)3.5f)
            {
                OpenPos3 = child.position + ( child.forward+ Vector3.up/3 ) * zpos;
            }
            else if (zpos == (float)5.25f)
            {
                OpenPos4 = child.position + ( child.forward+ Vector3.up/3 ) * zpos;
            }

            else if (zpos == (float)7f)
            {
                OpenPos5 = child.position + ( child.forward + Vector3.up/3 ) * zpos;
            }

            zpos = zpos + 1.75f;
        }

    }

    private void LateUpdate() 
    {
        if (ladder1 != null)
        {
            ladder1active = ladder1.GetComponent<LadderMove>().canActivate;
        }
        if (ladder2 != null)
        {
            ladder2active = ladder2.GetComponent<LadderMove>().canActivate;
        }       

        if (ladder1active && ladder2active && canActivate)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position,2f);
            foreach(Collider hitCollider in hitColliders)
            {
                
                if (hitCollider.gameObject == Player)
                {
                    SetPositions();
                    canActivate = false;
                }
            }
        }
        

        if (canActivate == false)
        {

            SmoothPositon1 = Vector3.SmoothDamp(transform.GetChild(0).position,OpenPos1,ref velocity,0.1f);
            SmoothPositon2 = Vector3.SmoothDamp(transform.GetChild(1).position,OpenPos2,ref velocity1,0.2f);
            SmoothPositon3 = Vector3.SmoothDamp(transform.GetChild(2).position,OpenPos3,ref velocity2,0.3f);
            SmoothPositon4 = Vector3.SmoothDamp(transform.GetChild(3).position,OpenPos4,ref velocity3,0.4f);
            SmoothPositon5 = Vector3.SmoothDamp(transform.GetChild(4).position,OpenPos5,ref velocity4,0.5f);      

            transform.GetChild(0).position = SmoothPositon1; 
            transform.GetChild(1).position = SmoothPositon2; 
            transform.GetChild(2).position = SmoothPositon3; 
            transform.GetChild(3).position = SmoothPositon4; 
            transform.GetChild(4).position = SmoothPositon5;

        }
        
    }


}
