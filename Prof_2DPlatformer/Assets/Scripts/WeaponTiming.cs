using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTiming : MonoBehaviour
{
    public float startSwingPercent;
    public float stopSwingPercent;

    Collider2D myCol;
    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<Collider2D>();
        myAnim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myCol.enabled = false;
        AnimatorStateInfo state = myAnim.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Attack"))
        {
            float percent = state.normalizedTime;
            if(percent >= startSwingPercent && percent <= stopSwingPercent)
                myCol.enabled = true;
        }
    }
}
