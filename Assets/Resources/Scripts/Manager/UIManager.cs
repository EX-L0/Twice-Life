using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public Text chacactername;//����
    public Text talkStr;//�Ի�
    public GameObject talkUI;//�Ի�����
    public GameObject[] eventTalkUI;//��֧����
    public Text[] eventTalkText;//��֧����
    public GameObject[] cannotDestroy;//���ϵͳΨһ������

    public void UpdateName(string name)//��������
    {
        this.chacactername.text = name;
    }

    public void UpdateTalkStr(string talkStr)//���¶Ի�
    {
        this.talkStr.text = talkStr;
    }

    public void CloseTalkUI()//�رնԻ�����
    {
        talkUI.SetActive(false);
    }

    public void OpenTalkUI()//�򿪶Ի�����
    {
        talkUI.SetActive(true);
    }

    public void UpdateEventTalk(string[] eventTalk)//���·�֧ѡ��
    {
        CloseTalkUI();
        for (int i = 0; i < eventTalk.Length; i++)
        {
            eventTalkUI[i].SetActive(true);
            eventTalkText[i].text = eventTalk[i];
        }
    }

    public void OpenBag()//�¼�2���򿪱���
    {
        CloseTalkUI();
        Debug.Log("�򿪱���");
    }

    public void LoadNext()//������һ������
    {
        TalkSystem.Instance.LoadNext();
    }

    public void UpdateTalk(int index)//��֧ѡ��������һ�ξ���
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
        DontDestroyOnLoad(cannotDestroy[0]);//�����л�������ϵͳ
        DontDestroyOnLoad(cannotDestroy[1]);
    }
}
