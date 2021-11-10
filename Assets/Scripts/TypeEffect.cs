using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMsg;
    public GameObject EndCursor;
    public int CharperSeconds;
    int index;
    Text msgText;
    float interval;
    AudioSource audioSource;
    public bool isAnim;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        EndCursor.SetActive(false);
        msgText.text = "";
        index = 0;
        interval = 1.0f / CharperSeconds;
        Invoke("Effecting", interval);
        isAnim = true;
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
         

     
        msgText.text += targetMsg[index];
        //sound 
        if (targetMsg[index] != ' ' ||targetMsg[index] != '.')
        {
            audioSource.Play();
        }
           

        index++;
       
       
        Invoke("Effecting", interval);
       
    }

    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);

    }
}
