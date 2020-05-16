using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer : MonoBehaviour
{
    Rigidbody rb;
    int velocidade = 1;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Controle();
    }

    void Controle()
    {
        Vector3 vetorMovimento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += vetorMovimento * velocidade * Time.deltaTime;

        if (vetorMovimento != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(vetorMovimento);
        }

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("boolCorrendo", true);
                anim.SetBool("boolAndando", false);
                anim.SetBool("boolParado", false);
            }
            else
            {
                anim.SetBool("boolAndando", true);
                anim.SetBool("boolCorrendo", false);
                anim.SetBool("boolParado", false);
            }
        }
        else
        {
            anim.SetBool("boolCorrendo", false);
            anim.SetBool("boolAndando", false);
            anim.SetBool("boolParado", true);
        }

        


    }
}
