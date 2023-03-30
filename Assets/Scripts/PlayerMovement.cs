using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private Animator _anim;
    private float dixY;
    private BoxCollider2D coll;
    [SerializeField] private float _speed = 7.0f;
    [SerializeField] private float _jump = 14.0f;
    [SerializeField] private LayerMask jumbleGround;

    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    };
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
         dixY = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(dixY * _speed, _rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jump);
        }
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        MovementState state;
        
        if (dixY > 0f )
        {
            state = MovementState.running;
            _sprite.flipX = false;
        }
        else if ( dixY < 0f)
        {
            state = MovementState.running;
            _sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }


        if (_rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        else if(_rb.velocity.y > 0.1f )
        {
            state = MovementState.jumping;
        }
        _anim.SetInteger("state",(int)state);
        //Debug.Log((int)state);
    }

    private bool isGrounded()
    {
      return  Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down,0.1f,jumbleGround);
    }
}
