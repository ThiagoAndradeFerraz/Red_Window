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

        switch (estagioIntr)
        {
            case 1:
                IniciarDialogo("NPCS/Isaac/Isaac1");
                break;

            case 2:
                Debug.Log("Ola");
                break;
        }
    }

    protected override void Interagir2()
    {

    }

    protected override void PosDialogo()
    {
        switch (estagioIntr)
        {
            case 1:
                estagioIntr = 2;
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
