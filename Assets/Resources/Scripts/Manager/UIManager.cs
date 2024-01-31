using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public Text chacactername;//名字
    public Text talkStr;//对话
    public GameObject talkUI;//对话界面
    public GameObject[] eventTalkUI;//分支界面
    public Text[] eventTalkText;//分支文字
    public GameObject[] cannotDestroy;//多个系统唯一不销毁

    public void UpdateName(string name)//更新名字
    {
        this.chacactername.text = name;
    }

    public void UpdateTalkStr(string talkStr)//更新对话
    {
        this.talkStr.text = talkStr;
    }

    public void CloseTalkUI()//关闭对话界面
    {
        talkUI.SetActive(false);
    }

    public void OpenTalkUI()//打开对话界面
    {
        talkUI.SetActive(true);
    }

    public void UpdateEventTalk(string[] eventTalk)//更新分支选项
    {
        CloseTalkUI();
        for (int i = 0; i < eventTalk.Length; i++)
        {
            eventTalkUI[i].SetActive(true);
            eventTalkText[i].text = eventTalk[i];
        }
    }

    public void OpenBag()//事件2，打开背包
    {
        CloseTalkUI();
        Debug.Log("打开背包");
    }

    public void LoadNext()//加载下一条剧情
    {
        TalkSystem.Instance.LoadNext();
    }

    public void UpdateTalk(int index)//分支选择后进入下一段剧情
    {
        for (int i = 0; i < eventTalkUI.Length; i++)
        {
            eventTalkUI[i].SetActive(false);
        }
        OpenTalkUI();
        TalkSystem.Instance.UpdateTalk(index);
    }

    void Start()
    {
        DontDestroyOnLoad(cannotDestroy[0]);//场景切换不销毁系统
        DontDestroyOnLoad(cannotDestroy[1]);
    }
}
