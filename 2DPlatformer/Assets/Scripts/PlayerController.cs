using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBod;
    Animator myAnim;

    public float runSpeed;
    public float jumpSpeed;
    public int maxJumps;

    private int jumpsRemaining;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myBod = GetComponent<Rigidbody2D>();
        jumpsRemaining = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 myVel = myBod.velocity;

        myVel.x = h * runSpeed;
        if (jumpsRemaining > 0 && Input.GetButtonDown("Jump"))
        {
            myVel.y = jumpSpeed;
            jumpsRemaining--;
        }
        myBod.velocity = myVel;

        if (Input.GetButtonDown("Fire1"))
        {
            myAnim.SetTrigger("ATTACK");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherGO = collision.gameObject;
        if (otherGO.name == "Ground")
        {
            jumpsRemaining = maxJumps;
        }
    }
}
