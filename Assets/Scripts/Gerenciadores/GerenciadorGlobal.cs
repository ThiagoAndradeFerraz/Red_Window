using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorGlobal : MonoBehaviour
{
    private GameObject player;
    private Text txtObjt;

    // Objetivos ---
    public int idObjetivo = 0;
    private bool objChecado = true; // <- Serve para evitar que o método seja chamado a todo momento

    // Itens ----------------
    // Objetivo1
    public int qtdFrutas = 0;
    public bool pegouFruta = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        txtObjt = GameObject.FindGameObjectWithTag("txtObjetivo").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        // Checando o objetivo do momento...
        if (objChecado)
        {
            ChecarObjetivo();
        }

        // Ligando e desligando o texto de com o estado do jogo (pausado ou rodando)
        if (player.GetComponent<Controle>().estaPausado)
        {
            txtObjt.enabled = true;
        }
        else
        {
            txtObjt.enabled = false;
        }
    }

    public void ChecarObjetivo()
    {
        switch (idObjetivo)
        {
            case 0:
                // Coleta de frutas
                Objetivo1();
                break;
            case 1:
                // Voltar para nave e conversar com a NPC
                Objetivo2();
                break;

            case 2:
                // Abrir templo 1
                break;
        }

        objChecado = false;
    }

    // Script do objetivo1... =====================================
    private void Objetivo1()
    {
        string texto1 = "Nossos suprimentos estão ficando escassos. Preciso encontrar algo que possamos comer.";
        SetarObjetivoTxt(PorAspas(texto1));
    }

    public void PegarFruta() // Chamado externamente (fruta / apple)!
    {
        qtdFrutas++;

        // Checa se o objetivo foi concluido...
        if(qtdFrutas > 2 && pegouFruta)
        {
            // Indo para o objetivo2...
            idObjetivo = 1;
            ChecarObjetivo();
        }
    }
    // ===========================================================

    // Script do objetivo2... =====================================
    private void Objetivo2()
    {
        string texto1 = "Acho que isso é suficiente. Melhor eu voltar para a nave.";
        SetarObjetivoTxt(PorAspas(texto1));
    }


    // ===========================================================

    private string PorAspas(string entrada)
    {
        string aspas = "\"";
        string saida = aspas + entrada + aspas;
        return saida;
    }

    public void SetarObjetivoTxt(string objetivo)
    {
        txtObjt.text = objetivo;
    }

    public void LimparObjetivo()
    {
        txtObjt.text = " ";
    }
}
