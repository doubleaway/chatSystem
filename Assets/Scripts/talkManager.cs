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
        talkData.Add(1000, new string[] { "안녕?:0", "어쩐일이야?:2","필요한거라도 있어?:1" });
        talkData.Add(2000, new string[] { "넌 누구야?:1", "우리 마을에 온걸 환영해! 둘밖에 없었는데 새로운 사람이 오니 좋다!:0" });
        talkData.Add(100, new string[] { "평범한 나무상자다.", "기분 나쁜 느낌이 난다. ." });

        //quest talk
       talkData.Add(10 + 1000, new string[] { "어서 와, 내 부탁 하나 들어줄 수 있어?:0", "씨앗을 잃어버렸어:2", "B가 마지막으로 갖고 있었는데.. 왼쪽으로 가면 그녀가 있을거야 :1","한번 물어봐줄래?:0" });
       talkData.Add(11 + 2000, new string[] { "응? 무슨일있어?:0", "응? 맞아 내가 가지고있었지, 혼자 심어보려다가 좋은자리를 찾지못해 그냥 놔뒀어:2", "오른쪽으로 가다보면 큰 상자가 있을거야 거기서 쭉 직진하면 나오는  강가 근처에 있어!:2" });

 
       talkData.Add(20 + 5000, new string[] { "상자 바로 옆에서 씨앗을 찾았다." });

       talkData.Add(21 + 1000, new string[] { "찾아줘서 고마워, 집에 있는 화분에 심어야겠어:1" });


       


        //초상화
        //악마
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
            //퀘스트 맨 처음 대사마저 없을 때
            //기본 대사를 가지고 온다.
            
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);             
            else
                //해당 퀘스트 진행 순서 대사가 없을때
                //퀘스트 맨 처음 대사 가지고 옴
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
