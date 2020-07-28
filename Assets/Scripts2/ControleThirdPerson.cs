using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ControleThirdPerson : MonoBehaviour
{
    // CONTROLE
    public CharacterController controle;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    // ANIMAÇÃO
    public Animator anim;
    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controle.Move(moveDir * speed * Time.deltaTime);

            //float animPercentVelocid = ((lastPosition != transform.position) ? .5f : .0f) * moveDir.magnitude;
            anim.SetFloat("speedPercent", .5f, turnSmoothTime, Time.deltaTime);


            /*
            if (lastPosition != transform.position)
            {
                float animPercentVelocid = .0f * direction.magnitude;
                anim.SetFloat("speedPercent", animPercentVelocid, turnSmoothTime, Time.deltaTime);
            }*/

            // Atualizando a posição anterior...
            lastPosition = transform.position;
        }
        else
        {
            anim.SetFloat("speedPercent", .0f, turnSmoothTime, Time.deltaTime);
        }

        
        Debug.Log(direction);
        
    }
}
