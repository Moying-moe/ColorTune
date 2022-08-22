/*
  Copyright (c) Moying-moe All rights reserved. Licensed under the MIT license.
  See LICENSE in the project root for license information.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBehavior : MonoBehaviour
{
    // 在editor中设置的public属性
    public SpriteRenderer Renderer;

    // 普通的public属性
    public NoteColor Color { get; private set; }
    public NoteTiming Timing { get; private set; }

    private const float SPEED = 14f;
    private const float START_Y = 9.4f;
    private const float END_Y = -0.4f;

    private bool _onScreen;
    private bool _headSEPlayed;


    // Start is called before the first frame update
    void Start()
    {
        _onScreen = false;
        _headSEPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        float curSec = Singleton<GameTimeManager>.Instance.CurSec;

        float relativeTime = curSec - Timing.HitTime;
        float tailRelativeTime = relativeTime - Timing.HoldTime;

        if (tailRelativeTime >= 0f)
        {
            // 已到达判定线
            MonoSingleton<SoundEffectManager>.Instance.PlaySE_Answer();

            Destroy(gameObject);
            Destroy(this);
            return;
        }

        if (!_headSEPlayed && relativeTime >= 0f)
        {
            // 头部音效
            _headSEPlayed = true;
            MonoSingleton<SoundEffectManager>.Instance.PlaySE_Answer();
        }

        float showTime = (END_Y - START_Y) / SPEED;
        if (relativeTime <= showTime && !_onScreen)
        {
            _onScreen = true;
            Renderer.color = new Color(1f, 1f, 1f, 1f);
        }

        if (_onScreen)
        {
            Renderer.size = new Vector2(0.75f, Timing.GetHoldCurLength(relativeTime, SPEED));
            float curY = END_Y + Timing.GetRelativeY(relativeTime, SPEED);
            transform.localPosition = new Vector3(0f, curY);
        }
    }

    /// <summary>
    /// 初始化note
    /// </summary>
    /// <param name="_timing">note的击打时机</param>
    /// <param name="_color">note的颜色</param>
    public void Init(NoteTiming _timing, NoteColor _color)
    {
        transform.localPosition = new Vector3(0, START_Y);
        Renderer.color = new Color(1f, 1f, 1f, 0f);

        Timing = _timing;
        Color = _color;
        this.ApplyNoteStyle();

        _onScreen = false;
    }

    /// <summary>
    /// 更改Note的外观
    /// </summary>
    private void ApplyNoteStyle()
    {
        if (!this.Color.IsValid())
        {
            return;
        }

        Renderer.sprite = Singleton<NoteStyleManager>.Instance.HoldSprite[this.Color];
    }
}
