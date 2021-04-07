using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButtonHandler : MonoBehaviour
{
    public delegate void NextLineDelegate();
    public event NextLineDelegate nextLineEvent;
    public AnimationCurve myCurve;
    bool move = true;

    void Start()
    {
        GetComponentInParent<TalkManager>().endConvoEvent += ConvoEnd;
        
    }

    // Update is called once per frame
    void Update()
    {
        // the bobbing thing
        if (move) {
            transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)) - 0.6f, transform.position.z);
        }
    }

    void OnMouseDown() {
        Debug.Log("Down button pressed");
        nextLineEvent();
        transform.localScale -= new Vector3(0.05f, 0.05f, 0);
    }

    void OnMouseUp()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0);
    }

    void ConvoEnd() {
        move = false;
    }
}
