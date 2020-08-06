using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public abstract class Interativo : MonoBehaviour
{
    // --------------------------------------------------------
    // DESCRIÇÃO: Classe pai de todos os objetos interativos...
    // --------------------------------------------------------

    //*********************************************************

    // Variaveis de processamento de distancia com o player...
    protected GameObject player;
    protected float distMin = 0;
    private bool estaPerto = false;
    private bool estavaPerto = false;

    //*********************************************************
    
    // Caracteristicas do objeto...
    protected string strNome;
    protected string strInteracao;
    protected string strInteracao2;

    //*********************************************************

    // OBJETOS DO UI
    // Interação...
    protected GameObject PainelIntr;
    protected Text txtNome;
    protected Text txtIntr1;
    protected Text txtIntr2;

    //*********************************************************

    /*
    // Start is called before the first frame update
    void Start()
    {
        EncontrarObjetos();
    }*/

    // Update is called once per frame
    void Update()
    {
        //DetectarPlayer();
    }

    protected void DetectarPlayer()
    {
        // Detecta se a distancia entre player e objeto é inferior a um valor minimo estabelecido no inspector...

        if (Vector3.Distance(this.transform.position, player.transform.position) < distMin)
        {
            estavaPerto = estaPerto;
            estaPerto = true;
            if (estaPerto == true && estavaPerto == false)
            {
                //Debug.Log("perto");
                UsandoUIinteracao();
            }
            ChecarInput();
        }
        else
        {
            estavaPerto = estaPerto;
            estaPerto = false;
            if (!estaPerto && estavaPerto)
            {
                //Debug.Log(" ");
                LimpandoUIinteracao();
            }
        }
    }

    protected void EncontrarObjetos()
    {
        // Encontra, via tag, os objetos usados no script...
        
        //PLAYER
        player = GameObject.FindGameObjectWithTag("Player");

        //OBJETOS DE UI
        PainelIntr = GameObject.FindGameObjectWithTag("painel_intrc");
        txtNome = GameObject.FindGameObjectWithTag("txtNome").GetComponent<Text>();
        txtIntr1 = GameObject.FindGameObjectWithTag("txtIntrc1").GetComponent<Text>();
        txtIntr2 = GameObject.FindGameObjectWithTag("txtIntrc2").GetComponent<Text>();
    }

    protected void UsandoUIinteracao()
    {
        // Checando se o objeto tem mais de uma interação...
        // Teste em debug...

        txtNome.text = strNome;
        txtIntr1.text = strInteracao;

        if (strInteracao2 == null || strInteracao2 == "")
        {
            //Debug.Log(strNome + " - " + "[E] " + strInteracao); // TROCAR POR UI
            txtIntr2.text = " ";
        }
        else
        {
            //Debug.Log(strNome + " - " + "[E] " + strInteracao + " | " + "[R]" + strInteracao2); // TROCAR POR UI
            txtIntr2.text = strInteracao2;
        }

        LigaUIinteracao(true);
    }

    protected void LimpandoUIinteracao()
    {
        txtNome.text = " ";
        txtIntr1.text = " ";
        txtIntr2.text = " ";

        LigaUIinteracao(false);
    }

    protected void LigaUIinteracao(bool comando)
    {
        // Ativando / desativando a transparencia do painel de interação...
        Color cor = PainelIntr.GetComponent<UnityEngine.UI.Image>().color;
        float transparencia = comando ? 1 : 0;
        cor.a = transparencia;
        PainelIntr.GetComponent<UnityEngine.UI.Image>().color = cor;
    }


    protected void ChecarInput()
    {
        // Checando qual foi a interação selecionada pelo player...

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interagir1();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Interagir2();
        }

        DefinirInteracoes(); // Atualizando as opções de interação...
        if (estaPerto)
        {
            UsandoUIinteracao(); // Atualização a exibição do texto...
        }
    }

    // Métodos abstratos obrigatórios para as classes herdeiras...
    protected abstract void Interagir1();        // Define o que é feito na primeira opção de interação...
    protected abstract void Interagir2();        // Define o que é feito na segunda opção de interação...
    protected abstract void DefinirInteracoes(); // Define os textos descritivos de ações...
}