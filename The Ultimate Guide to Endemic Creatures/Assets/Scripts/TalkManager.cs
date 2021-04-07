using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Text conversation;
    public float TextShowDelay;
    bool nextEvent = false;
    public delegate void EndConversation();
    public event EndConversation endConvoEvent;


    void Start()
    {
        GoOutOfFrame();
        conversation = GetComponentInChildren<Text>();
        // StartCoroutine(MakeConversation(new string[] {"All your base are belong to us!", "Yahahahaha!"}));
        GetComponentInChildren<DownButtonHandler>().nextLineEvent += GoNextLine; // subscribing to event
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeConversation(string[] sentences) {
        GoInFrame();
        enabled = true;
        foreach (string sentence in sentences) {
            for (int i = 0; i < sentence.Length + 1; i++) {
                conversation.text = sentence.Substring(0, i);
                yield return new WaitForSeconds(TextShowDelay);
            }
            yield return new WaitUntil(() => nextEvent);
        }
        nextEvent = false;
        yield return new WaitUntil(() => nextEvent); // wait for one final button click
        
        endConvoEvent();
        GoOutOfFrame();
    }

    IEnumerator WaitingForNext() {
        yield return new WaitUntil(() => nextEvent);
        nextEvent = false;
    }

    void GoNextLine() {
        nextEvent = true;
    }

    void GoOutOfFrame() {
        Vector3 distance = new Vector3(0, 15, 0);
        transform.position -= distance;
        conversation.transform.position -= new Vector3(0, 200, 0);
        GetComponentInChildren<DownButtonHandler>().transform.position -= distance;
    }

    void GoInFrame() {
        Vector3 distance = new Vector3(0, 15, 0);
        transform.position += distance;
        conversation.transform.position += new Vector3(0, 200, 0);
        GetComponentInChildren<DownButtonHandler>().transform.position += distance;
    }
} 
