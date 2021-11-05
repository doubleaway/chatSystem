using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkManager : MonoBehaviour
{
    
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitaArr;
     void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?:0", "���� ��¾���̾�?:2","���� �����ð��� ��ٸ��� ����:1" });
        talkData.Add(100, new string[] { "����� �������ڴ�.", "�⸧ ������ ����." });


        //�ʻ�ȭ
        portraitData.Add(1000 + 0, portraitaArr[0]);
        portraitData.Add(1000 + 1, portraitaArr[1]);
        portraitData.Add(1000 + 2, portraitaArr[2]);
        portraitData.Add(1000 + 3, portraitaArr[3]);
    }
    public string GetTalk(int id,int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
        return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id,int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
