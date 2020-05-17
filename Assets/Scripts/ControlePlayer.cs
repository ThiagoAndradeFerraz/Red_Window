using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer : MonoBehaviour
{
    Rigidbody rb;
    int velocidadeAndar = 1;
    int velocidadeCorrer = 3;
    Animator anim;

    float turnSmoothTime = 0.2f;
    float turnSmoothVelocid;

    float speedSmoothTime = 0.1f;
    float speedSmoothVelocid;
    float velocidadeAgr;

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
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if(inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, 
                targetRotation, ref turnSmoothVelocid, turnSmoothTime);
        }

        bool correndo = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((correndo) ? velocidadeCorrer : velocidadeAndar) * inputDir.magnitude;
        velocidadeAgr = Mathf.SmoothDamp(velocidadeAgr, targetSpeed, ref speedSmoothVelocid, speedSmoothTime);


        transform.Translate(transform.forward * velocidadeAgr * Time.deltaTime, Space.World);

        float animPercentVelocid = ((correndo) ? 1 : .5f) * inputDir.magnitude;
        anim.SetFloat("speedPercent", animPercentVelocid, speedSmoothTime, Time.deltaTime);
    }
}
