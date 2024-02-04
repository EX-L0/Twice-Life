using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Singleton<PlayerManager>
{
    public float Speed { get; set; }//速度
    public float Happyness { get; set; }//快乐
    public float Intelligence { get; set; }//智力
    public float Health { get; set; }//体力
    public float Beauty { get; set; }//美貌
    public float Experience { get; set; }//经验
    public float Contacts { get; set; }//人脉
    public Dictionary<string, GameObject> bag = BagSystem.Instance.bag;//背包
}
