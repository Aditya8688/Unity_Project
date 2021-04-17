using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
   private Rigidbody2D rb;
   private Animator animator;
   private enum State{idel, running, jumping, falling,hurt}
   private State state = State.idel;
   private Collider2D coll;
   [SerializeField]private LayerMask Ground;
   [SerializeField]private float speed = 5f;
   [SerializeField]private float jumpforce = 15f;
   [SerializeField] public int cherry = 0;
   [SerializeField] public Text cherrytext;
   

   void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       coll = GetComponent<Collider2D>(); 
    }
  
   
   void Update()
   {
        if(state != State.hurt)
        {
            movement();
        }
        AnimationState();
        animator.SetInteger("state", (int)state);     
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "collect")
        {
            Destroy(collision.gameObject);
            cherry += 1;
            cherrytext.text = cherry.ToString();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.tag == "enemy")
         {
            if(state == State.falling)
            {
             Destroy(other.gameObject);
            }
            else 
            {
               state = State.hurt;   
            }  
         }

        
        
    }

    private void movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if(hDirection < 0 )
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);    
        }

        
        else if(hDirection > 0 )
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);    
        } 

       
        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Ground))
        {
           rb.velocity = new Vector2(rb.velocity.x, jumpforce);
           state = State.jumping;
        } 
    }
     
    private void AnimationState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }

        }

        else if(state == State.falling)
        {
            if(coll.IsTouchingLayers(Ground))
            {
                state = State.idel;
            }
        }

        else if(state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.hurt;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 1f)
        {
            state = State.running;
        }
        else
        {
            state = State.idel;

        }
           
    }
}
