using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private float startPosition;
    void Start()
    {
        float halfHeight = GetComponent<Camera>().orthographicSize;
        float halfWidth = GetComponent<Camera>().aspect * halfHeight;

        // startPosition = halfWidth;
        startPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // float playerOffset = player.transform.position.x - transform.position.x;
        
        if (player.transform.position.x >= startPosition) {
            transform.position = new Vector3(player.transform.position.x, 0, -10);
        }
    }
}
