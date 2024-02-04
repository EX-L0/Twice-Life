using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour
{
    public float timer;//游戏时间与世界时间的固定比例
    float currentTimer;//游戏时间与世界时间的当前比例
    float time;//计时器
    private int minute;//显示当前几分
    private int hour;//显示当前几时
    public Text timeUI;//场景中的时间ui

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        TimePass();
    }

    void TimePass()//计数器模拟时间的流逝
    {
        time += Time.deltaTime * currentTimer;
        if (time >= 60)
        {
            time = 0;
            minute++;
            if (minute >= 60)
            {
                minute = 0;
                hour++;
                ChangeDayOrNight();
                if (hour >= 24)
                {
                    hour = 0;
                }
            }
            UpdateTime();
        }
    }

    void UpdateTime()//更新时间的ui显示
    {
        timeUI.text = string.Format((hour >= 10 ? hour.ToString() : ("0" + hour)) + ":" + (minute >= 10 ? minute.ToString() : ("0" + minute)));
    }

    public void ChangeTimer(float newTimer)//改变比例，0代表暂停，1代表继续，其余为改变时间流速
    {
        currentTimer = timer * newTimer;
    }

    public void AddTime(int hour, int minute)//跳过一段时间
    {
        this.minute += minute;
        Debug.Log(this.minute);
        Debug.Log(25/60);
        if (this.hour >= 7 && this.hour < 20)
        {
            this.hour += (this.minute / 60);
            this.minute %= 60;
            this.hour += hour;
            this.hour %= 24;
            if (this.hour < 7 || this.hour >= 20)
                ScenesManager.Instance.LoadScene("Night");
        }
        else
        {
            this.hour += (this.minute / 60);
            this.minute %= 60;
            this.hour += hour;
            this.hour %= 24;
            if (this.hour >= 7 && this.hour < 20)
                ScenesManager.Instance.LoadScene("Day");
        }
        UpdateTime();
    }

    private void ChangeDayOrNight()//现实与梦境的切换
    {
        if (hour == 7)
            ScenesManager.Instance.LoadScene("Day");
        if (hour == 20)
            ScenesManager.Instance.LoadScene("Night");
    }
}
