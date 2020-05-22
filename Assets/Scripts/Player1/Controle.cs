using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    private int velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }
}