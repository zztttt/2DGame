using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject BagTextObj;
    public GameObject BagObj;
    public GameObject RepoObj;
    public GameObject ClickButtonObj;
    public GameObject OpenButtonObj;
    public GameObject CloseButtonObj;
    public GameObject OpenRepoButtonObj;
    public GameObject SwordAttackObj;
    public GameObject imageHolder;
    public GameObject tele1;
    public GameObject tele2;
    public GameObject tele3;
    public GameObject player;
    public GameObject woman;

    private Text BagText;

    private HashSet<KeyValuePair<int, int>> swordSet = new HashSet<KeyValuePair<int, int>>();
    private HashSet<KeyValuePair<int, int>> tiziSet = new HashSet<KeyValuePair<int, int>>();
    private HashSet<KeyValuePair<int, int>> alcoholSet = new HashSet<KeyValuePair<int, int>>();
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

        // generate tizi
        tiziSet.Add(new KeyValuePair<int, int>(0, 1));
        tiziSet.Add(new KeyValuePair<int, int>(0, 5));
        tiziSet.Add(new KeyValuePair<int, int>(1, 1));
        tiziSet.Add(new KeyValuePair<int, int>(1, 2));
        tiziSet.Add(new KeyValuePair<int, int>(1, 3));
        tiziSet.Add(new KeyValuePair<int, int>(1, 4));
        tiziSet.Add(new KeyValuePair<int, int>(1, 5));

        tiziSet.Add(new KeyValuePair<int, int>(2, 1));
        tiziSet.Add(new KeyValuePair<int, int>(2, 5));
        tiziSet.Add(new KeyValuePair<int, int>(3, 1));
        tiziSet.Add(new KeyValuePair<int, int>(3, 2));
        tiziSet.Add(new KeyValuePair<int, int>(3, 3));
        tiziSet.Add(new KeyValuePair<int, int>(3, 4));
        tiziSet.Add(new KeyValuePair<int, int>(3, 5));

        tiziSet.Add(new KeyValuePair<int, int>(4, 1));
        tiziSet.Add(new KeyValuePair<int, int>(4, 5));
        tiziSet.Add(new KeyValuePair<int, int>(5, 1));
        tiziSet.Add(new KeyValuePair<int, int>(5, 2));
        tiziSet.Add(new KeyValuePair<int, int>(5, 3));
        tiziSet.Add(new KeyValuePair<int, int>(5, 4));
        tiziSet.Add(new KeyValuePair<int, int>(5, 5));

        tiziSet.Add(new KeyValuePair<int, int>(6, 1));
        tiziSet.Add(new KeyValuePair<int, int>(6, 5));

        // generate alcohol
        alcoholSet.Add(new KeyValuePair<int, int>(0, 1));
        alcoholSet.Add(new KeyValuePair<int, int>(0, 2));
        alcoholSet.Add(new KeyValuePair<int, int>(0, 3));
        alcoholSet.Add(new KeyValuePair<int, int>(0, 4));
        alcoholSet.Add(new KeyValuePair<int, int>(0, 5));
        alcoholSet.Add(new KeyValuePair<int, int>(1, 1));
        alcoholSet.Add(new KeyValuePair<int, int>(1, 5));
        alcoholSet.Add(new KeyValuePair<int, int>(2, 1));
        alcoholSet.Add(new KeyValuePair<int, int>(2, 5));
        alcoholSet.Add(new KeyValuePair<int, int>(3, 2));
        alcoholSet.Add(new KeyValuePair<int, int>(3, 4));
        alcoholSet.Add(new KeyValuePair<int, int>(4, 3));
        alcoholSet.Add(new KeyValuePair<int, int>(5, 3));
        alcoholSet.Add(new KeyValuePair<int, int>(6, 2));
        alcoholSet.Add(new KeyValuePair<int, int>(6, 3));
        alcoholSet.Add(new KeyValuePair<int, int>(6, 4));
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
        resetImagesColor();
    }

    public void generate() {
        Debug.Log("generate weapons");
        GridLayoutGroup gridLayoutGroup = imageHolder.GetComponent<GridLayoutGroup>();
        int rows = gridLayoutGroup.constraintCount;
        Image[] images = imageHolder.GetComponentsInChildren<Image>();
        int count = images.Length, cols = count / rows;
        
        Debug.Log("rows:" + rows+ ", cols:" + cols);

        if (isSword(images, rows, cols))
        {
            Debug.Log("this is sword");
            EnablePlayerAttack();
            SwordAttackObj.SetActive(true);
            Invoke("showSwordAttack", 3f);
        }
        else if (isTizi(images, rows, cols))
        {
            Debug.Log("this is tizi");

            tele1.SetActive(true);
            tele2.SetActive(true);
            tele3.SetActive(true);
        }
        else if (isAlcohol(images, rows, cols)) {
            Debug.Log("this is alcohol");
            woman.SendMessage("activateKey");
        }
        else
        {
            Debug.Log("this is not sword");
        }
    }

    public void openRepo() {
        Debug.Log("open repo");
        if (RepoObj.activeSelf == true)
        {
            Debug.Log("Repo is already active");
            RepoObj.SetActive(false);
        }
        else {
            Debug.Log("Open Repo");
            RepoObj.SetActive(true);
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

    public bool isTizi(Image[] images, int rows, int cols) {
        HashSet<KeyValuePair<int, int>> tmp = new HashSet<KeyValuePair<int, int>>(tiziSet);
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

        if (blackCount != 23)
        {
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
                    else
                    {
                        Debug.Log("color not correct");
                        return false;
                    }
                }
            }
        }

        return tmp.Count == 0 ? true : false;
    }

    public bool isAlcohol(Image[] images, int rows, int cols) {
        HashSet<KeyValuePair<int, int>> tmp = new HashSet<KeyValuePair<int, int>>(alcoholSet);
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

        if (blackCount != 16)
        {
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
                    else
                    {
                        Debug.Log("color not correct");
                        return false;
                    }
                }
            }
        }

        return tmp.Count == 0 ? true : false;
    }

    public void resetImagesColor() {
        GridLayoutGroup gridLayoutGroup = imageHolder.GetComponent<GridLayoutGroup>();
        int rows = gridLayoutGroup.constraintCount;
        Image[] images = imageHolder.GetComponentsInChildren<Image>();
        int count = images.Length, cols = count / rows;
        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                Image image = images[i * cols + j];
                image.color = Color.white;
            }
        }
    }

    private void EnablePlayerAttack()
    {
        Debug.Log("EnablePlayerAttack");
        player.SendMessage("EnableMeleeAttacking");
    }

    private void showSwordAttack() {
        SwordAttackObj.SetActive(false);
    }
}
