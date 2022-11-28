using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingStats : MonoBehaviour
{

    #region Singleton

    public static GeneratingStats instance;

    void Awake()
    {
        instance = this;
    }
    #endregion 

    public int MaxSpawnPlatforms = 10;
    
    public int SpawnedPlatforms = 0;    

}
