using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMove : MonoBehaviour
{

    private int MovePos = 0;
    private Vector3 move;
    private float t1;
    private Vector3 vel = Vector3.forward;
    private Vector3 _vel = -Vector3.back;

    private int RotatePos = 0;
    private float rotate;
    private float t;
    private float Lastrotate;

    void LateUpdate()
    {

        if (MovePos == 0)
        {
            move = Vector3.SmoothDamp(transform.position,transform.position + new Vector3( 0, 0, 0.5f ), ref vel, 2.0f);

            transform.position = move;

            if (transform.position.z >= 0.5f)
            {
                MovePos = 1;
            }

        }
        else if (MovePos == 1)
        {
            move = Vector3.SmoothDamp(transform.position,transform.position + new Vector3( 0, 0, -0.5f ), ref _vel, 2.0f);

            transform.position = move;

            if (transform.position.z <= 0f)
            {
                MovePos = 0;
            }            
        }

        if (RotatePos == 0)
        {
            rotate = Mathf.Lerp(0,5,t);
            t += 0.25f * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(rotate,Vector3.right);
            if (rotate >= 5)
            {
                RotatePos = 1;
                print("1");
                t = 0;
                Lastrotate = rotate;
            }           
        }
        else if (RotatePos == 1)
        {   
            rotate = Mathf.Lerp(0,5,t);
            t += 0.25f * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(-Lastrotate+rotate,Vector3.left);   

            if (rotate >= 5)
            {
                RotatePos = 0;
                print("0");
                t = 0;
                Lastrotate = rotate;
            }         
        }

    }

}
