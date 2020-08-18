using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeController : MonoBehaviour
{
    public GameObject tree;
    public GameObject key;
    public GameObject rejectImage;
    public GameObject successImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Tree: OnCollisionEnter2D");
        if (key.activeSelf == false)
        {
            rejectImage.SetActive(true);
            Invoke("rejectImageEnd", 2f);
        }
        else {
            successImage.SetActive(true);
            Invoke("successImageEnd", 2f);
            tree.SetActive(false);
            //GameObject.Destroy(this);
        }
    }

    private void rejectImageEnd() {
        rejectImage.SetActive(false);
    }
    private void successImageEnd() {
        successImage.SetActive(false);
    }
}
