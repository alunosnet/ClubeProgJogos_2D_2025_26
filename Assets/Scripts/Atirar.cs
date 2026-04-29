using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Transform pontoAtirar;   //ponto onde vai ser instanciado o objeto a atirar
    public float forca = 10;
    public GameObject objetoAAtirar;
    public PlayerMovement pm;
    public float TempoDeVida = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pm=GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Acabou de carregar no botão para disparar
        if (Input.GetButtonDown("Fire1"))
        {
            var objeto=Instantiate(objetoAAtirar, pontoAtirar.position, Quaternion.identity);
            Destroy(objeto, TempoDeVida);
            //aplicar uma força
            if (pm.direita)
                objeto.GetComponent<Rigidbody2D>().AddForce(transform.right * forca);
            else    
                objeto.GetComponent<Rigidbody2D>().AddForce(-transform.right * forca);
        }
    }
}
