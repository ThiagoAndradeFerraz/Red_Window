using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controle : MonoBehaviour
{
    private GameObject gerenciadorGlobal;
    //private GameObject camera;

    public GameObject telaPreta;
    private Text txtFala;
    Rigidbody rb;
    bool estaNoChao = true;

    // Lanterna
    private GameObject lanterna;
    private bool lanternaStatus = false;

    // Movimento
    bool gravidade = true; // APAGAR DEPOIS
    bool pdMovimentar = true;

    // Pensamento
    public TextAsset pensamento1;
    private string texto;
    private string[] linhas;
    private int cont = 0;
    private bool pensando = false; // FIQUE ATENTO A ISSO!!!

    // Controle pensamentos
    private bool pens1 = true;


    // Pausa
    public bool estaPausado = false;

    


    // Checando se está no chão
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            estaNoChao = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        txtFala = GameObject.FindGameObjectWithTag("txtFala").GetComponent<Text>();
        gerenciadorGlobal = GameObject.FindGameObjectWithTag("Controle_Global");
        lanterna = GameObject.FindGameObjectWithTag("lanterna");
        //camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (pdMovimentar)
        {
            Movimento();
            ControlePensamentos();
        }

        // Iterando linhas de pensamento
        if (pensando)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Iterar();
            }
        }

        Pausar();
    }

    protected void Movimento()
    {
        // Corrida
        bool correndo = Input.GetKey(KeyCode.LeftShift);
        int velocidade = ((correndo) ? 20 : 10);

        // Pulo
        /*
        bool pulou = Input.GetKey(KeyCode.Space);
        int velocidadePulo = ((pulou) ? 10 : 0);*/
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            estaNoChao = false;
        }


        // Movimento WASD
        float x = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * velocidade * Time.deltaTime;
        //float y = velocidadePulo * Time.deltaTime;
        transform.Translate(x, 0, z);

        // Movimento mouse --------------------------------
        float mouseX = ((estaPausado) ? 0 : (Input.GetAxis("Mouse X") * 10f));
        transform.Rotate(0, mouseX, 0);
        

        // Liga / Desliga lanterna 
        if (Input.GetKeyDown(KeyCode.H))
        {
            lanterna.GetComponent<Light>().enabled = lanternaStatus;
            lanternaStatus = !lanternaStatus;
        }


        





        // ============================================
        // Funções exclusivas para testes! ==============

        // Liga / Desliga a gravidade
        if (Input.GetKeyDown(KeyCode.G))
        {
            gravidade = !gravidade;
            rb.useGravity = gravidade;

            if (gravidade)
            {
                Debug.Log("Gravidade: ON");
            }
            else
            {
                Debug.Log("Gravidade: OFF");
            }
        }

        // ============================================
        // ============================================
    }

    public void EscurecerTela(bool comando)
    {
        telaPreta.GetComponent<MeshRenderer>().enabled = comando;

        pdMovimentar = !comando;
    }

    // Pausa
    private void Pausar()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado)
            {
                Time.timeScale = 1;
                EscurecerTela(false); // PODE CAUSAR BUG, CUIDADO!!!!!!
                txtFala.enabled = true;
                estaPausado = false;
            }
            else
            {
                Time.timeScale = 0;
                EscurecerTela(true);
                txtFala.enabled = false;
                estaPausado = true;
            }
        }
    }

    // Funções usadas ao longo da história ------------
    public void ExibirPensamento(TextAsset arquivo)
    {
        texto = arquivo.text;
        linhas = texto.Split('\n');
        Iterar();
    }

    private void LimparPensamento()
    {
        txtFala.text = " ";
    }

    private void Iterar()
    {
        if (!estaPausado)
        {
            if (cont <= (linhas.Length - 1))
            {
                txtFala.text = linhas[cont];
                cont++;
                pensando = true;

            }
            else
            {
                cont = 0;
                LimparPensamento();
                //gerenciadorGlobal.GetComponent<GerenciadorGlobal>().SetarObjetivo("volte para a nave");
                pensando = false;
            }
        }
        
    }

    private void ControlePensamentos()
    {
        if (pens1)
        {
            ExibirPensamento(pensamento1);
            pens1 = false;
        }
    }

    // -----------------------------------------------
}