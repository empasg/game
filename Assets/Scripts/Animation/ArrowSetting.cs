using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowSetting : MonoBehaviour
{  

    public GameObject Hand;
    public GameObject Arrow;

    public GameObject Player;

    private bool ArrowTransform;
    private bool ArrowShot;
    private Vector3 vel;
    private Vector3 EndPos;
    Dictionary<Object,float> newHitEffects = new Dictionary<Object,float>();
    [SerializeField] private GameObject HitEffect;

    public void GrabArrow()
    {
        ArrowTransform = true;
    }
    private void Awake()
    {
        HitEffect.SetActive(false);

    }
    private void Update()
    {

        if (ArrowTransform)
        {

            Arrow.transform.position = Hand.transform.position + Arrow.transform.forward * 0.175f;

        }

        if (ArrowShot)
        {
            Vector3 SmoothPos = Vector3.SmoothDamp(Arrow.transform.position, EndPos, ref vel, 0.1f );

            Arrow.transform.position = SmoothPos;
            
            if (Vector3.Distance(Arrow.transform.position, EndPos) <= 0.025f)
            {
                ArrowShot = false;
                
                Arrow.transform.position = transform.position - new Vector3(0,1.4f,0);

                DoHitEffect();
            }

        }

    }

    void DoHitEffect()
    {
        var newHitEffect = Instantiate(HitEffect,EndPos,Quaternion.identity) as GameObject;
        Destroy(newHitEffect,0.4f);

        newHitEffect.SetActive(true);

    }

    public void ReleaseArrow()
    {
        ArrowTransform = false;
        ArrowShot = true;
        EndPos = Player.transform.position + new Vector3(0,Random.Range(0.85f,1.4f),0);
    }

}
