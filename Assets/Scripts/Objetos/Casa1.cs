using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa1 : InterativoDialog
{
    public TextAsset arqTexto1;
    public TextAsset arqTexto2;
    public TextAsset arqTexto3;

    private bool conv1 = true; // Inicio do jogo
    private bool conv2 = false; // Quando volta pra casa antes de completar o objt2
    
    public int idConversa = 1;

    protected override void Interagir()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            //playerObj.GetComponent<Controle>().EscurecerTela(true);
            LimpaTexto();
            SelecionarArquivo();
        }
    }

    private void SelecionarArquivo()
    {

        switch (idConversa)
        {
            case 1:
                // Cena inicial...
                ChamarGerenciador(arqTexto1);
                idConversa = 2;
                break;
                // ==========================
            case 2:
                // Quando volta para a nave antes de cumprir o objetivo...
                ChamarGerenciador(arqTexto2);
                // OBSERVAÇÃO: idConversa é setado como 3 pelo GerenciadorGlobal!
                break;
                // ==========================
            case 3:
                // Quando o objetivo de trazer frutas é cumprido...
                ChamarGerenciador(arqTexto3);
                break;

            case 4:
                //
                break;
        }


        /*
        if (conv1)
        {
            ChamarGerenciador(arqTexto1);
            conv1 = false;
            conv2 = true;
        }
        else if(conv2)
        {
            ChamarGerenciador(arqTexto2);
        }*/
    }

    private void Start()
    {
        //distMin = 100f;

        setarObjetos();
        setTexto("[E] - Entrar");
    }

    // Update is called once per frame
    void Update()
    {

        // Chamando a cena inicial...
        if(idConversa == 1)
        {
            SelecionarArquivo();
        }
        // --------------------------
        
        DetectarPlayer();   
    }
}