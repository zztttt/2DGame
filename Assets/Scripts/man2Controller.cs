using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man2Controller : MonoBehaviour
{
    public GameObject teleporter;
    public GameObject tizi;
    public GameObject talk;
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
        Debug.Log("man2: OnCollisionEnter2D");
        talk.SetActive(true);
        Invoke("talkEnd", 2f);
        Invoke("showTiziStart", 2f);
        Invoke("showTiziEnd", 4f);
    }
    public void showTiziStart() {
        tizi.SetActive(true);
    }
    public void showTiziEnd() {
        tizi.SetActive(false);
    }
    public void talkEnd() {
        talk.SetActive(false);
    }
}
