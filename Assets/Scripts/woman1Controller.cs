﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woman1Controller : MonoBehaviour
{
    public GameObject talk1;
    public GameObject talk2;
    public GameObject talk3;
    public GameObject key;

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
        Debug.Log("woman1: OnCollisionEnter2D");
        Invoke("talk1Start", 0f);
        Invoke("talk1End", 2f);
        Invoke("talk2Start", 2f);
        Invoke("talk2End", 4f);
    }

    public void talkEnd(GameObject go)
    {
        go.SetActive(false);
    }
    public void talkStart(GameObject go)
    {
        go.SetActive(true);
    }

    public void talk1Start() {
        talkStart(talk1);
    }
    public void talk1End() {
        talkEnd(talk1);
    }
    public void talk2Start()
    {
        talkStart(talk2);
    }
    public void talk2End()
    {
        talkEnd(talk2);
    }
    public void talk3Start()
    {
        talkStart(talk3);
    }
    public void talk3End()
    {
        talkEnd(talk3);
    }

    public void activateKey() {
        key.SetActive(true);
        Invoke("talk3Start", 0f);
        Invoke("talk3End", 2f);
    }
}
