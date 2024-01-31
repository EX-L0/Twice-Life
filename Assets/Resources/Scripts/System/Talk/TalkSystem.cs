using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TalkSystem : Singleton<TalkSystem>
{
    public Dictionary<int, TalkData> talkDic = null;//������������������ֳɶ��������
    int index;//��ǰ�����ľ���������

    public void LoadNext()//������һ������
    {
        index++;
        if (index > talkDic.Count)
        {
            UIManager.Instance.CloseTalkUI();
            return;
        }
        TalkData talk = talkDic[index];
      
        switch (talk.Event)//�¼���1-��֧�Ի�
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

        if (talk.Name != null)//��������
        {
            UIManager.Instance.UpdateName(talk.Name);
        }

        if (talk.TalkStr != null)//���¶Ի�
        {
            UIManager.Instance.UpdateTalkStr(talk.TalkStr);
        }
    }

   public void Init(string path)//���籾��ֵ
    {
        index = 0;
        string json = File.ReadAllText(path);
        talkDic = JsonConvert.DeserializeObject<Dictionary<int, TalkData>>(json);
        LoadNext();
    }

    public void UpdateTalk(int index)//��֧������һ���籾
    {
        Init("Screenplay/" + talkDic[this.index + index].NextPath+".txt");
    }
}
