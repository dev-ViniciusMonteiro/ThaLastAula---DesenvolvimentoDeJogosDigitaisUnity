using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private int ParamSpeed = Animator.StringToHash("speed");
    private int ParamJump = Animator.StringToHash("jump");
    private int PramamChouch = Animator.StringToHash("crouch");//transforma as strings em int para melhor performace 

    private CapsuleCollider2D _capsuleColider;//para colisao do contato com o solo
    private bool _killPlayer = false;

    //andar
    public float speedForce = 12.0f;//forca andar
    private Vector2 _moviment = Vector2.zero; //recebe movimento do eixo X no codigo


    //no chao
    public bool isGrounded = false; //se esta no chao

    //agachar e pular
    public Vector3 offSet = Vector2.zero;//centro do criculo de contato com o chao
    public float radios = 10.0f;//raio do circulo de contato ao chao
    public LayerMask layer;//com o que ira ter contato
    public float JumpForce = 5f;//forca do pulo
    public bool isCrounch = false;//se esta de pe ou agachado
    public bool currentCrounch = false;//se esta apertando para agachar ou nao

   //sets de colisao com o chao de pe e agachado
    public Vector2 up_offset = new Vector2(0.002437592f, -0.5458291f);
    public Vector2 up_size = new Vector2(1.345448f, 1.345448f);
    public Vector2 down_offset = new Vector2(0f, -0.620397f);
    public Vector2 down_size = new Vector2(0.678647f, 0.9354168f);



    public int _cristal = 0;




    private Rigidbody2D _body = null;//fisica
    private Animator _animation = null;
    private SpriteRenderer _render = null;//usado para flip X personagem direita e esquerda

   



   

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

        //andar
        _moviment = new Vector2(Input.GetAxisRaw("Horizontal") * speedForce, 0.0f);//recebe <- -1 ou 0 ou +1 -> * Forca andar , DeltaTime = 0 (intervalo em segundos desde o último quadro até o atual)

        if (_moviment.sqrMagnitude > 0.1f)//se esta andando 
        {
            bool xRight = Input.GetAxis("Horizontal") > 0;//Ve lado que esta andando -- false vai pra esquerda(-1)
            if (_render.flipX == xRight) //se ele esta para um lado(<-false ou true->) e andar pra outro
                _render.flipX = !xRight;//inverte o FLip X do "Sprite Render"
        }

        float speed = Mathf.Abs(_body.velocity.x);//verefica se esta se movendo para animacao com numero absoluto
        _animation.SetFloat(ParamSpeed, speed);//paramspeed = stringhash
        //+ FixedUpdate()


        //agachar
        currentCrounch = Input.GetAxisRaw("Vertical") < 0f;//se apertar pra baixo = true
        //isCrounch se setiver agachado ou levantado
        if (isCrounch != currentCrounch )//se tiver agachando e nao estiver agachado ou se estiver levantando e estiver agachado
        {
            isCrounch = currentCrounch;//coloca como agachado ou de pe
            if (isCrounch)//se for agachar
            {
                _capsuleColider.offset = down_offset;//colisao do circulo agachado
                _capsuleColider.size = down_size;
            }
            else//se for levantar
            {
                _capsuleColider.offset = up_offset;//colisao do circulo de pe
                _capsuleColider.size = up_size;
            }

            _animation.SetBool(PramamChouch, isCrounch);//animacao de agachar

        }


        //pular
        if (Input.GetButtonDown("Jump") && isGrounded && !currentCrounch)//se apertar pra pular, estiver no ar e nao estiver agachando
        {
            _body.AddForce(Vector2.up* JumpForce, ForceMode2D.Impulse);//adiciona forca no Y usando jumpForce e impulso
        }

        _animation.SetBool(ParamJump, isGrounded);//animacao pular stringhash

    }

    private void FixedUpdate()
    {

        //pular e agachar
        isGrounded = Physics2D.OverlapCircle((this.transform.position + offSet), radios, layer);//se a esfera estiver em contato com a layer(ground) = true

        //andar
        if (_moviment.sqrMagnitude > 0.1f && !currentCrounch && !_killPlayer)//se tiver movimento E nao estiver agachado (tem rastro de massa so para se agachar) E nao pode estar morto
        {
            _body.AddForce(_moviment, ForceMode2D.Force);//adiciona forca no corpo com movimento e Adicione uma força ao Rigidbody2D, usando sua massa.
        }
        if (currentCrounch && isGrounded)//se agachar e nao estiver no ar para de andar
        {
            _body.velocity = Vector2.zero;//para a velocidade do corpo
        }
    }

    // Implemente OnDrawGizmosSelected se desejar desenhar utensílios somente se o objeto for selecionado
    private void OnDrawGizmosSelected()//desenha uma esfera no personagem para ver se esta pulando ou nao
    {
        Gizmos.color = Color.red;//cor vermelha
        Gizmos.DrawWireSphere((this.transform.position + offSet), radios);//desenha a esfera no centro do personagem + offSet(pra por bem no pe) com o raio escolhido
    }

    public void AddCristal()
    {
        _cristal++;
    }

    public void Kill()//Animacao de player morrer
    {
        _render.color = Color.red;
        _body.velocity = Vector2.zero;
        _killPlayer = true;
    }
    public void NextFase()
    {
        _render.color = Color.blue;
        _body.velocity = Vector2.zero;
        _killPlayer = true;
    }
}
