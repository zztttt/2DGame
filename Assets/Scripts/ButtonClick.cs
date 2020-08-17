using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject BagTextObj;
    public GameObject BagObj;
    public GameObject ClickButtonObj;
    public GameObject OpenButtonObj;
    public GameObject CloseButtonObj;
    public GameObject imageHolder;

    private Text BagText;


    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        BagText = BagTextObj.GetComponent<Text>();
        BagText.text = "Count:" + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        BagText.text = "Count:" + count.ToString();
    }

    public void ClickClick() {
        Debug.Log("Click");
        count++;
    }

    public void SendMessage() {
        Debug.Log("SendMessage");
    }

    public void open() {
        if (BagObj.activeSelf == true)
        {
            Debug.Log("Bag is already active");
        }
        else {
            Debug.Log("Open Bag");
            BagObj.SetActive(true);
        }
    }

    public void close() {
        BagObj.SetActive(false);
    }

    public void generate() {
        Debug.Log("generate weapons");
        GridLayoutGroup gridLayoutGroup = imageHolder.GetComponent<GridLayoutGroup>();
        int rows = gridLayoutGroup.constraintCount;
        Image[] images = imageHolder.GetComponentsInChildren<Image>();
        int count = images.Length, cols = count / rows;
        
        Debug.Log("rows:" + rows+ ", cols:" + cols);

        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                Image image = images[i * cols + j];
                Color color = image.color;
                if (color == Color.black)
                    Debug.Log("Black: row:" + i + ", col:" + j);
            }
        }
    }
}
