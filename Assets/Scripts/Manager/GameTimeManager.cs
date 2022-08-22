/*
  Copyright (c) Moying-moe All rights reserved. Licensed under the MIT license.
  See LICENSE in the project root for license information.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameTimeManager : Singleton<GameTimeManager>
{
    public float StartTime { get; private set; }
    public float CurSec
    {
        get
        {
            return Time.time - StartTime;
        }
    }
    public float CurMsec
    {
        get
        {
            return CurSec * 1000f;
        }
    }

    /// <summary>
    /// 设置谱面开始时间
    /// </summary>
    /// <param name="_startTime">开始时间(Depend on UnityEngine.Time.time)</param>
    public void SetStartTime(float _startTime)
    {
        StartTime = _startTime;
    }

    /// <summary>
    /// 将谱面开始时间设为现在
    /// </summary>
    public void SetStartTime()
    {
        this.SetStartTime(Time.time);
    }
}
