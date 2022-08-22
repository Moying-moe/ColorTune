using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NoteTiming
{
    public float HitTime { get; private set; }
    public float HoldTime { get; private set; }

    public NoteTiming(float _hitTime)
    {
        HitTime = _hitTime;
        HoldTime = 0f;
    }

    public NoteTiming(float _hitTime, float _holdTime)
    {
        HitTime = _hitTime;
        HoldTime = _holdTime;
    }

    public float GetRelativeY(float relativeTime, float speed)
    {
        return Math.Max(-relativeTime * speed, 0f);
    }

    /// <summary>
    /// 获得Hold的总长度
    /// </summary>
    /// <param name="speed">流速</param>
    /// <returns>Hold的总长度</returns>
    public float GetHoldFullLength(float speed)
    {
        // Hold的头、尾长度为0.375
        return HoldTime * speed + 0.75f;
    }

    /// <summary>
    /// 获得Hold的当前长度
    /// </summary>
    /// <param name="relativeTime">相对时间 未到为负数 抵达为正数</param>
    /// <param name="speed">流速</param>
    /// <returns></returns>
    public float GetHoldCurLength(float relativeTime, float speed)
    {
        if (relativeTime < 0f)
        {
            // 未抵达 则长度和FullLength一致
            return GetHoldFullLength(speed);
        }
        else
        {
            // 已抵达 则减去已经经过的长度
            return GetHoldFullLength(speed) - relativeTime * speed;
        }
    }
}
