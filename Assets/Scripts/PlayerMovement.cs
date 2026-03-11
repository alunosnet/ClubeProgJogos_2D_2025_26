using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 2; //velocidade por segundo
    public float salto = 400;
    public bool IsGrounded = false; //indica se tem os pés no chão
    public Transform pe_e;
    public Transform pe_d;
    public float maxDistance = 0.5f;
    //Referência para rigidbody2d
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    float velocidade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Leitura do input do jogador
        float horizontal = Input.GetAxis("Horizontal");
        //verificar se está a correr
        if (Input.GetButton("Run"))
        {
            horizontal = horizontal * 2;
        }
        velocidade=Mathf.Abs(horizontal);

        animator.SetFloat("velocidade", velocidade);
        Vector3 movimento = new Vector3(horizontal, 0, 0);
        //Movimento lateral (esq/dir) do jogador
        transform.position += movimento * Time.deltaTime * speed;
        //Salto
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            rb.AddForce(Vector2.up * salto);
            //animação saltar
            animator.SetTrigger("saltar");
        }
        //verificar se está grounded
        VerificaPeChao(pe_d);
        if (IsGrounded==false)
            VerificaPeChao(pe_e);
        //se está com os pés no chão e está a fazer a animação de saltar
        //parar
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).shortNameHash);
        if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash==-1481439722 &&
            IsGrounded)
        {
            animator.ResetControllerState(true);
        }
        //flip do sprite quando está a andar para a esquerda
        sr.flipX = (horizontal < 0);
    }

    private void VerificaPeChao(Transform pe)
    {
        RaycastHit2D raio = Physics2D.Raycast(pe.position, Vector2.down, maxDistance);
        //Desenha o raio que deteta o chão
        Debug.DrawRay(pe.position, Vector3.down * maxDistance, Color.red);
        if (raio.collider == null)
        {
            IsGrounded = false;
        }
        else
        {
            IsGrounded = true;
        }
    }
}
