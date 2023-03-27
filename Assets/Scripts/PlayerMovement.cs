using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dixY = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(dixY * 7, _rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 14);
        }

        if (dixY > 0f || dixY < 0f)
        {
            _anim.SetBool("running",true);
        }
        else
        {
            _anim.SetBool("running",false);
        }
    }
}
