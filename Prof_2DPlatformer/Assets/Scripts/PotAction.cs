using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotAction : MonoBehaviour
{
    //GIVE THE PLAYER CONTROLLER 1 EXTRA MAX JUMP
    PlayerController pc;
    InventoryMgr inv;
    Rigidbody2D myBod;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<InventoryMgr>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        inv.removeItem(0);
        transform.position = pc.transform.position + 2.5f * Vector3.up;
        myBod = GetComponent<Rigidbody2D>();
        myBod.velocity = new Vector2(-5 * pc.transform.localScale.x, 0);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
