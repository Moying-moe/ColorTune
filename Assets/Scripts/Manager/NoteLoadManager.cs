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

public class NoteLoadManager : MonoSingleton<NoteLoadManager>
{
    public GameObject[] TrackObjects;
    public GameObject TapPrefab;
    public GameObject HoldPrefab;
    public GameObject TouchPrefab;


    void Awake()
    {
        this.SetInstance(this);
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 创建一个Tap
    /// </summary>
    /// <param name="timing">note时间</param>
    /// <param name="trackId">轨道编号(from 1 to 4)</param>
    public void AddTap(NoteTiming timing, int trackId)
    {
        this.AddTap(timing, NoteColorEnum.FromTrackId(trackId));
    }

    /// <summary>
    /// 创建一个Tap
    /// </summary>
    /// <param name="timing">note时间</param>
    /// <param name="track">轨道颜色</param>
    public void AddTap(NoteTiming timing, NoteColor track)
    {
        int trackIndex = track.ToTrackId() - 1;

        GameObject tapGObject = Instantiate(TapPrefab, TrackObjects[trackIndex].transform);
        TapBehavior tapBehavior = tapGObject.GetComponent<TapBehavior>();

        tapBehavior.Init(timing, track);
    }

    /// <summary>
    /// 创建一个Hold
    /// </summary>
    /// <param name="timing">note时间</param>
    /// <param name="trackId">轨道编号(from 1 to 4)</param>
    public void AddHold(NoteTiming timing, int trackId)
    {
        this.AddHold(timing, NoteColorEnum.FromTrackId(trackId));
    }

    /// <summary>
    /// 创建一个Hold
    /// </summary>
    /// <param name="timing">note时间</param>
    /// <param name="track">轨道颜色</param>
    public void AddHold(NoteTiming timing, NoteColor track)
    {
        int trackIndex = track.ToTrackId() - 1;

        GameObject holdGObject = Instantiate(HoldPrefab, TrackObjects[trackIndex].transform);
        HoldBehavior holdBehavior = holdGObject.GetComponent<HoldBehavior>();

        holdBehavior.Init(timing, track);
    }

    /// <summary>
    /// 创建一个Touch
    /// </summary>
    /// <param name="timing">note时间</param>
    /// <param name="trackId">轨道编号(from 1 to 4)</param>
    public void AddTouch(NoteTiming timing, int trackId)
    {
        this.AddTouch(timing, NoteColorEnum.FromTrackId(trackId));
    }

    /// <summary>
    /// 创建一个Touch
    /// </summary>
    /// <param name="timing">note时间</param>
    /// <param name="track">轨道颜色</param>
    public void AddTouch(NoteTiming timing, NoteColor track)
    {
        int trackIndex = track.ToTrackId() - 1;

        GameObject touchGObject = Instantiate(TouchPrefab, TrackObjects[trackIndex].transform);
        TouchBehavior touchBehavior = touchGObject.GetComponent<TouchBehavior>();

        touchBehavior.Init(timing, track);
    }
}
