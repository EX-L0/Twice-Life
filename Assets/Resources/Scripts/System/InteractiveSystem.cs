using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveSystem : Singleton<InteractiveSystem>
{
    public void Get(string name)//收集
    {
        BagSystem.Instance.Get(name);
    }

    public void Submit(string name)//提交
    {
        BagSystem.Instance.Submit(name);
    }

    public void LoadScene(string name)//加载场景
    {
        ScenesManager.Instance.LoadScene(name);
    }

    public void Talk(string path)//开始对话
    {
        UIManager.Instance.OpenTalkUI();
        TalkSystem.Instance.Init(path);
    }
}
