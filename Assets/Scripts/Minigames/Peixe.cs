using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peixe : MonoBehaviour
{
    private int velocidade;
    private float tempo;
    public bool negativo;
    private int multiplicador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        multiplicador = (negativo) ? -1 : 0;

        velocidade = 360 * multiplicador;

        tempo += Time.deltaTime;

        Debug.Log(tempo);

        if (tempo > 1.2)
        {
            velocidade = 1660 * multiplicador;
            
        }
        
        if(tempo > 5)
        {
            Destroy(gameObject);
        }

        float x = velocidade * Time.deltaTime;

        transform.Translate(x, 0, 0);
    }
}
