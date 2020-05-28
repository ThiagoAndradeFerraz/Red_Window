using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa1 : InterativoDialog
{
    public TextAsset arqTexto1;

    private bool conv1 = true;

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
        if (conv1)
        {
            ChamarGerenciador(arqTexto1);
            conv1 = false;
        }
    }

    private void Start()
    {
        setarObjetos();
        setTexto("[E] - Entrar");
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();   
    }
}