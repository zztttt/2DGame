using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorController : MonoBehaviour
{
    public GameObject self;
    public GameObject talk1;
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
        Debug.Log("Narrator: OnCollisionEnter2D");
        Invoke("talk1Start", 0f);
        Invoke("talk1End", 2f);
        self.SetActive(false);
    }

    public void talkEnd(GameObject go)
    {
        go.SetActive(false);
    }
    public void talkStart(GameObject go)
    {
        go.SetActive(true);
    }

    public void talk1Start()
    {
        talkStart(talk1);
    }
    public void talk1End()
    {
        talkEnd(talk1);
    }
}
