using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    //��ȭ ���� ����
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;


     void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }
    void GenerateData()
    {
        questList.Add(10, new QuestData("npc�� ��ȭ�ϱ�",new int[] {1000,2000}));
        questList.Add(20, new QuestData("B�� ������ֱ�",new int[] {5000,1000}));
        questList.Add(30, new QuestData("����Ʈ�Ϸ� ȣ���� ���!",new int[] {0}));

    }

    public int GetQuestTalkIndex(int id)
    {
        return questId+questActionIndex;

    }
    public string CheckQuest(int id)
    {
        //control quest object
     

        if(id==questList[questId].npcId[questActionIndex])
        questActionIndex++;

        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length)
            NextQueset();

        return questList[questId].questName;
    }


    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQueset()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
       
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
            
        }
    }
}
