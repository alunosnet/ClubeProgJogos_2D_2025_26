using UnityEngine;
/// <summary>
/// Deve ser colocado numa armadilha ou npc que tira vida com contacto
/// Para não tirar vida ao player colocar o objeto e o player em layers diferentes
/// e alterar a matriz de colisiões na settings do projeto
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class TiraVida : MonoBehaviour
{
    public int ValorDaVidaARetirar = 10;
    public bool DestroiQuandoTiraVida = false;
    public GameObject EfeitosDestruir;  //Sistema de particulas a ativar quando a armadilha é destruida
    //Alteração para permitir armadilhas que move o player quando este perde vida
    public bool MovePlayer = false;
    public Transform Posicao;   //Indica a posição para onde o player vai quando cai na armadilha
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessaArmadilha(collision.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessaArmadilha(collision.gameObject);
    }
    /// <summary>
    /// Recebe o objeto que colidiu com a armadilha e que vai perder vida
    /// </summary>
    /// <param name="objeto"></param>
    void ProcessaArmadilha(GameObject objeto)
    {
        Vida vida = objeto.transform.GetComponent<Vida>();
        if (vida != null)
        {
            //Testar se existe um efeito de particulas para "spawnar"
            if (EfeitosDestruir != null)
            {
                var sp = Instantiate(EfeitosDestruir, transform.position, Quaternion.identity);
                sp.GetComponent<ParticleSystem>().Play();
            }
            //O game object que colidiu tem vida por isso vai perder
            vida.TiraVida(ValorDaVidaARetirar);
            if (DestroiQuandoTiraVida == true)
                Destroy(this.gameObject);
            //Mover o player para a posição segura
            if (MovePlayer == true && objeto.CompareTag("Player"))
                objeto.transform.position = Posicao.position;

        }
    }
}
