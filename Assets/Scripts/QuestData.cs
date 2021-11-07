using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questName;
    //퀘스트랑 상관있는 npc 아이디
    public int[] npcId;


    public QuestData(string name,int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}
