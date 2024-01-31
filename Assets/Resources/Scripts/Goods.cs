using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goods : MonoBehaviour
{
    public int kind;//物品种类:1-收集类    2-加载场景  3-开始对话
    public string sceneName;//需要加载的场景名称
    public string path;//对话的路径

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        if (!Input.GetKeyDown(KeyCode.E))
            return;
        switch (kind)
        {
            case 1:
                InteractiveSystem.Instance.Get(name);
                Destroy(this.gameObject);
                break;
            case 2:
                InteractiveSystem.Instance.LoadScene(sceneName);
                break;
            case 3:
                InteractiveSystem.Instance.Talk(path);
                break;
        }
    }
}
