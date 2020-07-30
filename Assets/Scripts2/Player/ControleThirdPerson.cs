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

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }

    private void Movimento()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            if (Input.GetKey(KeyCode.LeftShift)){
                speed = 12f;
                velocidadeAnim = 1;
            }
            else
            {
                speed = 5f;
                velocidadeAnim = 0.5f;
            }

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controle.Move(moveDir * speed * Time.deltaTime);

            // Definindo se tá correndo ou andando...
            //float velocidade = ((Input.GetKeyDown(KeyCode.LeftShift)) ? 1f : 0.5f);

            // Chamando animação de movimento...
            anim.SetFloat("speedAnim", velocidadeAnim, turnSmoothTime, Time.deltaTime);
        }
        else
        {
            // Chamando a animação de Idle
            anim.SetFloat("speedAnim", .0f, turnSmoothTime, Time.deltaTime);
        }
    }

}
