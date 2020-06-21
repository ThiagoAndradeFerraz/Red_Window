using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer2 : MonoBehaviour
{
    private bool estaNoChao = false;

    Rigidbody rb;

    private bool estaPausado;

    private GameObject lanterna;
    private bool lanternaStatus = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chao" || collision.gameObject.tag == "ponte")
        {
            estaNoChao = true;
            lanterna = GameObject.FindGameObjectWithTag("lanterna");
        }
    }


    private void Movimento()
    {
        // Corrida
        bool correndo = Input.GetKey(KeyCode.LeftShift);
        int velocidade = ((correndo) ? 3 : 2);

        // Pulo
        /*
        bool pulou = Input.GetKey(KeyCode.Space);
        int velocidadePulo = ((pulou) ? 10 : 0);*/
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
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
    }

}
