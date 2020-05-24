using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDialogo : MonoBehaviour
{
    protected Image imgRosto;
    protected Text txtNome;
    protected Text txtFala;

    protected string texto;
    protected string[] linhas;





    bool comando = true; // APAGAR

    // Start is called before the first frame update
    void Start()
    {
        imgRosto = GameObject.FindGameObjectWithTag("imgRosto").GetComponent<Image>();
        txtNome = GameObject.FindGameObjectWithTag("txtNome").GetComponent<Text>();
        txtFala = GameObject.FindGameObjectWithTag("txtFala").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (texto != null)
        {
            Debug.Log("carregou arquivo");
        }
        /*
        // APENAS TESTE ---
        Dialogo dadosDialog = new Dialogo();
        dadosDialog.fala = "olá";
        // ----------------
        */
    }

    public void Iterar(Dialogo dadosDiag)
    {
        
    }





}