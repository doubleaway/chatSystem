using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questName;
    //����Ʈ�� ����ִ� npc ���̵�
    public int[] npcId;


    public QuestData(string name,int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}
