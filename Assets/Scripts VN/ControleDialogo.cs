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
    public bool tipoFim; // Indica se o fim vai ou não ter uma escolha...
    public string idioma; // Indica o idioma que o jogo foi iniciado...

    // === UI ===
    private Image imgRosto; // Objeto usado para a exibição da sprite de dialogo...
    private Sprite sprite;  // Sprite a ser carregado...
    private Text txtNome;   // Exibe a string de nome...
    private Text txtFala;   // Exibe a string de fala...
    private string emocao;  // Usado para recuperar o arquivo de img certo...


    // === Carga de texto ===
    private TextAsset arquivoTexto; // Arquivo de texto bruto...
    private string strTexto;        // String do texto...
    private string[] strLinhas;     // Texto dividio por linhas...
    private string[] strPartes;     // Linha dividida em partes...

    // === Iteração texto ===
    private int contLinhas = 0;
    private bool dialogoIniciado = false;

    // Start is called before the first frame update
    void Start()
    {
        imgRosto = GameObject.FindGameObjectWithTag("imgRosto").GetComponent<Image>();
        txtNome = GameObject.FindGameObjectWithTag("txtNome").GetComponent<Text>();
        txtFala = GameObject.FindGameObjectWithTag("txtFala").GetComponent<Text>();

        idioma = "PT-BR"; // ATENÇÃO A ISSO!!!!
        CarregarTexto("Valquiria1");
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
        string path = "Dialogos/" + idioma + "/" + nomeArq;
        return path;
    }
    

    private void CarregarTexto(string nomeArq)
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

    private void IterarLinhas()
    {
        if(contLinhas <= (strLinhas.Length - 1))
        {
            strPartes = strLinhas[contLinhas].Split('|');

            txtNome.text = strPartes[0];
            txtFala.text = strPartes[1];

            string caminho = CarregarImg(strPartes[0], strPartes[2]);
            sprite = Resources.Load<Sprite>(caminho);
            imgRosto.GetComponent<Image>().sprite = sprite;

            contLinhas++;
        }
        else
        {
            dialogoIniciado = false;
            contLinhas = 0;
            Debug.Log("acabou");
        }
    }

}
