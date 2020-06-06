using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoEscolha : MonoBehaviour
{
    public bool btnTipo; // true -> Sim; false -> Não
    private GameObject gerenciadorDialogo;

    // Start is called before the first frame update
    void Start()
    {
        gerenciadorDialogo = GameObject.FindGameObjectWithTag("controle_dialogo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetornarValor()
    {
        gerenciadorDialogo.GetComponent<GerenciadorDialogo>().ReceberResposta(btnTipo);

        /*
        if (btnTipo)
        {
            Debug.Log("sim");
        }
        else
        {
            Debug.Log("nao");
        }*/
        
    }

}
