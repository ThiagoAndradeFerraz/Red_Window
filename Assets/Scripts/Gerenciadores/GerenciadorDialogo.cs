using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDialogo : MonoBehaviour
{
    private GameObject player;


    public List<Sprite> rostos = new List<Sprite>();

    protected Image imgRosto;
    protected Text txtNome;
    protected Text txtFala;

    protected string texto;
    protected string[] linhas;
    protected string[] partes;
    protected int cont;

    protected string strNome;
    protected string strFala;
    protected int indexRosto;

    bool dialogoIniciado = false;


    bool comando = true; // APAGAR

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        imgRosto = GameObject.FindGameObjectWithTag("imgRosto").GetComponent<Image>();
        txtNome = GameObject.FindGameObjectWithTag("txtNome").GetComponent<Text>();
        txtFala = GameObject.FindGameObjectWithTag("txtFala").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

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

            txtNome.text = strNome;
            txtFala.text = strFala;
            imgRosto.sprite = rostos[indexRosto];

            cont++;
        }
        else
        {
            cont = 0;
            ExibirImagem(false);
            ApagaTexto();
            dialogoIniciado = false;
            player.GetComponent<Controle>().EscurecerTela(false);
            Debug.Log("acabou");
        }

    }
}