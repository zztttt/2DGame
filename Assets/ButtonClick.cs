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
}
