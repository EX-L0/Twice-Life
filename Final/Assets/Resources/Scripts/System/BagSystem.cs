using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagSystem : MonoSingleton<BagSystem>
{
    public Dictionary<string, GameObject> bag = new Dictionary<string, GameObject>();//����
    public GameObject[] gameobjects;//���������е���Ʒ

    public void InitBag()//��ʼ������
    {
        for (int i = 0; i < gameobjects.Length; i++)
        {
            bag.Add(gameobjects[i].name, gameobjects[i]);
        }
    }

    public void Get(string name)//�õ�ĳ����Ʒ 
    {
        foreach (var item in bag)
        {
            if (item.Key == name)
                item.Value.SetActive(true);
        }
    }

    public bool Submit(string name)//�ύĳ����Ʒ
    {
        if (!bag.ContainsKey(name))
            return false;
        foreach (var item in bag)
        {
            if (item.Key == name)
                item.Value.SetActive(false);
        }
        return true;
    }
}
