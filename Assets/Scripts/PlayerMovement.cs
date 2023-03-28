using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private Animator _anim;
    private float dixY;

    [SerializeField] private float _speed = 7.0f;
    [SerializeField] private float _jump = 14.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         dixY = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(dixY * _speed, _rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jump);
        }
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        if (dixY > 0f )
        {
            _anim.SetBool("running",true);
            _sprite.flipX = false;
        }
        else if ( dixY < 0f)
        {
            _anim.SetBool("running",true);
            _sprite.flipX = true;
        }
        else
        {
            _anim.SetBool("running",false);
        }
    }
}
