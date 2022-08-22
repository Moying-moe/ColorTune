using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoSingleton<DebugController>
{
    private class DebugKeyStruct
    {
        public KeyCode DebugKey { get; private set; }
        public bool IsOn { get; set; }
        public Func<bool> OnKeyDown { get; private set; }
        public Func<bool> OnKeyUp { get; private set; }

        public DebugKeyStruct(KeyCode _debugKey, Func<bool> _onKeyDown, Func<bool> _onKeyUp)
        {
            DebugKey = _debugKey;
            OnKeyDown = _onKeyDown;
            OnKeyUp = _onKeyUp;
            IsOn = false;
        }
    }

    private List<DebugKeyStruct> _debugKeyList = new List<DebugKeyStruct>();

    void Awake()
    {
        this.SetInstance(this);
    }

    void Start()
    {
        _debugKeyList.Add(new DebugKeyStruct(
            KeyCode.Space,
            this.OnCreateDebugChart,
            this.DoNothing
        ));
        _debugKeyList.Add(new DebugKeyStruct(
            KeyCode.D,
            this.OnMonoSingletonTest,
            this.DoNothing
        ));
    }

    void Update()
    {
        foreach (DebugKeyStruct keyInfo in _debugKeyList)
        {
            if (!keyInfo.IsOn && Input.GetKey(keyInfo.DebugKey))
            {
                keyInfo.IsOn = true;
                keyInfo.OnKeyDown();
            }
            else if (keyInfo.IsOn && !Input.GetKey(keyInfo.DebugKey))
            {
                keyInfo.IsOn = false;
                keyInfo.OnKeyUp();
            }
        }
    }

    private bool DoNothing()
    {
        return true;
    }

    private bool OnMonoSingletonTest()
    {
        MonoSingleton<SoundEffectManager>.Instance.PlaySE_Answer();
        return true;
    }

    public bool OnCreateDebugChart()
    {
        Singleton<GameTimeManager>.Instance.SetStartTime(Time.time + 1);

        //_noteLoader.ClearTracks();
        NoteLoadManager noteLoader = MonoSingleton<NoteLoadManager>.Instance;
        noteLoader.AddTap(new NoteTiming(0f), 1);
        noteLoader.AddHold(new NoteTiming(0f, 0.2f), 2);
        noteLoader.AddTap(new NoteTiming(0f), 3);

        noteLoader.AddHold(new NoteTiming(0.4f, 0.2f), 1);
        noteLoader.AddTap(new NoteTiming(0.4f), 2);
        noteLoader.AddTap(new NoteTiming(0.4f), 4);

        noteLoader.AddTap(new NoteTiming(0.8f), 1);
        noteLoader.AddTap(new NoteTiming(0.8f), 3);
        noteLoader.AddHold(new NoteTiming(0.8f, 0.2f), 4);

        noteLoader.AddHold(new NoteTiming(1.2f, 0.2f), 2);
        noteLoader.AddTap(new NoteTiming(1.2f), 3);
        noteLoader.AddTap(new NoteTiming(1.2f), 4);

        //noteLoader.AddHold(new NoteTiming(0.8f, 1f), 1);
        //noteLoader.AddHold(new NoteTiming(0.8f, 1f), 2);
        //noteLoader.AddHold(new NoteTiming(0.8f, 1f), 3);
        //noteLoader.AddHold(new NoteTiming(0.8f, 1f), 4);

        for (int i = 32; i <= 52; i++) 
        {
            noteLoader.AddTouch(new NoteTiming(i / 20f), i%4+1);
        }


        TrackManager trackManager = MonoSingleton<TrackManager>.Instance;
        for (int i=0; i<4; i++)
        {
            trackManager.TrackBehaviors[i].JumpTo(-3 + i*2f, -4, 0);
        }

        MonoSingleton<TrackManager>.Instance.TrackMerge(0, 4, -180, 1.4f, 0.2f, MergeAnimation.Ease, 1, 2, 3, 4);

        return true;
    }
}
