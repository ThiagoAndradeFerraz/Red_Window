using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Lampada : Interativo
{

    public bool ligada; // Define se esta ligada ou desligada...
    public bool funcionando; // Define se a lampada esta funcional...
    private Transform objetoLuz; // Objeto de luz...

    private void Start()
    {
        EncontrarObjetos();
        EncontrarLampadaFilha();

        distMin = 3;
        strNome = "Lampada";
        DefinirInteracoes();
    }

    private void Update()
    {
        DetectarPlayer();
    }

    // Liga / Desliga o objeto de luz da lampada...
    private void LigaDesliga()
    {
        objetoLuz.GetComponent<Light>().enabled = !ligada;
        ligada = objetoLuz.GetComponent<Light>().enabled;
    }

    // Interação 1...
    protected override void Interagir1()
    {
        SetarIntr(1);

        // Ligando ou desligando a luz...
        if (funcionando)
        {
            LigaDesliga();
        }
        else
        {
            if(GerenciadorInvt.Instancia.contLampadas > 0)
            {
                IniciarDialogo("OBJETOS/Lampada/no-lamp2");
            }
            else
            {
                IniciarDialogo("OBJETOS/Lampada/no-lamp1");
            }
        }
    }

    // Interação 2...
    protected override void Interagir2()
    {
        SetarIntr(2);

        if (funcionando)
        {
            PegarLampada();
        }
        else
        {
            BotarLampada();
        }
    }

    protected void PegarLampada()
    {
        // Tirando o objeto da lampada do suporte...
        GerenciadorInvt.Instancia.contLampadas++; // Adicionado +1 de lampadas para o inventário...
        //ligada = false;
        objetoLuz.GetComponent<Light>().enabled = false;
        funcionando = false;
    }

    protected void BotarLampada()
    {
        // Bota lampada em suporte vazio...
        if(GerenciadorInvt.Instancia.contLampadas > 0)
        {
            GerenciadorInvt.Instancia.contLampadas--;
            //ligada = true;
            objetoLuz.GetComponent<Light>().enabled = ligada;
            funcionando = true;
        }
        else
        {
            Debug.Log("estou sem lampadas...");
        }
    }

    protected override void DefinirInteracoes()
    {
        // Define as interações...

        strInteracao = ligada ? "[E] - Desligar" : "[E] - Ligar";
        strInteracao2 = funcionando ? "[E] - Tirar lampada" : "[R] - Botar lampada";
    }

    protected void EncontrarLampadaFilha()
    {
        // Obtem o objeto de luz que acende e a apaga...
        objetoLuz = gameObject.transform.GetChild(0);
    }

    protected override void PosDialogo()
    {
        
    }
}
