using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilulas : Interativo
{
    public bool vermelha; // Indica se é a pilula vermelha ou laranja...

    protected override void DefinirInteracoes()
    {
        strInteracao = "[E] - Ver";
        strInteracao2 = "[R] - Pegar";
    }

    protected override void Interagir1()
    {
        // Acrescentar o que fazer depois!!!
    }

    protected override void Interagir2()
    {
        // Pegando a pilula...

        if (vermelha)
        {
            GerenciadorInvt.Instancia.pilulaVermelha++;
        }
        else
        {
            GerenciadorInvt.Instancia.pilulaLaranja++;
        }

        Destroy(gameObject);
    }

    protected override void PosDialogo()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        IniciarBase(3, "Cartela de remédio");
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();
    }
}
