using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class men1Controller : MonoBehaviour
{
    public GameObject talk1;
    public GameObject talk2;
    public GameObject talk3;
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
        Debug.Log("men1: OnCollisionEnter2D");
        Invoke("talk1Start", 0f);
        Invoke("talk1End", 2f);
        Invoke("talk2Start", 2f);
        Invoke("talk2End", 4f);
        Invoke("talk3Start", 4f);
        Invoke("talk3End", 6f);
    }

    public void talkEnd(GameObject go) {
        go.SetActive(false);
    }
    public void talkStart(GameObject go) {
        go.SetActive(true);
    }

    public void talk1Start() {
        talkStart(talk1);
    }
    public void talk2Start()
    {
        talkStart(talk2);
    }
    public void talk3Start()
    {
        talkStart(talk3);
    }
    public void talk1End() {
        talkEnd(talk1);
    }
    public void talk2End()
    {
        talkEnd(talk2);
    }
    public void talk3End()
    {
        talkEnd(talk3);
    }
}
