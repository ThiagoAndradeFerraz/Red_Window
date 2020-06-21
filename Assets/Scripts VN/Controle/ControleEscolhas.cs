using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleEscolhas : MonoBehaviour
{
    private TextAsset txtEscolhas;
    public List<ObjEscolha> listaEscolhas = new List<ObjEscolha>();


    // Start is called before the first frame update
    void Start()
    {
        CarregarLista();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PreencherLista(string[] vetor)
    {
        string[] partes;

        foreach (string linha in vetor)
        {
            partes = linha.Split('|');
            int id = int.Parse(partes[0]);
            string sim = partes[1];
            string nao = partes[2];

            listaEscolhas.Add(new ObjEscolha(id, sim, nao));
        }
    }


    private void CarregarLista()
    {
        string idioma = "PT-BR"; // ESSA INFORMAÇÃO TEM QUE VIR DE FONTE EXTERNA!!!!!! APAGAR!!!!

        string caminho = "Escolhas/" + idioma + "/" + "escolhas";
        txtEscolhas = Resources.Load<TextAsset>(caminho);
        string textoBruto = txtEscolhas.text;
        string[] linhasTexto = textoBruto.Split('\n');

        PreencherLista(linhasTexto);
    }



    public void DefinirEscolhas()
    {
        // Define o texto das escolhas com base no momento da história do jogo...





    }

}
