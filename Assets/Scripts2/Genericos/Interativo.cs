using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class Interativo : MonoBehaviour
{
    // ========================================================
    // --------------------------------------------------------
    // DESCRIÇÃO: Classe pai de todos os objetos interativos...
    // --------------------------------------------------------
    // ========================================================

    // Variaveis de processamento de distancia com o player...
    protected GameObject player;
    protected float distMin = 0;
    private bool estaPerto = false;
    private bool estavaPerto = false;

    //*********************************************************

    // Caracteristicas do objeto...
    public string strNome;
    public string strInteracao;
    public string strInteracao2;

    /*
    // Start is called before the first frame update
    void Start()
    {
        EncontrarObjetos();
    }*/

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();
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
                UsandoUI();
            }
            ChecarInput();
        }
        else
        {
            estavaPerto = estaPerto;
            estaPerto = false;
            if (!estaPerto && estavaPerto)
            {
                Debug.Log(" ");
            }
        }
    }

    protected void EncontrarObjetos()
    {
        // Encontra, via tag, os objetos usados no script...
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected void UsandoUI()
    {
        // Checando se o objeto tem mais de uma interação...
        // Teste em debug...
        if (strInteracao2 == null || strInteracao2 == "")
        {
            Debug.Log("nulo" + strNome + " - " + "[E] " + strInteracao);
        }
        else
        {
            Debug.Log("nao nulo" + strNome + " - " + "[E] " + strInteracao + " | " + "[R]" + strInteracao2);
        }
    }

    protected void ChecarInput()
    {
        // Checando qual foi a interação selecionada pelo player...

        //Debug.Log("checou");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("apertou E");
            Interagir1();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("apertou R");
            Interagir2();
        }
    }

    // Métodos abstratos que serão unico para cada objeto filho...
    protected abstract void Interagir1();
    protected abstract void Interagir2();
}