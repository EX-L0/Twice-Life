using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour
{
    public float timer;//��Ϸʱ��������ʱ��Ĺ̶�����
    float currentTimer;//��Ϸʱ��������ʱ��ĵ�ǰ����
    float time;//��ʱ��
    private int minute;//��ʾ��ǰ����
    private int hour;//��ʾ��ǰ��ʱ
    public Text timeUI;//�����е�ʱ��ui

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

    void TimePass()//������ģ��ʱ�������
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

    void UpdateTime()//����ʱ���ui��ʾ
    {
        timeUI.text = string.Format((hour >= 10 ? hour.ToString() : ("0" + hour)) + ":" + (minute >= 10 ? minute.ToString() : ("0" + minute)));
    }

    public void ChangeTimer(float newTimer)//�ı������0������ͣ��1�������������Ϊ�ı�ʱ������
    {
        currentTimer = timer * newTimer;
    }

    public void AddTime(int hour, int minute)//����һ��ʱ��
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

    private void ChangeDayOrNight()//��ʵ���ξ����л�
    {
        if (hour == 7)
            ScenesManager.Instance.LoadScene("Day");
        if (hour == 20)
            ScenesManager.Instance.LoadScene("Night");
    }
}
