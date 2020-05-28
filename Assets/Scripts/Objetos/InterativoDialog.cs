using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InterativoDialog : MonoBehaviour
{
    protected GameObject playerObj;
    protected GameObject objControle;
    protected GameObject gerenciadorDialogo;
    protected float distMin = 20.0f;
    protected GameObject txtAlertas;
    protected GameObject gerenciadorGlobal;

    protected string mensagem;
    protected bool estdAgr = false;
    protected bool estdAntes = true;

    /*
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        objControle = GameObject.FindGameObjectWithTag("Controle_Global");
        txtAlertas = GameObject.FindGameObjectWithTag("txtAlerta");
    }*/

    protected void DetectarPlayer()
    {
        if (Vector3.Distance(this.transform.position, playerObj.transform.position) < distMin)
        {
            estdAgr = true;
            if (estdAgr != estdAntes)
            {
                
                txtAlertas.GetComponent<Text>().text = mensagem;
                estdAntes = estdAgr;
                Interagir();
            }
            Interagir();
        }
        else
        {
            estdAgr = false;
            if (estdAgr != estdAntes)
            {
                LimpaTexto();
                estdAntes = estdAgr;
            }
        }
    }

    protected void setarObjetos()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        objControle = GameObject.FindGameObjectWithTag("Controle_Global");
        txtAlertas = GameObject.FindGameObjectWithTag("txtAlerta");
        gerenciadorDialogo = GameObject.FindGameObjectWithTag("controle_dialogo");
        gerenciadorGlobal = GameObject.FindGameObjectWithTag("Controle_Global");
    } 


    protected void setTexto(string texto)
    {
        mensagem = texto;
    }

    protected void LimpaTexto()
    {
        txtAlertas.GetComponent<Text>().text = " ";
    }

    protected abstract void Interagir();

    protected void ChamarGerenciador(TextAsset arquivo)
    {
        gerenciadorDialogo.GetComponent<GerenciadorDialogo>().LerDados(arquivo);
    }
}
