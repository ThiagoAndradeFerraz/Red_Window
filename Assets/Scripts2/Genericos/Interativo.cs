using System;
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
    protected GameObject painelIntr;
    protected Text txtNome;
    protected Text txtIntr1;
    protected Text txtIntr2;

    // Dialogo...
    protected GameObject painelFala;
    protected Text txtFala;
    protected string strFala;

    //*********************************************************

    // Leitura de arquivo de texto...
    protected TextAsset arquivo;   
    protected string strArquivo;  // String bruta dos dados do arquivo...
    protected string[] strLinhas; // Array de linhas brutas do arquivo...
    protected string[] strDados;  // Array de dados por linha...
    protected int contFala = 0;
    protected int tamanho = 0;
    protected string checaFim;

    // Usadas para ajustar o clique do mouse em cenas de dialogo...
    protected bool intr1 = false;
    protected bool intr2 = false;

    //*********************************************************

    // UI computador...
    protected GameObject inputPC;

    //*********************************************************

    // Update is called once per frame
    void Update()
    {
        //DetectarPlayer();
    }

    // Detectar proximidade do jogador...
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
                PreechendoUIinteracao();
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

    // Obtem os objetos da cena via tag...
    protected void EncontrarObjetos()
    {
        // Encontra, via tag, os objetos usados no script...
        
        //PLAYER
        player = GameObject.FindGameObjectWithTag("Player");

        //OBJETOS DE UI
        // Interação...
        painelIntr = GameObject.FindGameObjectWithTag("painel_intrc");
        txtNome = GameObject.FindGameObjectWithTag("txtNome").GetComponent<Text>();
        txtIntr1 = GameObject.FindGameObjectWithTag("txtIntrc1").GetComponent<Text>();
        txtIntr2 = GameObject.FindGameObjectWithTag("txtIntrc2").GetComponent<Text>();

        // Dialogo...
        painelFala = GameObject.FindGameObjectWithTag("painel_fala");
        txtFala = GameObject.FindGameObjectWithTag("txtFala").GetComponent<Text>();

        // Interação UI com o computador...
        inputPC = GameObject.FindGameObjectWithTag("InputSenha");
    }

    // Preenchendo os textos de interação...
    protected void PreechendoUIinteracao()
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

        ExibirPainelIntr(true);
    }

    // Limpando os textos de interação...
    protected void LimpandoUIinteracao()
    {
        txtNome.text = " ";
        txtIntr1.text = " ";
        txtIntr2.text = " ";

        ExibirPainelIntr(false);
    }

    // Ligando / desligando a exibição do painel de interação...
    protected void ExibirPainelIntr(bool comando)
    {
        // Ativando / desativando a transparencia do painel de interação...
        Color cor = painelIntr.GetComponent<UnityEngine.UI.Image>().color;
        float transparencia = comando ? 1 : 0;
        cor.a = transparencia;
        painelIntr.GetComponent<UnityEngine.UI.Image>().color = cor;
    }

    // Ligando / desligando a exibição do painel de fala...
    protected void ExibirPainelFala(bool comando)
    {
        // Ligando/Desligando a transparencia do painel...
        Color cor = painelFala.GetComponent<UnityEngine.UI.Image>().color;
        float transparencia = comando ? 1 : 0;
        cor.a = transparencia;
        painelFala.GetComponent<UnityEngine.UI.Image>().color = cor;
    }

    // Carrega o arquivo de texto...
    protected void CarregarArquivo(string caminhoP2)
    {
        string caminhoP1 = "Dialogos/PT-BR/";
        string caminhoCompleto = caminhoP1 + caminhoP2;
        arquivo = Resources.Load<TextAsset>(caminhoCompleto);
        strArquivo = arquivo.text;
        strLinhas = strArquivo.Split('\n');

        tamanho = strLinhas.Length - 1;
    }

    // Inicia e trata o fluxo do dialogo...
    protected void IniciarDialogo(string caminho)
    {
        if(!GerenciadorInvt.Instancia.falando) // Iniciando o fluxo de dialogo...
        {
            //Debug.Log("iniciou");
            CarregarArquivo(caminho);
            ExibirPainelFala(true);
            GerenciadorInvt.Instancia.falando = true;
            //Debug.Log(strLinhas[contFala]);
            strDados = strLinhas[contFala].Split('|');
            txtFala.text = strDados[1];
            contFala++;
        }
        else // Fluxo já iniciado em iteração anterior...
        {
            if(contFala <= strLinhas.Length - 1) // Ainda não chegou ao fim do arquivo...
            {
                //Debug.Log(strLinhas[contFala]);
                strDados = strLinhas[contFala].Split('|');
                txtFala.text = strDados[1];
                contFala++; 
            }
            else // Chegou ao fim...
            {
                //Debug.Log("ACABOU A LISTA!");
                ExibirPainelFala(false);
                txtFala.text = " ";
                GerenciadorInvt.Instancia.falando = false;
                contFala = 0;
                PosDialogo();
            }
        }
    }

    // Usado para marcar quak interação está sendo trabalhada...
    protected void SetarIntr(int intr)
    {
        switch (intr)
        {
            case 1:
                intr1 = true;
                intr2 = false;
                break;

            case 2:
                intr1 = false;
                intr2 = true;
                break;
        }
    }

    // Checando se foi pedida alguma interação com o objeto...
    protected void ChecarInput()
    {
        // Checando qual foi a interação selecionada pelo player...
        if (Input.GetKeyDown(KeyCode.E) || (Input.GetMouseButtonDown(0) && GerenciadorInvt.Instancia.falando && intr1))
        {
            Interagir1();
        }
        else if (Input.GetKeyDown(KeyCode.R) || (Input.GetMouseButtonDown(0) && GerenciadorInvt.Instancia.falando && intr2))
        {
            Interagir2();
        }

        DefinirInteracoes(); // Atualizando as opções de interação...
        if (estaPerto)
        {
            PreechendoUIinteracao(); // Atualização a exibição do texto...
        }
    }

    // Métodos abstratos obrigatórios para as classes herdeiras...
    protected abstract void Interagir1();        // Define o que é feito na primeira opção de interação...
    protected abstract void Interagir2();        // Define o que é feito na segunda opção de interação...
    protected abstract void DefinirInteracoes(); // Define os textos descritivos de ações...

    protected abstract void PosDialogo(); // Define as ações que podem acontece após um dialogo... (OPCIONAL)
}