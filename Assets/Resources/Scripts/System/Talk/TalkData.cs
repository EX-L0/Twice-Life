using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkData : MonoBehaviour
{
    //对话剧本属性
    public int ID { get; set; }//id
    public string Name { get; set; }//角色名字
    public string TalkStr { get; set; }//当前角色对话内容
    public int Event { get; set; }//事件
    public string  EventTalk { get; set; }//分支选项
    public string  NextPath { get; set; }//下一个剧本的文件目录
}
