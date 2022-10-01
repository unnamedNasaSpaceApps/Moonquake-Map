using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonquake : MonoBehaviour
{
    public int id { get; set; }
    public string name { get; set; }
    public int apollo { get; set; }
    public DateTime date { get; set; }
    public float intensity { get; set; }

    public Moonquake(int id, string name, int apollo, DateTime date, float intensity)
    {
        this.id = id;
        this.name = name;
        this.apollo = apollo;
        this.date = date;
        this.intensity = intensity;
    }
}
