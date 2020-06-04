using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private GameObject gerenciadorGlobal;

    // Start is called before the first frame update
    void Start()
    {
        gerenciadorGlobal = GameObject.FindGameObjectWithTag("Controle_Global");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gerenciadorGlobal.GetComponent<GerenciadorGlobal>().pegouFruta = true;
            gerenciadorGlobal.GetComponent<GerenciadorGlobal>().PegarFruta();
            Destroy(gameObject);
        }
    }
}
