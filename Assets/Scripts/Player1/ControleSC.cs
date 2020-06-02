using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSC : MonoBehaviour
{

    int velocidade = 20;
    bool viradoDireita = true;
    bool estaNoChao = false;
    Rigidbody rb;
    bool ligouGrav = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        //Caindo();
    }

    private void Movimento()
    {

        // MOVIMENTO ESQUERDA - DIREITA ----------------

        if (Input.GetKey(KeyCode.A))
        {
            float x = velocidade * Time.deltaTime;
            transform.Translate(x, 0, 0);
            
            if (viradoDireita)
            {
                transform.Rotate(0, 180, 0);
                viradoDireita = false;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            float x = velocidade * Time.deltaTime;
            transform.Translate(x, 0, 0);

            if (!viradoDireita)
            {
                transform.Rotate(0, 180, 0);
                viradoDireita = true;
            }
        }

        // ---------------------------------------------

        // Pulo ----------------------------------------
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            estaNoChao = false;
        }
        // ---------------------------------------------
    }

    // Checando se está no chão
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "plataforma")
        {
            estaNoChao = true;
            ligouGrav = true;
        }
    }

    private void Caindo()
    {
        if (!estaNoChao && ligouGrav)
        {
            rb.AddForce(new Vector3(0, -5, 0), ForceMode.Impulse);
            ligouGrav = false;
        }
    }



}
