using UnityEngine;
/// <summary>
/// Deve ser colocado numa armadilha ou npc que tira vida com contacto
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class TiraVida : MonoBehaviour
{
    public int ValorDaVidaARetirar = 10;
    public bool DestroiQuandoTiraVida = false;
    public GameObject EfeitosDestruir;  //Sistema de particulas a ativar quando a armadilha é destruida
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
            var sp = Instantiate(EfeitosDestruir,transform.position, Quaternion.identity);
            sp.GetComponent<ParticleSystem>().Play();
            //O game object que colidiu tem vida por isso vai perder
            vida.TiraVida(ValorDaVidaARetirar);
            if (DestroiQuandoTiraVida == true)
                Destroy(this.gameObject);
        }
    }
}
