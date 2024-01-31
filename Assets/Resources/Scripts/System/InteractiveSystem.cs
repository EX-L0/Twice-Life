using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveSystem : Singleton<InteractiveSystem>
{
    public void Get(string name)//�ռ�
    {
        BagSystem.Instance.Get(name);
    }

    public void Submit(string name)//�ύ
    {
        BagSystem.Instance.Submit(name);
    }

    public void LoadScene(string name)//���س���
    {
        ScenesManager.Instance.LoadScene(name);
    }

    public void Talk(string path)//��ʼ�Ի�
    {
        UIManager.Instance.OpenTalkUI();
        TalkSystem.Instance.Init(path);
    }
}
