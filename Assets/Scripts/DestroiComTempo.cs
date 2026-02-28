using UnityEngine;

public class DestroiComTempo : MonoBehaviour
{
    //Quanto tempo (segundos) espera para destruir o game object
    public float TempoDeVida = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, TempoDeVida);    
    }
}
