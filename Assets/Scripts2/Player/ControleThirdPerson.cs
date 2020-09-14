using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ControleThirdPerson : MonoBehaviour
{
    // CONTROLE
    public CharacterController controle;
    private float speed = 5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    // ANIMAÇÃO
    public Animator anim;
    private float velocidadeAnim = 0;

    // Update is called once per frame
    void Update()
    {
        if (!GerenciadorInvt.Instancia.pausado)
        {
            Movimento(); // Controle de movimentação...
            Ataque(); // Controle de ataque...
            Desviar();

            /*
            taNoChao = controle.isGrounded;
            Debug.Log(taNoChao);*/
        }
    }

    private void Movimento()
    {
        // Obtendo o input direcional...
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) // Teve input...
        {
            Andar(direction);
        }
        else // Está parado...
        {
            if (!controle.isGrounded)
            {
                Andar(direction); // Aplicando gravidade caso esteja parado e não esteja no chão...
            }
        }


        /*
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            // DETERMINADA VELOCIDADE DE CORRIDA...
            /*if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 12f;
                velocidadeAnim = 5f;
            }
            else
            {
                speed = 5f;
                velocidadeAnim = 1f;
            }

            // PROVISÓRIO!!!!!!!!!!
            speed = 9f;
            velocidadeAnim = 5f;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Gravidade...
            moveDir.y -= 9.81f;

            controle.Move(moveDir * speed * Time.deltaTime);

            anim.SetFloat("speedAnim", velocidadeAnim);

            anim.SetBool("andando", true);
        }
        else
        {
            // Chamando a animação de Idle...
            anim.SetFloat("speedAnim", .0f);
            anim.SetBool("andando", false);
        }*/

    }

    // Usado no método Movimento!
    private void Andar(Vector3 direction)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        /*
        // DETERMINADA VELOCIDADE DE CORRIDA...
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12f;
            velocidadeAnim = 5f;   
        }
        else
        {
            speed = 5f;
            velocidadeAnim = 1f;    
        }*/

        // PROVISÓRIO!!!!!!!!!!
        speed = 9f;
        velocidadeAnim = 5f;

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        
        // Gravidade...
        moveDir.y -= 9.81f;

        controle.Move(moveDir * speed * Time.deltaTime);     
    }



    private void Ataque()
    {
        // Deixando true ao apertar o botão...
        if (Input.GetMouseButtonDown(0))
        {
            //anim.SetTrigger("h1");
            anim.SetBool("h1Bool", true);
        }
    }



    private void Desviar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, 0, 5);
        }
    }
}