using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private 
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
        // not arrive here
        Debug.Log("Soda: enter OnCollisionEnter2D");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Soda: enter OnTriggerEnter2D");
        GameObject go = GameObject.Find("Soda");
        go.SetActive(false);
    }
}
