using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButtonInfoBox : MonoBehaviour
{
    public delegate void NextLineDelegate();
    public event NextLineDelegate continueToQuestionEvent;
    public AnimationCurve myCurve;
    bool move = true;

    void Start()
    {
        // GetComponentInParent<InfoBoxHandler>().animationDone += startMoving; 
    }

    void OnMouseDown() {
        Debug.Log("Down button pressed");
        continueToQuestionEvent();
        transform.localScale -= new Vector3(0.05f, 0.05f, 0);
        move = false;
    }

    void OnMouseUp()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0);
    }

    void startMoving() {
        move = true;
    }

}
