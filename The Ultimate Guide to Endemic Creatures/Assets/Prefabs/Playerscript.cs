using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{

    public CharacterController2D controller;
    public float speed = 40f;

    public Animator animator;
    bool jump = false;

    bool crouch = false;

    float horread = 0f;

    public AudioClip Walk_01;
    public AudioClip Walk_02;
    public AudioClip Walk_03;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horread = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horread));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jumpy", true);
            StartCoroutine(WaitSeconds(1));
            animator.SetBool("Jumpy", false);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("Jumpy", false);
    }

    void FixedUpdate()
    {
        controller.Move(horread * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    
    IEnumerator WaitSeconds(int seconds) {
        yield return new WaitForSeconds(seconds);
    }

    public void playWalkSound() {
        int num = Random.Range(1, 4);
        float volume = Random.Range(0.8f, 1f);
        AudioSource audioSource = GetComponent<AudioSource>();

        Debug.Log(num);
        if (num == 3) {
            audioSource.PlayOneShot(Walk_01, volume);
        } else if (num == 2) {
            audioSource.PlayOneShot(Walk_02, volume);
        } else if (num == 3) {
            audioSource.PlayOneShot(Walk_03, volume);
        }
    }
}
