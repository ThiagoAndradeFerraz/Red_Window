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
    protected List<DialogModel> listaLinhas = new List<DialogModel>(); // Lista usada para a exibição dos dados...
    protected int lidasCont = 0;

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
    }

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
        Color cor = painelIntr.GetComponent<UnityEngine.UI.Image>().color;
        float transparencia = comando ? 1 : 0;
        cor.a = transparencia;
        painelIntr.GetComponent<UnityEngine.UI.Image>().color = cor;
    }

    protected void LigaUIfala(bool comando)
    {
        // Ligando/Desligando a transparencia do painel...
        Color cor = painelFala.GetComponent<UnityEngine.UI.Image>().color;
        float transparencia = comando ? 1 : 0;
        cor.a = transparencia;
        painelIntr.GetComponent<UnityEngine.UI.Image>().color = cor;
        
        // Definindo o conteúdo do campo de texto...
        //txtFala.text = comando ? strFala : " ";
    }

    protected void CarregarArquivoBruto(string caminho)
    {
        // CARREGA OS DADOS DO ARQUIVO NA MEMÓRIA

        // A primeira parte do caminho deve ser dinamica para acomodar a escolha de idioma...
        string caminhoCompleto = "Dialogos/PT-BR/" + caminho;

        arquivo = Resources.Load<TextAsset>(caminhoCompleto);
        strArquivo = arquivo.text;
        strLinhas = strArquivo.Split('\n');

        string[] dados;

        // Loop que adiciona cada linha a lista de objeto de fala...
        for (int i = 0; i < strLinhas.Length; i++)
        {
            dados = strLinhas[i].Split('|'); // Separando os dados da linha por pipe...
            string nome = dados[0];
            string fala = dados[1];
            listaLinhas.Add(new DialogModel(nome, fala)); // Jogando os dados da linha na lista...
        }
    }

    protected void ExibirTextoFala()
    {
        // CUIDA DO PROCESSO DE EXIBIÇÃO DA LISTA DE LINHAS DE FALA...
        Debug.Log("cont: " + lidasCont + " " + "tamanho: " + listaLinhas.Count);
        if (lidasCont < listaLinhas.Count)
        {
            txtFala.text = listaLinhas[lidasCont].GetFala();
            
            lidasCont++;
        }
        else
        {
            txtFala.text = " ";
            lidasCont = 0;
            //listaLinhas.Clear();
            GerenciadorInvt.Instancia.falando = false; // Avisando que o dialogo acabou...
        }
    }

    protected void AvancarTexto()
    {
        // Da avanco no dialogo por meio do clique do mouse...
        if (GerenciadorInvt.Instancia.falando)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ExibirTextoFala();
            }
        }
    }

    protected void IniciarDialogo(string caminho)
    {
        CarregarArquivoBruto(caminho); // Carregando arquivo na lista da memória...
        LigaUIfala(true); // Exibindo o painel...
        ExibirTextoFala(); // Exibindo a primeira linha...
        GerenciadorInvt.Instancia.falando = true; // Deixando marcado que o jogo esta em momento de dialogo...

        //strFala = texto;
        //LigaUIfala(true);
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
            PreechendoUIinteracao(); // Atualização a exibição do texto...
        }
    }

    // Métodos abstratos obrigatórios para as classes herdeiras...
    protected abstract void Interagir1();        // Define o que é feito na primeira opção de interação...
    protected abstract void Interagir2();        // Define o que é feito na segunda opção de interação...
    protected abstract void DefinirInteracoes(); // Define os textos descritivos de ações...
}