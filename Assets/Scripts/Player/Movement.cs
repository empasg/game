using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;

    [SerializeField] private float rotationSpeed = 140f;

    [SerializeField] private Animator _animator;

    public float playerSpeed = 1200.0f;

    [HideInInspector] public bool Stunned;


    private void Start()
    {
        
        if (_controller == null)
        {
            Debug.LogError("No CharacterController");
        }
        
        if (_animator == null)
        {
            Debug.LogError("Can't find animator");
        }
        
        
    }
    void Update()
    {

        if (Stunned)
        {
            return; 
        }

        float translation = Input.GetAxis("Vertical") * playerSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        _animator.SetFloat("MovementSpeed",translation);

        if (rotation != 0 && translation == 0)
        {
            _animator.SetBool("IsRotate",true);
        }
        else
        {
            _animator.SetBool("IsRotate",false);
        }

        _animator.SetFloat("RotationSpeed",Mathf.Clamp(Input.GetAxis("Horizontal"), 0, 1) );

        transform.Rotate(0, rotation, 0);        
        
    }
}
