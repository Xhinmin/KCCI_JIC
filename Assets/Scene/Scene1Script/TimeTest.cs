﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeTest : MonoBehaviour
{

    public float f_GameTime, AllWordTime;
    public GUIStyle StartCount, TimeCounter;

    public int SWdown, SWup, SHdown, SHup, WordW, WordH;
    public int GSWdown, GSWup, GSHdown, GSHup, GWordW, GWordH;
    public int TSWdown, TSWup, TSHdown, TSHup, TWordW, TWordH;

    public GameObject G_WordCreat;

    public bool AllWord = false;
    //  private List<int> saveList = new List<int>();

    // Use this for initialization
    void Start()
    {
        f_GameTime = 66;

    }

    void OnGUI()
    {
        if (AllWord == true)
        {
            if (AllWordTime > 3)
            {
                GUI.Label(new Rect(Screen.width * TSWup / TSWdown, Screen.height * TSHup / TSHdown, TWordW, TWordH), Mathf.Floor(f_GameTime).ToString("00"), TimeCounter);
                TimeCounter.fontSize = Screen.height * TWordH / TWordW;
            }
            else
            {
                GUI.Label(new Rect(Screen.width * TSWup / TSWdown, Screen.height * TSHup / TSHdown, TWordW, TWordH), Mathf.Floor(f_GameTime).ToString("00"), TimeCounter);
                TimeCounter.fontSize = Screen.height * TWordH / TWordW;
            }
        }
        else
        {
            if (f_GameTime <= -3)
            {
                GUI.Label(new Rect(Screen.width * TSWup / TSWdown, Screen.height * TSHup / TSHdown, TWordW, TWordH), "00", TimeCounter);
                TimeCounter.fontSize = Screen.height * TWordH / TWordW;
            }
            else if (f_GameTime <= 0)
            {
                GUI.Label(new Rect(Screen.width * TSWup / TSWdown, Screen.height * TSHup / TSHdown, TWordW, TWordH), "00", TimeCounter);
                GUI.Label(new Rect(Screen.width * GSWup / GSWdown, Screen.height * GSHup / GSHdown, GWordW, GWordH), "TIME  OUT", StartCount);
                TimeCounter.fontSize = Screen.height * TWordH / TWordW;
            }
            else if (f_GameTime <= 60)
            {
                GUI.Label(new Rect(Screen.width * TSWup / TSWdown, Screen.height * TSHup / TSHdown, TWordW, TWordH), Mathf.Floor(f_GameTime).ToString("00"), TimeCounter);
                TimeCounter.fontSize = Screen.height * TWordH / TWordW;

                G_WordCreat.SetActive(true);
            }
            else if (f_GameTime <= 61)
            {
                GUI.Label(new Rect(Screen.width * GSWup / GSWdown, Screen.height * GSHup / GSHdown, GWordW, GWordH), "  START  ", StartCount);
                StartCount.fontSize = Screen.height * GWordH / GWordW;
            }
            else if (f_GameTime <= 64)
            {
                GUI.Label(new Rect(Screen.width * SWup / SWdown, Screen.height * SHup / SHdown, WordW, WordH), Mathf.Floor((f_GameTime - 60)).ToString("0"), StartCount);
                StartCount.fontSize = Screen.height * WordH / WordW;
            }
        }



    }


    // Update is called once per frame
    void Update()
    {
        if (AllWord != true)
        {

            f_GameTime -= Time.deltaTime;
        }
        else
        {

            AllWordTime += Time.deltaTime;
        }


    }
}