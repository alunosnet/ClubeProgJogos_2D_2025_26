using UnityEngine;

public class NpcController : MonoBehaviour
{
    //Estados do npc
    public enum NPCEstados { Idle = 0, Patrula = 1, Atacar = 2, Morto = 3, Fugir = 4 };
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
    //falas
    public string[] falas;
    //tira vida
    TiraVida tiraVida;
    //Pontos patrulha
    public Transform[] pontos;
    public int PontoAtual;
    //Perseguir player (várias plataformas)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
