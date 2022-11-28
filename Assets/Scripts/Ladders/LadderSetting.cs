using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSetting : MonoBehaviour
{

    private void Start()
    {
        
        transform.GetChild(0).GetComponent<LadderMove>().ladder1 = transform.GetChild(1).gameObject;

        
        transform.GetChild(0).GetComponent<LadderMove>().ladder2 = transform.GetChild(2).gameObject;

        
        transform.GetChild(1).GetComponent<LadderMove>().ladder1 = transform.GetChild(0).gameObject;
        
        
        transform.GetChild(1).GetComponent<LadderMove>().ladder2 = transform.GetChild(2).gameObject;

        
        transform.GetChild(2).GetComponent<LadderMove>().ladder1 = transform.GetChild(0).gameObject;

        
        transform.GetChild(2).GetComponent<LadderMove>().ladder2 = transform.GetChild(1).gameObject;

    }

}
