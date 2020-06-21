using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleRoteiro : MonoBehaviour
{
    // *****************************************
    // *         CONTROLE DE ROTEIRO           *
    // *****************************************

    private int idCena;     // Muda sempre que uma conversa é terminada...
    private GameObject controleDialogo; // Objeto que possui o sistema de dialogo...
    

    void Start()
    {
        controleDialogo = GameObject.FindGameObjectWithTag("controle_dialogo");
        idCena = ControleGlobal.Instancia.GetIdCena();
    }

    private void Update()
    {
        // Começando o fluxo ... --------------
        if(idCena == 1)
        {
            CarregarTexto("Valquiria1");
            idCena++;
        }
        // ------------------------------------
    }

    private void CarregarTexto(string nomeArq)
    {
        controleDialogo.GetComponent<ControleDialogo>().CarregarTexto(nomeArq);
    }

    private void MudarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    private void IncrementarIdCena()
    {
        idCena++;
        ControleGlobal.Instancia.SetIdCena(idCena);
    }

    public void ChecarPonto()
    {
        switch (idCena)
        {
            case 1:
                CarregarTexto("Valquiria1");
                break;
     
            case 2:
                IncrementarIdCena();
                MudarCena("GAMEPLAY");
                break;
            
        }
    }
}
