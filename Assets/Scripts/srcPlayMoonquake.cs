using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Math = System.Math;

public class srcPlayMoonquake : MonoBehaviour
{
    public Slider timeLine;
    public GameObject moon;
    public Text txtLat, txtLon, txtLocation, txtStartTime, txtScale, txtScaleFreq, txtEndTime;
    public Transform marker;
    public List<Moonquake> mks = new List<Moonquake>();
    public GameObject apollo11, apollo12, apollo14, apollo15, apollo16;

    // Start is called before the first frame update
    void Start()
    {
        setDefaultMoonquakes();
        timeLine.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        /*string[] prueba = readFromFile("Assets/list.txt");
        Moonquake m = lineToMoonquake('|', prueba[5]);
        Debug.Log(m.location);*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ValueChangeCheck()
    {
        txtLat.text = "";
        txtLon.text = "";
        txtEndTime.text = "";
        txtScale.text = "";
        txtScaleFreq.text = "";
        txtStartTime.text = "";
        marker.position = new Vector3(1f, 1f, 1f);
        apollo11.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        apollo12.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        apollo14.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        apollo15.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        apollo16.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        if (timeLine.value != -1)
        {
            switch ((string)mks[(int)timeLine.value].location)
            {
                case "S11":
                    apollo11.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    break;
                case "S12":
                    apollo12.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    break;
                case "S14":
                    apollo14.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    break;
                case "S15":
                    apollo15.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    break;
                case "S16":
                    apollo16.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    break;
            }
            txtLat.text = "Lat: " + Convert.ToString(mks[(int)timeLine.value].latitude) + "°";
            txtLon.text = "Lon: " + Convert.ToString(mks[(int)timeLine.value].longitude) + "°";
            txtEndTime.text = "End: " + Convert.ToString(mks[(int)timeLine.value].endTime);
            txtScale.text = "Scale: " + Convert.ToString(mks[(int)timeLine.value].scale) + "M";
            txtScaleFreq.text = "Scale Freq: " + Convert.ToString(mks[(int)timeLine.value].scaleFreq) + "mHz";
            txtStartTime.text = "Start: " + Convert.ToString(mks[(int)timeLine.value].startTime);
            marker.position = coordinateToPoint(mks[(int)timeLine.value].latitude, mks[(int)timeLine.value].longitude, 20);
            setRadiusMoonquake(mks[(int)timeLine.value].scale);
            moon.GetComponent<Animator>().Play("LunaTiembla");
        }
    }

    public void setDefaultMoonquakes()
    {
        //string[] lines = readFromFile("Assets/list.txt");
        string[] lines = readFromInternalScript();
        for(int i = 3; i < lines.Count(); i++)
        {
            string line = lines[i];
            lineToMoonquake('|', line);
        }
    }

    public void setRadiusMoonquake(float scale)
    {
        float newScale = scale / 1E9f;
        if (scale > 1)
        {
            marker.localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    public void createMoonquake(string location, float latitude, float longitude, float scale, float scaleFreq, DateTime startTime, DateTime endTime)
    {
        Moonquake m = new Moonquake(location, latitude, longitude, scale, scaleFreq, startTime, endTime);
        mks.Add(m);
        orderMksByDate();
        timeLine.maxValue += 1;
    }

    public void orderMksByDate()
    {
        mks = mks.OrderBy(m => m.startTime).ToList();
    }

    public Vector3 coordinateToPoint(float latitude, float longitude, float radius)
    {
        latitude = Mathf.PI * latitude / 180;
        longitude = Mathf.PI * longitude / 180;

        // adjust position by radians	
        latitude -= 1.570795765134f; // subtract 90 degrees (in radians)

        // and switch z and y (since z is forward)
        float xPos = (radius) * Mathf.Sin(latitude) * Mathf.Cos(longitude);
        float zPos = (radius) * Mathf.Sin(latitude) * Mathf.Sin(longitude);
        float yPos = (radius) * Mathf.Cos(latitude);

        // move marker to position
        Vector3 coordinates = new Vector3((float)xPos, (float)yPos, (float)zPos);
        return coordinates;
    }

/******************************************************************************************/
    private string[] readFromFile(string pathFile)
    {
        string[] lines = System.IO.File.ReadAllLines(pathFile);
        return lines;
    }

    private string[] readFromInternalScript()
    {
        DataBase db = new DataBase();
        string[] lines = db.database.Split('\n');
        return lines;
    }

    private void lineToMoonquake(char splitter, string line)
    {
        string[] subs = line.Split(splitter);
        string location = "";
        float latitude = 0;
        float longitude = 0;
        float scale = 0;
        float scaleFreq = 0;
        DateTime start = DateTime.Now;
        DateTime end = DateTime.Now;
        if (subs[1] != "")
            location = subs[1];
        if (subs[4] != "")
            latitude = (float)Convert.ToDouble(subs[4]);
        if (subs[5] != "")
            longitude = (float)Convert.ToDouble(subs[5]);
        if (subs[11] != "")
            scale = (float)Convert.ToDouble(subs[11]);
        Debug.Log("a");
        if (subs[12] != "")
            scaleFreq = (float)Convert.ToDouble(subs[12]);

        /*********************/
        if (subs[15] != "")
        {
            string[] arrStartDateTime = subs[15].Split('T');
            string strStartDate = arrStartDateTime[0];
            string[] arrStartSeparatedDate = strStartDate.Split('-');
            int year = Convert.ToInt32(arrStartSeparatedDate[0]);
            int month = Convert.ToInt32(arrStartSeparatedDate[1]);
            int day = Convert.ToInt32(arrStartSeparatedDate[2]);
            string strStartTime = arrStartDateTime[1];
            string[] arrStartSeparatedTime = strStartTime.Split(':');
            int hour = Convert.ToInt32(arrStartSeparatedTime[0]);
            int minute = Convert.ToInt32(arrStartSeparatedTime[1]);
            int second = Convert.ToInt32(arrStartSeparatedTime[2]);
            start = new DateTime(year, month, day, hour, minute, second);
        }
        /*********************/

        /*********************/
        if (subs[16] != "")
        {
            string[] arrEndDateTime = subs[16].Split('T');
            string strEndDate = arrEndDateTime[0];
            string[] arrEndSeparatedDate = strEndDate.Split('-');
            int year = Convert.ToInt32(arrEndSeparatedDate[0]);
            int month = Convert.ToInt32(arrEndSeparatedDate[1]);
            int day = Convert.ToInt32(arrEndSeparatedDate[2]);
            string strEndTime = arrEndDateTime[1];
            string[] arrEndSeparatedTime = strEndTime.Split(':');
            int hour = Convert.ToInt32(arrEndSeparatedTime[0]);
            int minute = Convert.ToInt32(arrEndSeparatedTime[1]);
            int second = Convert.ToInt32(arrEndSeparatedTime[2]);
            end = new DateTime(year, month, day, hour, minute, second);
        }
        /*********************/

        createMoonquake(location, latitude, longitude, scale, scaleFreq, start, end);
    }
/******************************************************************************************/
}
