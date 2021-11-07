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
        talkData.Add(1000, new string[] { "�ȳ�?:0", "��¾���̾�?:2","�ʿ��ѰŶ� �־�?:1" });
        talkData.Add(2000, new string[] { "�� ������?:1", "�츮 ������ �°� ȯ����! �ѹۿ� �����µ� ���ο� ����� ���� ����!:0" });
        talkData.Add(100, new string[] { "����� �������ڴ�.", "��� ���� ������ ����. ." });

        //quest talk
       talkData.Add(10 + 1000, new string[] { "� ��, �� ��Ź �ϳ� ����� �� �־�?:0", "������ �Ҿ���Ⱦ�:2", "B�� ���������� ���� �־��µ�.. �������� ���� �׳డ �����ž� :1","�ѹ� ������ٷ�?:0" });
       talkData.Add(11 + 2000, new string[] { "��? �������־�?:0", "��? �¾� ���� �������־���, ȥ�� �ɾ���ٰ� �����ڸ��� ã������ �׳� ���׾�:2", "���������� ���ٺ��� ū ���ڰ� �����ž� �ű⼭ �� �����ϸ� ������  ���� ��ó�� �־�!:2" });

 
       talkData.Add(20 + 5000, new string[] { "���� �ٷ� ������ ������ ã�Ҵ�." });

       talkData.Add(21 + 1000, new string[] { "ã���༭ ����, ���� �ִ� ȭ�п� �ɾ�߰ھ�:1" });


       


        //�ʻ�ȭ
        //�Ǹ�
        portraitData.Add(1000 + 0, portraitaArr[0]);
        portraitData.Add(1000 + 1, portraitaArr[1]);
        portraitData.Add(1000 + 2, portraitaArr[2]);
        portraitData.Add(1000 + 3, portraitaArr[3]);
        //npcb
        portraitData.Add(2000 + 0, portraitaArr[4]);
        portraitData.Add(2000 + 1, portraitaArr[5]);
        portraitData.Add(2000 + 2, portraitaArr[6]);
        portraitData.Add(2000 + 3, portraitaArr[7]);
    }
    public string GetTalk(int id,int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            //����Ʈ �� ó�� ��縶�� ���� ��
            //�⺻ ��縦 ������ �´�.
            
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);             
            else
                //�ش� ����Ʈ ���� ���� ��簡 ������
                //����Ʈ �� ó�� ��� ������ ��
                return GetTalk(id - id % 10, talkIndex);
            
        }
            
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
