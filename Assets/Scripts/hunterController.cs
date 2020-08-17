using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hunterController : MonoBehaviour
{
    //private Rigidbody2D rigidbody;
    //private BoxCollider2D collider;
    private Animator animator;

    public GameObject swordImage;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
        //collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hunter: OnCollisionEnter2D");

        animator.SetTrigger("talk");
        if (swordImage.activeSelf == false) {
            swordImage.SetActive(true);
            Invoke("showSwordImageEnd", 5f);
        }
    }

    private void showSwordImageEnd() {
        swordImage.SetActive(false);
    }
}
