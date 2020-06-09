using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDialogo : MonoBehaviour
{
    private GameObject player;


    // ****************************************************
    public List<Sprite> rostos = new List<Sprite>();
    // FASE 1 ---------------
    // 0 -> NPC-ROSTO1;
    // 1 -> NPC-ROSTO2;
    // 2 -> CENA-MONOLITO;
    // ----------------------
    // ****************************************************


    protected Image imgRosto;
    protected Text txtNome;
    protected Text txtFala;

    // TEXTO A SER EXIBIDO -------------
    protected string texto;    // Texto bruto...
    protected string[] linhas; // Texto separado em linhas...
    protected string[] partes; // Linha dividia em partes...
    protected int cont;        // Contador usado para o processo de Iteração...

    protected string strNome;     // Nome a ser exibido...
    protected string strFala;     // Texto a ser exibido...
    protected int indexRosto;     // Define qual imagem de rosto será usada...
    protected string escolhaChar; // Caractere usado para definir a variavel 'escolha'...
    protected bool escolha;       // Define se o fim do dialogo vai levar a uma escolha ou não...


    public bool dialogoIniciado = false;

    // ---------------------------------

    // BOTÕES ---------------
    // Essa variaveis são publicas pois tais objetos precisam ser referenciados pelo Inspector,
    //pois por padrão eles são desativados...
    public GameObject btnSim; 
    public GameObject btnNao;
    public bool retornoBtn;   // Valor retornado dependendo do botão clicado; 
    // ----------------------

    // OBJETOS CONVERSAVEIS -------
    private GameObject casa1;
    // ----------------------------

    bool comando = true; // APAGAR

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        imgRosto = GameObject.FindGameObjectWithTag("imgRosto").GetComponent<Image>();
        txtNome = GameObject.FindGameObjectWithTag("txtNome").GetComponent<Text>();
        txtFala = GameObject.FindGameObjectWithTag("txtFala").GetComponent<Text>();

        // OBJETOS DE DIALOGO ----
        casa1 = GameObject.FindGameObjectWithTag("casa1");
        // -----------------------

        // Definindo caracteristicas iniciais dos botões...
        btnSim.GetComponent<BotaoEscolha>().btnTipo = true;
        btnNao.GetComponent<BotaoEscolha>().btnTipo = false;
    }

    // Update is called once per frame
    void Update()
    {

        //ExibirEscolha(); // ESTÁ AQUI APENAS PARA TESTES!!!!

        if (dialogoIniciado)
        {


            if (Input.GetMouseButtonDown(0))
            {
                Iterar();
            }
        }




        // TESTE
        if (Input.GetKeyDown(KeyCode.I))
        {
            comando = !comando;
            ExibirImagem(comando);

        }
    }

    private void ExibirImagem(bool comando)
    {
        float transparencia = ((comando) ? 1 : 0);
        Color cor = imgRosto.color;
        cor.a = transparencia;
        imgRosto.color = cor;
    }

    private void ApagaTexto()
    {
        txtNome.text = " ";
        txtFala.text = " ";
    }

    public void LerDados(TextAsset arquivo)
    { 
        texto = arquivo.text;
        linhas = texto.Split('\n');
        player.GetComponent<Controle>().EscurecerTela(true);
        dialogoIniciado = true;

        ExibirImagem(true);
        Iterar();
    }

    public void Iterar()
    {
        if(cont <= (linhas.Length - 1))
        {
            partes = linhas[cont].Split('|');
            strNome = partes[0];
            strFala = partes[1];
            indexRosto = int.Parse(partes[2]);
            escolhaChar = partes[3];

            // escolhaChar = N -> Não tem escolha...
            // escolhaChar = E -> Tem escolha...
            escolha = ((escolhaChar.Equals("N") ? false : true));

            txtNome.text = strNome;
            txtFala.text = strFala;
            imgRosto.sprite = rostos[indexRosto];

            cont++;
        }
        else
        {
            ApagaTexto();
            cont = 0;
            dialogoIniciado = false;

            if (escolha) // Caso tenha uma escolha...
            {
                ExibirEscolha();
            }
            else // Caso o dialogo acabe sem escolha...
            {
                ExibirImagem(false);
                player.GetComponent<Controle>().EscurecerTela(false);
            }
        }
    }

    // Cuidando dos botões...
    private void ExibirEscolha()
    {
        btnSim.SetActive(true);
        btnNao.SetActive(true);

    }

    private void OcultarEscolha()
    {
        btnSim.SetActive(false);
        btnNao.SetActive(false);
    }


    public void ReceberResposta(bool resposta)
    {
        OcultarEscolha();
        retornoBtn = resposta;

        //Aonde a magica vai acontecer...

        switch(casa1.GetComponent<Casa1>().idConversa)
        {
            case 3:
                // Atualizando a idConversa
                casa1.GetComponent<Casa1>().idConversa++; // Icrementando id da próxima conversa...
                casa1.GetComponent<Casa1>().escolha1 = resposta; // Salvando a resposta...
                casa1.GetComponent<Casa1>().SelecionarArquivo();

                break;
        }


       

    }


    // ----------------------


}