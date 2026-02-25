using UnityEngine;
/// <summary>
/// Deve ser colocado numa armadilha ou npc que tira vida com contacto
/// </summary>
[RequireComponent(typeof(Collider))]
public class TiraVida : MonoBehaviour
{
    public int ValorDaVidaARetirar = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vida vida= collision.transform.GetComponent<Vida>();
        if ( vida!=null)
        {
            //O game object que colidiu tem vida por isso vai perder
            vida.TiraVida(ValorDaVidaARetirar);
        }
    }
}
