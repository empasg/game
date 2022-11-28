using UnityEngine;

public class NameMove : MonoBehaviour
{

    private int MovePos = 0;
    private Vector3 move;
    private float t1;
    private Vector3 vel = Vector3.forward;

    private float r1;
    private float r2;

    private void Start()
    {

        r1 = Random.Range(0.1f,0.35f);
        r2 = Random.Range(0.1f,0.35f);  

    }

    private void LateUpdate()
    {

        if (MovePos == 0)
        {
            move = Vector3.SmoothDamp(transform.position,transform.position + new Vector3( 0, 0, r1 ), ref vel, 2.0f);

            transform.position = Vector3.Min(transform.position,move);

            if (transform.position.z >= r1)
            {
                MovePos = 1;
            }

        }
        else if (MovePos == 1)
        {
            move = Vector3.SmoothDamp(transform.position,transform.position - new Vector3( 0, 0, r1 ), ref vel, 2.0f);

            transform.position = Vector3.Min(transform.position,move);

            if (transform.position.z >= r1)
            {
                MovePos = 0;
                r1 = Random.Range(0.1f,0.35f);
            }            
        }

    }

}
