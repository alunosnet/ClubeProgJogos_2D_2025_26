using UnityEngine;
/// <summary>
/// Este deve estar nos GameObjects que pretendemos que tenham vida e possam ser destruidos
/// P.Ex: Player, NPC, Veículos, etc
/// </summary>
public class Vida : MonoBehaviour
{
    public int MaxVida = 100;
    public int VidaAtual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VidaAtual = MaxVida;
    }
    /// <summary>
    /// Função que é executada a partir dos objetos que tiram vida (p.ex: armadilhas, npcs,etc)
    /// Devolve True se perdeu vida e não morreu
    /// Devolve False se perdeu vida e morreu
    /// </summary>
    /// <param name="valor">Valor da vida que perde</param>
    public bool TiraVida(int valor)
    {
        //retirar o valor da vida
        VidaAtual -= valor;
        if (VidaAtual <0)
        {
            VidaAtual = 0;
            return false; //Morreu
            //Destruir o gameobject?
        }
        return true; //Não morreu
    }
    /// <summary>
    /// Esta função é chamada a partir dos GameObjects que "dão" vida
    /// Devolve true se ganhou vida
    /// Devolve false se não ganhou vida
    /// </summary>
    /// <param name="valor">Valor da vida que ganha</param>
    /// <returns></returns>
    public bool GanhaVida(int valor)
    {
        if (VidaAtual == MaxVida) return false; //Não ganha vida
        VidaAtual += valor; //Ganha vida
        if (VidaAtual > MaxVida)
            VidaAtual = MaxVida;    
        return true;
    }
}
