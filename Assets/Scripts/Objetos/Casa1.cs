using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa1 : InterativoDialog
{
    public TextAsset arqTexto1;

    protected override void Interagir()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerObj.GetComponent<Controle>().EscurecerTela(true);
            LimpaTexto();
            ChamarGerenciador(arqTexto1);
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