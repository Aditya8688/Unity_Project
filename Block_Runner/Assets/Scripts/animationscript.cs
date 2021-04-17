using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationscript : MonoBehaviour
{
    //public float RotateSpeed = 10f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("idle", true);
       if (Input.GetKey("w"))
       {
           animator.SetBool("run", true);
       }
       if (!Input.GetKey("w"))
       {
           animator.SetBool("run", false);
       }
       if (Input.GetKey("space"))
       {
           animator.SetBool("jump", true);
       }
       if (!Input.GetKey("space") )
       {
           //animator.SetBool("run", true);
           animator.SetBool("jump", false);
       }
      
    }
}
