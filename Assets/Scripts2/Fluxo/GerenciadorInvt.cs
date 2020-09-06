using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorInvt : MonoBehaviour
{
    // ========================================================
    // --------------------------------------------------------
    // DESCRIÇÃO: Apesar do nome, essa classe gerencia meio é que tudo mesmo...
    // --------------------------------------------------------
    // ======================================================== 

    // Instancia statica... *************************************
    public static GerenciadorInvt Instancia { get; private set; }
    //***********************************************************

    //*****************************
    // Inventário...
    public int contLampadas = 0;
    public int pilulaVermelha = 0;
    public int pilulaLaranja = 0;
    //*****************************

    //*****************************
    // Controle fala...
    public bool falando = false; // Indica se uma fala está sendo dita ou não...
    //*****************************

    //*****************************
    // Estados...
    public bool pausado = false;
    public bool esperandoSenha = false;
    //*****************************

    //*****************************
    // Estagios dos NPCs...
    private int isaacEst = 1;
    private int carlosEst = 1;

    //******************************************
    // Getters e Setters dos estagios de NPCs...
    
    // Isaac
    public int getIsaac()
    {
        return isaacEst;
    }

    public void setIsaac(int est)
    {
        isaacEst = est;
    }

    //******************************************



    private void Awake()
    {
        // Aplicando singleton...
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        // *************************************
        // Opção de pausar o game... 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!esperandoSenha) // Impedindo de descongelar em determindas situações...
            {
                int comando = (pausado) ? 1 : 0;
                PausarParcialmente(comando);
            }
        }
        // *************************************
    }

    // Pausa parcialmente o jogo...
    public void PausarParcialmente(int comando)
    {
        // 0 -> Pausa | 1 -> Continuar
        Time.timeScale = comando;
        pausado = (comando == 0);
        //Cursor.visible = (comando == 0);
    }
}