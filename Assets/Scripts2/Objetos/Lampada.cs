using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampada : Interativo
{
    public bool ligada; // Define se esta ligada ou desligada...
    public bool funcionando; // Define se a lampada esta funcional...

    private void Start()
    {
        EncontrarObjetos();
        distMin = 3;
    }

    private void LigaDesliga(bool status)
    {
        if (status) // Esta ligada...
        {
            ligada = !ligada;
            Debug.Log("desligou");
        }
        else
        {
            ligada = !ligada;
            Debug.Log("ligou");
        }
    }

    protected override void Interagir1()
    {
        // Ligando ou desligando a luz...
        if (funcionando)
        {
            LigaDesliga(ligada);
        }
        else
        {
            Debug.Log("droga, tá faltando uma lampada aqui!");
        }
    }

    protected override void Interagir2()
    {
        throw new System.NotImplementedException();
    }
}
