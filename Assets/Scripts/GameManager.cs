using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject scanObject;
    public Animator talkPanel;
    public bool isAction;
    public talkManager TalkManager;
    public int talkIndex;
    //초상화
    public Image portaitImg;
    public Animator portaitAnim;
    public Sprite prevPortrait;
    //퀘스트관련
    public QuestManager questManager;
    //텍스트 관련
    public TypeEffect talk;

    void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scanObj)
    {
            scanObject = scanObj;
            objData objData = scanObject.GetComponent<objData>();
            Talk(objData.id, objData.npc);

        talkPanel.SetBool("IsShow", isAction);
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
    void Talk(int id,bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";
        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
             questTalkIndex = questManager.GetQuestTalkIndex(id);
             talkData = TalkManager.GetTalk(id + questTalkIndex, talkIndex);
        }
        //end talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }
        if (isNpc) {
         
            talk.SetMsg(talkData.Split(':')[0]);

            portaitImg.sprite = TalkManager.GetPortrait(id,int.Parse(talkData.Split(':')[1]));

          
            portaitImg.color = new Color(1, 1, 1, 1);
            if (prevPortrait != portaitImg.sprite)
            {
                portaitAnim.SetTrigger("doEffect");
                prevPortrait = portaitImg.sprite;
            }
               

        }
        else {
           
            talk.SetMsg (talkData);
            portaitImg.color = new Color(1, 1, 1, 0);

        }
        isAction = true;
        talkIndex++;
    }
}
