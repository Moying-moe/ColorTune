using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoSingleton<SoundEffectManager>
{
    public AudioSource SE_Answer;

    // Start is called before the first frame update
    void Awake()
    {
        this.SetInstance(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySE_Answer()
    {
        SE_Answer.Play();
    }
}
