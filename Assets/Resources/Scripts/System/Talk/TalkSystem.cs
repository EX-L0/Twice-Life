using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TalkSystem : Singleton<TalkSystem>
{
    public Dictionary<int, TalkData> talkDic = null;//把整个剧情根据索引分成多个剧情条
    int index;//当前读到的剧情条索引

    public void LoadNext()//加载下一条剧情
    {
        index++;
        if (index > talkDic.Count)
        {
            UIManager.Instance.CloseTalkUI();
            return;
        }
        TalkData talk = talkDic[index];
      
        switch (talk.Event)//事件：1-分支对话
        {
            case 1:
                string[] eventTalk = new string[talkDic.Count - index];
                for (int i = 0; i < eventTalk.Length; i++)
                {
                    eventTalk[i] = talkDic[++index].EventTalk;
                }
                index -= eventTalk.Length;
                UIManager.Instance.UpdateEventTalk(eventTalk);
                break;
            case 2:
                UIManager.Instance.OpenBag();
                break;
        }

        if (talk.Name != null)//更新名字
        {
            UIManager.Instance.UpdateName(talk.Name);
        }

        if (talk.TalkStr != null)//更新对话
        {
            UIManager.Instance.UpdateTalkStr(talk.TalkStr);
        }
    }

   public void Init(string path)//给剧本赋值
    {
        index = 0;
        string json = File.ReadAllText(path);
        talkDic = JsonConvert.DeserializeObject<Dictionary<int, TalkData>>(json);
        LoadNext();
    }

    public void UpdateTalk(int index)//分支跳到下一个剧本
    {
        Init("Screenplay/" + talkDic[this.index + index].NextPath+".txt");
    }
}
