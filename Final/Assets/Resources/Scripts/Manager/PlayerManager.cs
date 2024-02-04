using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Singleton<PlayerManager>
{
    public float Speed { get; set; }//�ٶ�
    public float Happyness { get; set; }//����
    public float Intelligence { get; set; }//����
    public float Health { get; set; }//����
    public float Beauty { get; set; }//��ò
    public float Experience { get; set; }//����
    public float Contacts { get; set; }//����
    public Dictionary<string, GameObject> bag = BagSystem.Instance.bag;//����
}
