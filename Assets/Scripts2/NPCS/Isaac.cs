using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isaac : NPC
{
    protected override void DefinirInteracoes()
    {
        strInteracao = "[E] - Falar";
    }

    protected override void Interagir1()
    {
        SetarIntr(1);

        switch (GerenciadorInvt.Instancia.getIsaac())
        {
            case 1:
                IniciarDialogo("NPCS/Isaac/Isaac1");
                break;

            case 2:
                if(GerenciadorInvt.Instancia.pilulaLaranja == 0 
                    && GerenciadorInvt.Instancia.pilulaVermelha == 0)
                {
                    IniciarDialogo("NPCS/Isaac/Isaac2");
                }
                else
                {
                    // TRATAR DE COLOCAR UMA OPÇÃO DE ESCOLHA AQUI, NO MOMENTO APENAS UM CAMINHO ESTÁ SENDO TRATADO!
                    IniciarDialogo("NPCS/Isaac/IsaacE1");
                }
                break;
        }
    }

    protected override void Interagir2()
    {

    }

    protected override void PosDialogo()
    {
        switch (GerenciadorInvt.Instancia.getIsaac())
        {
            case 1:
                GerenciadorInvt.Instancia.setIsaac(2);
                //IniciarBase(3, "Carlos");
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        IniciarBase(3, "Desconhecido");
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();
    }
}
