using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Elevador : Interativo
{
    protected GameObject painel;
    private bool exibirPainel = true; // Indica se é pra exibir ou ocultar o painel...


    protected override void DefinirInteracoes()
    {
        strInteracao = "[E] - Entrar";
        strInteracao2 = " ";
    }

    protected override void Interagir1()
    {
        //APENAS PARA TESTE!!!
        Scene cenaAtual = SceneManager.GetActiveScene();
        string nomeCena = cenaAtual.name;
        string novaCena = " ";

        if(nomeCena == "TERREO")
        {
            novaCena = "CORREDOR1";
        }
        else if(nomeCena == "CORREDOR1")
        {
            novaCena = "TERREO";
        }

        SceneManager.LoadScene(novaCena);

        //LigaPainel(exibirPainel);
    }

    protected override void Interagir2()
    {
        
    }

    protected override void PosDialogo()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        EncontrarUI();
        IniciarBase(3, "Elevador");
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();
    }

    // Encontra elementos de UI exclusivos ao objeto...
    private void EncontrarUI()
    {
        painel = GameObject.FindGameObjectWithTag("painelElevador");
    }

    // Exibe ou oculta o painel do elevador...
    protected void LigaPainel(bool status)
    {
        painel.GetComponent<UnityEngine.UI.Image>().enabled = status;
        exibirPainel = !status;
        Debug.Log(painel.GetComponent<UnityEngine.UI.Image>().enabled);
    }
}