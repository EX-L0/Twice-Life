using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagSystem : MonoSingleton<BagSystem>
{
    public Dictionary<string, GameObject> bag = new Dictionary<string, GameObject>();//背包
    public GameObject[] gameobjects;//背包里所有的物品

    public void InitBag()//初始化背包
    {
        for (int i = 0; i < gameobjects.Length; i++)
        {
            bag.Add(gameobjects[i].name, gameobjects[i]);
        }
    }

    public void Get(string name)//得到某样物品 
    {
        foreach (var item in bag)
        {
            if (item.Key == name)
                item.Value.SetActive(true);
        }
    }

    public bool Submit(string name)//提交某样物品
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
