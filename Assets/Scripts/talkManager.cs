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
        talkData.Add(1000, new string[] { "안녕?:0", "여긴 어쩐일이야?:2","정말 오랜시간을 기다린것 같아:1" });
        talkData.Add(100, new string[] { "평범한 나무상자다.", "기름 냄새가 난다." });


        //초상화
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
