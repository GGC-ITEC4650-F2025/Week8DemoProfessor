using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudAction : MonoBehaviour
{
    //GIVE THE PLAYER CONTROLLER 1 EXTRA MAX JUMP
    PlayerController pc;
    InventoryMgr inv;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<InventoryMgr>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pc.maxJumps++;
        pc.jumpsRemaining++;
        inv.removeItem(1);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
