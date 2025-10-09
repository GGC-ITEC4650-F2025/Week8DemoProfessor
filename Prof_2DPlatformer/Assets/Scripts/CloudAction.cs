using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudAction : MonoBehaviour
{
    //GIVE THE PLAYER CONTROLLER 1 EXTRA MAX JUMP
    PlayerController pc;
    InventoryMgr inv;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<InventoryMgr>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pc.maxJumps++;
        pc.jumpsRemaining++;
        inv.removeItem(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            pc.maxJumps--;
            pc.jumpsRemaining--;
            Destroy(gameObject);
        }
    }
}
