using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man2Controller : MonoBehaviour
{
    public GameObject teleporter;
    public GameObject tizi;
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
        tizi.SetActive(true);
        Invoke("showTiziEnd", 2f);
    }

    public void showTiziEnd() {
        tizi.SetActive(false);
    }
}
