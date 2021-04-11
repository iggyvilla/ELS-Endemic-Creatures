using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoxHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<DownButtonInfoBox>().continueToQuestionEvent += exitInfoBox;
        // MakeInfoBoxEvent();
    }

    public void MakeInfoBoxEvent() {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("inframe", true);
    }

    void exitInfoBox() {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("inframe", false);
    }
}
