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
    //√ ªÛ»≠
    public Image portaitImg;
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

        string talkData=TalkManager.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
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
