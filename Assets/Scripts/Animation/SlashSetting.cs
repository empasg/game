using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSetting : MonoBehaviour
{

    public GameObject Pos;

    [SerializeField] private GameObject Effect;   

    private void Awake()
    {
        Effect.SetActive(false);
    }

    public void Slash()
    {

        CreateEffect();

    }

    private void CreateEffect()
    {

        var newEffect = Instantiate(Effect,Pos.transform.position - Pos.transform.right * 1,Pos.transform.rotation) as GameObject;
        Destroy(newEffect,0.4f);

        newEffect.SetActive(true);

    }

}
