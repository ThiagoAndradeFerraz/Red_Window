using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    public GameObject telaPreta;
    Rigidbody rb;
    bool gravidade = true; // APAGAR DEPOIS
    bool exibirTelaPreta = false;
    bool pdMovimentar = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pdMovimentar)
        {
            Movimento();
        }
        
    }

    protected void Movimento()
    {
        // Corrida
        bool correndo = Input.GetKey(KeyCode.LeftShift);
        int velocidade = ((correndo) ? 20 : 10);

        // Pulo
        bool pulou = Input.GetKey(KeyCode.Space);
        int velocidadePulo = ((pulou) ? 10 : 0);

        // Movimento WASD
        float x = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * velocidade * Time.deltaTime;
        float y = velocidadePulo * Time.deltaTime;
        transform.Translate(x, y, z);

        // Movimento mouse
        float mouseX = Input.GetAxis("Mouse X") * 10f;
        transform.Rotate(0, mouseX, 0);

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

        // Liga / Desliga tela preta de dialogo
        if (Input.GetKeyDown(KeyCode.H))
        {
            exibirTelaPreta = !exibirTelaPreta;
            EscurecerTela(exibirTelaPreta);
        }

        // ============================================
        // ============================================
    }

    public void EscurecerTela(bool comando)
    {
        telaPreta.GetComponent<MeshRenderer>().enabled = comando;

        pdMovimentar = !comando;
    }
}