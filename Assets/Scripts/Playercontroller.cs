using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private int ParamSpeed = Animator.StringToHash("speed");
    private int ParamJump = Animator.StringToHash("jump");
    private int PramamChouch = Animator.StringToHash("crouch");

    private CapsuleCollider2D _capsuleColider;


    public float speedForce = 12.0f;

    public bool isGrounded = false;
    public Vector3 offSet = Vector2.zero;
    public float radios = 10.0f;
    public LayerMask layer;
    public float JumpForce = 5f;

    public bool isCrounch = false;
    public bool currentCrounch = false;
    public Vector2 up_offset = new Vector2(0.002437592f, -0.5458291f);
    public Vector2 up_size = new Vector2(1.345448f, 1.345448f);
    public Vector2 down_offset = new Vector2(0f, -0.620397f);
    public Vector2 down_size = new Vector2(0.678647f, 0.9354168f);



    public Vector2 _moviment = Vector2.zero;
    private Rigidbody2D _body = null;
    private Animator _animation = null;
    private SpriteRenderer _render = null;


    public Vector2 velocity;

    // Despertado é chamado quando a instância do script for carregada
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _animation = GetComponent<Animator>();
        _render = GetComponent<SpriteRenderer>();
        _capsuleColider = GetComponent<CapsuleCollider2D>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        _moviment = new Vector2(Input.GetAxisRaw("Horizontal") * speedForce, 0.0f);

        if (_moviment.sqrMagnitude > 0.1f)
        {
            bool xRight = Input.GetAxis("Horizontal") > 0;
            if (_render.flipX == xRight)
                _render.flipX = !xRight;
        }

        currentCrounch = Input.GetAxisRaw("Vertical") < 0f;

        if (isCrounch != currentCrounch )
        {
            isCrounch = currentCrounch;
            if (isCrounch)
            {
                _capsuleColider.offset = down_offset;
                _capsuleColider.size = down_size;
            }
            else
            {
                _capsuleColider.offset = up_offset;
                _capsuleColider.size = up_size;
            }

            _animation.SetBool(PramamChouch, isCrounch);

        }
        /**/




            if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            _body.AddForce(Vector2.up* JumpForce, ForceMode2D.Impulse);
        }

        _animation.SetBool(ParamJump, isGrounded);

        float speed = Mathf.Abs(_body.velocity.x);
        _animation.SetFloat(ParamSpeed, speed);

    }

    private void FixedUpdate()
    {
        velocity = _body.velocity;

        isGrounded = Physics2D.OverlapCircle((this.transform.position + offSet), radios, layer);

        if (_moviment.sqrMagnitude > 0.1f && !currentCrounch)
        {

            _body.AddForce(_moviment, ForceMode2D.Force);

        }
    }

    // Implemente OnDrawGizmosSelected se desejar desenhar utensílios somente se o objeto for selecionado
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((this.transform.position + offSet), radios);
    }


}
