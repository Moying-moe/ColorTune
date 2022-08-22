using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoSingleton<TrackManager>
{
    public TrackBehavior[] TrackBehaviors = new TrackBehavior[4];

    void Awake()
    {
        this.SetInstance(this);
    }

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            TrackBehaviors[i] = MonoSingleton<NoteLoadManager>.Instance.TrackObjects[i].GetComponent<TrackBehavior>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrackMerge(float newTrackX, float newTrackY, float newTrackRotation, float startTime, float timeLength, MergeAnimation _animation, params int[] tracks)
    {
        // TODO: merge track color
        switch (_animation)
        {
            case MergeAnimation.Ease:
                foreach (int index in tracks)
                {
                    TrackBehaviors[index-1].EaseTo(newTrackX, newTrackY, newTrackRotation, startTime, timeLength);
                }
                break;
            case MergeAnimation.Linear:
                // TODO: Linear Animation
                break;
            case MergeAnimation.Jump:
                // TODO: Animation Queue & Animation Plan
                foreach (int index in tracks)
                {
                    TrackBehaviors[index-1].JumpTo(newTrackX, newTrackY, newTrackRotation);
                }
                break;
        }
    }
}

public enum MergeAnimation
{
    Ease,
    Linear,
    Jump
}
