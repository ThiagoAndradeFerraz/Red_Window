using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public float sensibilidadeMouse = 10;
    public Transform alvo;
    public float distanciaAlvo = 2;

    float yaw;
    float pitch;

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensibilidadeMouse;
        pitch += Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        Vector3 alvoRotacao = new Vector3(pitch, yaw);
        transform.eulerAngles = alvoRotacao;

        transform.position = alvo.position = transform.forward * distanciaAlvo;
    }
}
