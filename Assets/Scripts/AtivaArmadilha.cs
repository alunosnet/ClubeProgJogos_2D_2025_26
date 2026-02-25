using UnityEngine;

public class AtivaArmadilha : MonoBehaviour
{
    //referencia para o componente Rigidobyd2D da armalhida que vair cair quando o player entrar no trigger
    [Header("Arrastar para aqui a armadilha que cai")]
    public Rigidbody2D rb_armadilha;
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
            rb_armadilha.simulated = true;
        }
    }

}
