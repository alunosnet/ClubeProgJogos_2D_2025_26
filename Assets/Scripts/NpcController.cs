using UnityEngine;

public class NpcController : MonoBehaviour
{
    //Estados do npc
    public enum NPCEstados { Idle = 0, Patrulha = 1, Atacar = 2, Morto = 3, Fugir = 4 };
    public NPCEstados Estado;
    //Vida
    Vida vida;
    //Velocidade
    public float VelocidadeAndar;
    //Inimigo?
    public bool Inimigo;
    //Vida minima para fugir (0 não foge, >0 foge)
    public float VidaFugir = 0;
    //Vê o player?
    public bool VePlayer;
    public float DistanciaVe;
    public Transform olhos;
    public GameObject Player;
    //falas
    public string[] falas;
    //tira vida
    TiraVida tiraVida;
    //Pontos patrulha
    public Transform[] pontos;
    public int PontoAtual;
    public float distanciaMinima = 1;
    //Perseguir player (várias plataformas)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida = GetComponent<Vida>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MudarEstado();
        VePlayer = Ve_Player();
        switch (Estado)
        {
            case NPCEstados.Idle:
                Idle();
                break;
            case NPCEstados.Patrulha:
                Patrulha();
                break;
            case NPCEstados.Atacar:
                Atacar();
                break;
            case NPCEstados.Morto:
                Morto();
                break;
            case NPCEstados.Fugir:
                Fugir();
                break;
        }
    }
    void MudarEstado()
    {
        //verificar se o npc morreu?
        if (Estado!=NPCEstados.Morto && vida.VidaAtual==0)
        {
            Estado = NPCEstados.Morto;
            //TODO: animação morrer
            //TODO: dropar items
        }
    }
    /// <summary>
    /// Lógica do comportamento: Idle
    /// </summary>
    void Idle()
    {
        //TODO: animação idle
    }
    /// <summary>
    /// Lógica do comportamento : Patrulha
    /// </summary>
    void Patrulha()
    {
        //Calcular a distancia do NPC para o ponto para onde se move
        float distancia = Vector3.Distance(transform.position, pontos[PontoAtual].position);
        //Debug.Log(distancia);
        if (distancia < distanciaMinima)
        {
            PontoAtual++;
            if (PontoAtual == pontos.Length)
                PontoAtual = 0;
        }
        //Mover o NPC na direcao do ponto
        //Calcular a direção para onde o npc se move
        Vector3 direcao = pontos[PontoAtual].position - transform.position;
        //remover o y e z porque não é necessário no movimento lateral
        //normalizar o vector3 para ficar sempre do mesmo tamanho e assim
        //o npc mpve-se sempre à mesma velocidade
        direcao = new Vector3(direcao.x, 0, 0).normalized;
        //Debug.Log(direcao);
        //TODO: flip do sprite do npc?
        //aplicar o movimento à transform do npc
        transform.position += direcao * VelocidadeAndar * Time.deltaTime;
    }
    /// <summary>
    /// Lógica do comportamento: Atacar
    /// </summary>
    void Atacar()
    {

    }
    //Lógica do comportamento: Morto
    void Morto()
    {

    }
    /// <summary>
    /// Lógica do comportamento: Fugir
    /// </summary>
    void Fugir()
    {

    }
    /// <summary>
    /// Devolve verdadeiro se o npc vê o player
    /// </summary>
    /// <returns></returns>
    bool Ve_Player()
    {
        //Cria um raycast na direcao do player
        //TODO: limitar o angulo de visão do npc
        //TODO: raycast deve evitar o próprio NPC!!!!!
        RaycastHit2D raio = Physics2D.Raycast(olhos.position,Player.transform.position, DistanciaVe);
        //verifica se colidiu com um objeto e se o objeto tem tag player
        return (raio.collider!=null && raio.collider.CompareTag("Player"));
    }
}
