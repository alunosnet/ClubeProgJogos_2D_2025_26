using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2; //velocidade por segundo
    public float salto = 400;
    //Referência para rigidbody2d
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Leitura do input do jogador
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movimento = new Vector3(horizontal, 0, 0);
        //Movimento lateral (esq/dir) do jogador
        transform.position += movimento * Time.deltaTime * speed;
        //Salto
        //TODO: testar se está no chão
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * salto);
        }
    }
}
