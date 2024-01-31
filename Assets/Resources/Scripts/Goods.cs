using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goods : MonoBehaviour
{
    public int kind;//��Ʒ����:1-�ռ���    2-���س���  3-��ʼ�Ի�
    public string sceneName;//��Ҫ���صĳ�������
    public string path;//�Ի���·��

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
