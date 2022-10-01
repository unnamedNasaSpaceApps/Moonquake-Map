using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonquakes : MonoBehaviour
{
    public int id { get; set; }
    public int apolo { get; set; }
    public DateTime date { get; set; }
    public float intensity { get; set; }

    public moonquakes(int id, int apolo, DateTime date, float intensity)
    {
        this.id = id;
        this.apolo = apolo;
        this.date = date;
        this.intensity = intensity;
    }
}
