using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float runSpeed = 20;
    [SerializeField] float jumpSpeed = 5;
    Rigidbody2D rigidbodyPlayer;
    Collider2D colliderPlayer;
    SpriteRenderer SpriteRendererPlayer;
    Animator animatorPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyPlayer = gameObject.GetComponent<Rigidbody2D>();
        colliderPlayer = gameObject.GetComponent<Collider2D>();
        SpriteRendererPlayer = gameObject.GetComponent<SpriteRenderer>();
        animatorPlayer = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FlipSprite();
    }


    private void Run()
    {
        var getDirection = Input.GetAxis("Horizontal");
        rigidbodyPlayer.velocity = new Vector2(getDirection * runSpeed, rigidbodyPlayer.velocity.y);
        animatorPlayer.SetBool("isRunning" , true);

        if(getDirection
         == 0){
           animatorPlayer.SetBool("isRunning" , false);
        }
    }

    private void Jump()
    {
        if (!colliderPlayer.IsTouchingLayers(LayerMask.GetMask("ground"))) { return; }
        if (Input.GetButton("Jump") || Input.GetKey("up"))
        {
            rigidbodyPlayer.velocity = new Vector2(rigidbodyPlayer.velocity.x, jumpSpeed);
        }
    }
    private void FlipSprite()
    {

        if (rigidbodyPlayer.velocity.x < 0)
        {
            SpriteRendererPlayer.flipX = true;
        }
        else if (rigidbodyPlayer.velocity.x > 0)
        {
            SpriteRendererPlayer.flipX = false;
        }

    }
}
