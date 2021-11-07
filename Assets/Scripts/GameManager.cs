using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text talkText;
    public GameObject scanObject;
    public GameObject talkPanel;
    public bool isAction;
    public talkManager TalkManager;
    public int talkIndex;
    //초상화
    public Image portaitImg;

    //퀘스트관련
    public QuestManager questManager;


     void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scanObj)
    {
            scanObject = scanObj;
            objData objData = scanObject.GetComponent<objData>();
            Talk(objData.id, objData.npc);
      
        talkPanel.SetActive(isAction);
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
    void Talk(int id,bool isNpc)
    {
        
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData=TalkManager.GetTalk(id+questTalkIndex, talkIndex);
        //end talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }
        if (isNpc) {
         
            talkText.text = talkData.Split(':')[0];

            portaitImg.sprite = TalkManager.GetPortrait(id,int.Parse(talkData.Split(':')[1]));

            portaitImg.color = new Color(1, 1, 1, 1);
        }
        else {
           
            talkText.text = talkData;
            portaitImg.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;
    }
}
