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
        strInteracao = "Ligar / Desligar";
        strInteracao2 = "Colocar / Tirar";
    }

    private void Update()
    {
        DetectarPlayer();
        
    }

    private void LigaDesliga()
    {
        objetoLuz.GetComponent<Light>().enabled = !ligada;
        ligada = objetoLuz.GetComponent<Light>().enabled;
    }

    protected override void Interagir1()
    {
        // Ligando ou desligando a luz...
        if (funcionando)
        {
            LigaDesliga();
        }
        else
        {
            if(GerenciadorInvt.Instancia.contLampadas > 0)
            {
                Debug.Log("Preciso por uma lampada!");
            }
            else
            {
                Debug.Log("droga, tá faltando uma lampada aqui!");
            }
            
        }
    }

    protected override void Interagir2()
    {
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
        ligada = false;
        objetoLuz.GetComponent<Light>().enabled = false;
        funcionando = false;
    }

    protected void BotarLampada()
    {
        // Bota lampada em suporte vazio...
        if(GerenciadorInvt.Instancia.contLampadas > 0)
        {
            GerenciadorInvt.Instancia.contLampadas--;
            ligada = true;
            objetoLuz.GetComponent<Light>().enabled = true;
            funcionando = true;
        }
        else
        {
            Debug.Log("estou sem lampadas...");
        }
    }

    protected void EncontrarLampadaFilha()
    {
        // Obtem o objeto de luz que acende e a apaga...
        objetoLuz = gameObject.transform.GetChild(0);
    }
}
