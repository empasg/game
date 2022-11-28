using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.3f;
    public float smoothSpeedRotation = 1f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    
    private void LateUpdate() {
                        
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, Vector3.MoveTowards(transform.position, target.transform.position - target.forward * 5 + new Vector3 (0,offset[1],0) , 5), ref velocity, smoothSpeed);     

        transform.position = smoothPos;



       Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothSpeedRotation * Time.deltaTime );

       transform.rotation = smoothedRotation ;

    }
}
