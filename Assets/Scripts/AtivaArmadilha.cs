using UnityEngine;

public class AtivaArmadilha : MonoBehaviour
{
    //referencia para o componente Rigidobyd2D da armalhida que vair cair quando o player entrar no trigger
    [Header("Arrastar para aqui a armadilha que cai")]
    public Rigidbody2D rb_armadilha;
    public GameObject EfeitosAtivar;    //Sistema de particulas a ativar quando a armadilha é ativada

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    /// <summary>
    /// Executa o código quando um gameobject entra no trigger
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Verificar se é o player pela tag
        //if (collision.transform.CompareTag("Player"))
        //{

        //}
        //Verificar se é o player pelo componente PlayerMovement
        PlayerMovement pm = collision.transform.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            if (rb_armadilha != null)
                rb_armadilha.simulated = true;
            //Se existir o sistema de particulas a ativar
            if (EfeitosAtivar != null)
            {
                Debug.Log("Ativar sistema de particulas");
                foreach (ParticleSystem sp in EfeitosAtivar.GetComponentsInChildren<ParticleSystem>())
                {
                    Debug.Log("Sistema ativado");
                    sp.Play();
                }
            }
        }
    }

}
