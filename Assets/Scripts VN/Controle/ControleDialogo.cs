using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDialogo : MonoBehaviour
{
    // *****************************************
    // *  VERSÃO 2 DO CONTROLADOR DE DIALOGO   *
    // * ------------------------------------- *
    // *        - lê e itera arquivo de texto  *
    // *        - chama escolha                *
    // *        - segue roteiro de fluxo       *
    // *****************************************

    // === Controle ===
    public int step; // Marca determinados pontos da história...
    public string idioma; // Indica o idioma que o jogo foi iniciado...
    private GameObject controleRoteiro; // Controla os pontos de checkpoint da história...

    // === UI ===
    private Image imgRosto; // Objeto usado para a exibição da sprite de dialogo...
    private Sprite sprite;  // Sprite a ser carregado...
    private Text txtNome;   // Exibe a string de nome...
    private Text txtFala;   // Exibe a string de fala...
    private GameObject btnSim, btnNao; // Botões de escolha...
    private Text txtSim, txtNao;       // Texto dos botões de escolha...

    // === Carga de texto ===
    private TextAsset arquivoTexto; // Arquivo de texto bruto...
    private string strTexto;        // String do texto...
    private string[] strLinhas;     // Texto dividio por linhas...
    private string[] strPartes;     // Linha dividida em partes...

    // === Iteração texto ===
    private int contLinhas = 0;
    private bool dialogoIniciado = false;
    private int tipoFim; // Indica se o fim vai ou não ter uma escolha...

    // Start is called before the first frame update
    void Start()
    {
        imgRosto = GameObject.FindGameObjectWithTag("imgRosto").GetComponent<Image>();
        txtNome = GameObject.FindGameObjectWithTag("txtNome").GetComponent<Text>();
        txtFala = GameObject.FindGameObjectWithTag("txtFala").GetComponent<Text>();
        btnSim = GameObject.FindGameObjectWithTag("btnSim");
        btnNao = GameObject.FindGameObjectWithTag("btnNao");
        txtSim = GameObject.FindGameObjectWithTag("txtSim").GetComponent<Text>();
        txtNao = GameObject.FindGameObjectWithTag("txtNao").GetComponent<Text>();

        controleRoteiro = GameObject.FindGameObjectWithTag("controle_roteiro");

        //idioma = ControleGlobal.Instancia.idioma;

        //idioma = "PT-BR"; // ATENÇÃO A ISSO!!!!
        //CarregarTexto("Valquiria1");
    }

    // Update is called once per frame
    void Update()
    {


        if (dialogoIniciado)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IterarLinhas();
            }
        }

    }

    private string ConcatenarPath(string nomeArq)
    {
        idioma = ControleGlobal.Instancia.GetIdioma();

        string path = "Dialogos/" + idioma + "/" + nomeArq;
        return path;
    }
    
    public void teste()
    {
        Debug.Log("funciona!");
    }


    public void CarregarTexto(string nomeArq)
    {
        // Obtendo caminho do arquivo --
        string caminho = ConcatenarPath(nomeArq);
        // -----------------------------
        
        arquivoTexto = Resources.Load<TextAsset>(caminho);
        strTexto = arquivoTexto.text;
        strLinhas = strTexto.Split('\n');

        dialogoIniciado = true;
        IterarLinhas();

    }

    private string CarregarImg(string nome, string emocao)
    {
        string path = "Imagens/" + nome + "/" + nome + "-" + emocao;
        return path;
    }


    private void SetarEscolhas()
    {
        // Só pra testar!!!!!!!!!!!!!
        txtSim.text = "Sim";
        txtNao.text = "Não";
    }

    private void exibirBtnsEscolha(bool comando)
    {
        float transparencia = ((comando) ? 1 : 0);
        Color corBtnS = btnSim.GetComponent<Image>().color;
        Color corBtnN = btnNao.GetComponent<Image>().color;
        corBtnS.a = transparencia;
        corBtnN.a = transparencia;

        btnSim.GetComponent<Image>().color = corBtnS;
        btnNao.GetComponent<Image>().color = corBtnN;

        btnSim.GetComponent<Button>().interactable = comando;
        btnNao.GetComponent<Button>().interactable = comando;

        if (comando)
        {
            SetarEscolhas();
        }
        else
        {
            txtSim.text = " ";
            txtNao.text = " ";
        }
    }


    // Métodos de click dos botões =========================
    public void btnSimClick()
    {
        Debug.Log("sim");
    }

    public void btnNaoClick()
    {
        Debug.Log("nao");
    }
    // =====================================================

    private void IterarLinhas()
    {
        if(contLinhas <= (strLinhas.Length - 1))
        {
            // *********************************************************
            // *strPartes[0] = string de nome...
            // *strPartes[2] = string de fala...
            // *strPartes[2] = string de emoção...
            // *strPartes[3] = int que indica o tipo de fim da fala...
            // *********************************************************

            strPartes = strLinhas[contLinhas].Split('|');

            txtNome.text = strPartes[0];
            txtFala.text = strPartes[1];

            string caminho = CarregarImg(strPartes[0], strPartes[2]);
            sprite = Resources.Load<Sprite>(caminho);
            imgRosto.GetComponent<Image>().sprite = sprite;

            tipoFim = int.Parse(strPartes[3]);

            contLinhas++;
        }
        else
        {
            dialogoIniciado = false;
            contLinhas = 0;

            if (tipoFim == 0)
            {
                // Vendo o que vai acontecer...
                controleRoteiro.GetComponent<ControleRoteiro>().ChecarPonto();
            }
            //
            //
            //
            //
            // O else abaixo provavelmente vai ficar de fora no fim, mas não mexe, eu ainda posso
            // mudar de ideia!
            else // Tem escolha... 
            {
                exibirBtnsEscolha(true);
            }
            
        }
    }
}
