using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkData : MonoBehaviour
{
    //�Ի��籾����
    public int ID { get; set; }//id
    public string Name { get; set; }//��ɫ����
    public string TalkStr { get; set; }//��ǰ��ɫ�Ի�����
    public int Event { get; set; }//�¼�
    public string  EventTalk { get; set; }//��֧ѡ��
    public string  NextPath { get; set; }//��һ���籾���ļ�Ŀ¼
}
