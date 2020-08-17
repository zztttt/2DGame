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

    private HashSet<KeyValuePair<int, int>> swordSet = new HashSet<KeyValuePair<int, int>>();
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        BagText = BagTextObj.GetComponent<Text>();
        BagText.text = "Count:" + count.ToString();

        // generate sword
        swordSet.Add(new KeyValuePair<int, int>(0, 5));
        swordSet.Add(new KeyValuePair<int, int>(0, 6));
        swordSet.Add(new KeyValuePair<int, int>(1, 4));
        swordSet.Add(new KeyValuePair<int, int>(1, 6));
        swordSet.Add(new KeyValuePair<int, int>(2, 3));
        swordSet.Add(new KeyValuePair<int, int>(2, 5));
        swordSet.Add(new KeyValuePair<int, int>(3, 1));
        swordSet.Add(new KeyValuePair<int, int>(3, 2));
        swordSet.Add(new KeyValuePair<int, int>(3, 4));
        swordSet.Add(new KeyValuePair<int, int>(4, 2));
        swordSet.Add(new KeyValuePair<int, int>(4, 3));
        swordSet.Add(new KeyValuePair<int, int>(5, 1));
        swordSet.Add(new KeyValuePair<int, int>(5, 3));
        swordSet.Add(new KeyValuePair<int, int>(6, 0));
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

        /*for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                Image image = images[i * cols + j];
                Color color = image.color;
                if (color == Color.black)
                    Debug.Log("Black: row:" + i + ", col:" + j);
            }
        }*/
        if (isSword(images, rows, cols))
        {
            Debug.Log("this is sword");
        }
        else {
            Debug.Log("this is not sword");
        }
    }

    public bool isSword(Image[] images, int rows, int cols) {
        HashSet<KeyValuePair<int, int>> tmp = new HashSet<KeyValuePair<int, int>>(swordSet);
        int blackCount = 0;
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Image image = images[i * cols + j];
                Color color = image.color;
                if (color == Color.black)
                    blackCount++;
            }
        }

        if (blackCount != 14) {
            Debug.Log("count not correct");
            return false;
        }

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Image image = images[i * cols + j];
                Color color = image.color;
                if (color == Color.black)
                {
                    KeyValuePair<int, int> kv = new KeyValuePair<int, int>(i, j);
                    if (tmp.Contains(kv))
                    {
                        tmp.Remove(kv);
                    }
                    else {
                        Debug.Log("color not correct");
                        return false;
                    }
                }
            }
        }

        return tmp.Count == 0 ? true:false;
    }
}
