using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [HideInInspector] public bool BlockIsActive = false;

    [SerializeField] private Animator _animator;

    private void Start()
    {

        if (_animator == null)
        {
            Debug.LogError("Can't find animator");
        }

    }

    public void PlayerBlock(bool bb)
    {

        _animator.SetBool("IsBlock",bb);

        BlockIsActive = bb;

    }

}
