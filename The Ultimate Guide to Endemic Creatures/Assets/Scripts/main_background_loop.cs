using UnityEngine;
using UnityEngine.UI;

/*
    This script pretty much just loops the background again and again
    I don't know why it's so long
    And I don't know if it's optimal
    But it works 
*/

public class main_background_loop : MonoBehaviour
{

    public Image firstImage;
    public Canvas canvas;

    [HideInInspector]
    public Image secondImage;
    public int scrollSpeed;
    private int screenWidth;
    private float threshold;
    private Vector3 leftSide;
    private float change;


    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        screenWidth = camera.pixelWidth;
        
        secondImage = Image.Instantiate(firstImage);
        secondImage.transform.SetParent(canvas.transform);
        secondImage.transform.SetSiblingIndex(0);

        secondImage.transform.position = firstImage.transform.position;
        secondImage.transform.position -= new Vector3(firstImage.rectTransform.sizeDelta.x - 2, 0, 0);

        leftSide = secondImage.transform.position;

        threshold = firstImage.rectTransform.sizeDelta.x;
        Debug.Log(firstImage.rectTransform.sizeDelta.x);

        Debug.Log(screenWidth);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveSpeed =  new Vector3(scrollSpeed * Time.deltaTime, 0, 0);

        if (change > threshold) {
            Debug.Log(change + " " + threshold);
            firstImage.transform.position = leftSide;
            
            Image _firstImage = firstImage;

            firstImage = secondImage;
            secondImage = _firstImage;

            change = 0;
        }
        
        firstImage.transform.position += moveSpeed; 
        secondImage.transform.position += moveSpeed;
        change += scrollSpeed * Time.deltaTime;
        
    }
}
