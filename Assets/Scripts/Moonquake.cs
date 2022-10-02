using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonquake : MonoBehaviour
{
    public string location { get; set; }
    public float latitude { get; set; }
    public float longitude { get; set; }
    public float scale { get; set; }
    public float scaleFreq { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }

    public Moonquake(string location, float latitude, float longitude, float scale, float scaleFreq, DateTime startTime, DateTime endTime)
    {
        this.location = location;
        this.latitude = latitude;
        this.longitude = longitude;
        this.scale = scale;
        this.scaleFreq = scaleFreq;
        this.startTime = startTime;
        this.endTime = endTime;
    }
}
