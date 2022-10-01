using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class srcPlayMoonquake : MonoBehaviour
{
    public Slider timeLine;
    public GameObject moon;
    public List<Moonquake> mks = new List<Moonquake>();
    public GameObject apollo11, apollo12, apollo14, apollo15, apollo16;

    // Start is called before the first frame update
    void Start()
    {
        setDefaultMoonquakes();
        timeLine.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValueChangeCheck()
    {
        apollo11.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        apollo12.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        apollo14.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        apollo15.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        apollo16.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        if (timeLine.value != -1)
        {
            Debug.Log(mks[(int)timeLine.value].name);
            switch (mks[(int)timeLine.value].apollo)
            {
                case 11:
                    apollo11.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    break;
                case 12:
                    apollo12.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    break;
                case 14:
                    apollo14.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    break;
                case 15:
                    apollo15.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    break;
                case 16:
                    apollo16.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    break;
            }
            moon.GetComponent<Animator>().Play("LunaTiembla");
        }
    }

    public void setDefaultMoonquakes()
    {
        Moonquake m1 = new Moonquake(0, "prueba1", 11, Convert.ToDateTime("01/01/1900"), 0);
        mks.Add(m1);
        Moonquake m2 = new Moonquake(1, "prueba2", 12, Convert.ToDateTime("02/01/1900"), 0);
        mks.Add(m2);
        Moonquake m3 = new Moonquake(2, "prueba3", 14, Convert.ToDateTime("01/01/1905"), 0);
        mks.Add(m3);
        Moonquake m4 = new Moonquake(3, "prueba4", 15, Convert.ToDateTime("01/01/1800"), 0);
        mks.Add(m4);
        orderMksByDate();
    }

    public void orderMksByDate()
    {
        mks = mks.OrderBy(m => m.date).ToList();
    }
}
