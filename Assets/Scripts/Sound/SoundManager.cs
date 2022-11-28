using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    #region Singleton

    public static SoundManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public AudioSource SlashSound;
    public AudioSource ArrowSound;

}
