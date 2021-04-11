using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duplicator : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    private float camRightSide;
    private float nextInstance;
    private float myRightSide;
    private float offset;
    private float multiply = 3;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;

        myRightSide = transform.position.x + halfWidth + offset;
        camRightSide = cam.transform.position.x + halfWidth;

        if (camRightSide >= myRightSide) {
            Debug.Log(camRightSide);
            Debug.Log(myRightSide);

            nextInstance += GetComponent<SpriteRenderer>().bounds.size.x;
            multiply += 3;
            offset += myRightSide * multiply;
            Debug.Log("Offset: " + offset);
            Instantiate(gameObject, new Vector3(nextInstance, (float) transform.position.y, transform.position.z), transform.rotation);
        }
    }
}
