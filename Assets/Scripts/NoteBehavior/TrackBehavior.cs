using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBehavior : MonoBehaviour
{
    public float PosX { get; private set; }
    public float PosY { get; private set; }
    public float Rotation { get; private set; } // Z

    private AnimationCurve _curveX;
    private AnimationCurve _curveY;
    private AnimationCurve _curveRotation;
    private bool _inAnimation;
    private float _animationStartTime;
    private float _animationEndTime;
    private float _nextX;
    private float _nextY;
    private float _nextRotation;

    // Start is called before the first frame update
    void Start()
    {
        _inAnimation = false;
        _animationStartTime = -999f;
        _animationEndTime = -999f;
    }

    // Update is called once per frame
    void Update()
    {
        float curSec = Singleton<GameTimeManager>.Instance.CurSec;

        if (!_inAnimation && _animationStartTime <= curSec && curSec <= _animationEndTime)
        {
            // 之前不在动画中 在此帧进入了动画
            _inAnimation = true;
        }
        else if (_inAnimation && !(_animationStartTime <= curSec && curSec <= _animationEndTime))
        {
            // 之前在动画中 在此帧退出了动画
            _inAnimation = false;
            _animationStartTime = -999f;
            _animationEndTime = -999f;
            PosX = _nextX;
            PosY = _nextY;
            Rotation = _nextRotation;
        }

        if (_inAnimation)
        {
            float relativeTime = curSec - _animationStartTime;
            float curX = _curveX.Evaluate(relativeTime);
            float curY = _curveY.Evaluate(relativeTime);
            float curRotation = _curveRotation.Evaluate(relativeTime);
            transform.SetPositionAndRotation(new Vector3(curX, curY), Quaternion.Euler(new Vector3(0f, 0f, curRotation)));
        }
        else
        {
            transform.SetPositionAndRotation(new Vector3(PosX, PosY), Quaternion.Euler(new Vector3(0f, 0f, Rotation)));
        }
    }

    public void EaseTo(float newX, float newY, float newRotation, float timeLength)
    {
        this.EaseTo(newX, newY, newRotation, Singleton<GameTimeManager>.Instance.CurSec, timeLength);
    }

    public void EaseTo(float newX, float newY, float newRotation, float startTime, float timeLength)
    {
        _animationStartTime = startTime;
        _animationEndTime = _animationStartTime + timeLength;

        _curveX = AnimationCurve.EaseInOut(0f, PosX, timeLength, newX);
        _curveY = AnimationCurve.EaseInOut(0f, PosY, timeLength, newY);
        _curveRotation = AnimationCurve.EaseInOut(0f, Rotation, timeLength, newRotation);

        _nextX = newX;
        _nextY = newY;
        _nextRotation = newRotation;
    }

    public void JumpTo(float newX, float newY, float newRotation)
    {
        _inAnimation = false;
        _animationStartTime = -999f;
        _animationEndTime = -999f;
        PosX = newX;
        PosY = newY ;
        Rotation = newRotation;
    }
}
