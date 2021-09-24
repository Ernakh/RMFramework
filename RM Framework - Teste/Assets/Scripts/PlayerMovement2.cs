using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 6.0f;
    public float gravity = 20.0f;
    public float lookDirection = 0.2f;

    private Vector3 moveDirection = Vector3.zero;
    float timer = 0;
    float holdDur = 3f;

    public GameObject trocador1;
    public Animator barraAcao2;

    void Start()
    {
        trocador1 = GameObject.Find("CaixaDeAção(Clone)");
        barraAcao2.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection.normalized), lookDirection);
            }
        }
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);

        
        //parte debaixo [e para a outra caixa
        if (Input.GetButtonDown("Acao") && TrocarCor.possoFazerAcao && TrocarCor.player2NaCaixa)
        {
            barraAcao2.SetBool("Misturando", true);
            timer = Time.time;
        }
        else if (Input.GetButton("Acao") && TrocarCor.possoFazerAcao && TrocarCor.player2NaCaixa)
        {
            if (Time.time - timer > holdDur)
            {
                barraAcao2.SetBool("Misturando", false);
                timer = float.PositiveInfinity;
                TrocarCor.possoFazerAcao = false;
                trocador1.SendMessage("CriarPedido"); //manda mensagem pro objeto
            }
        }
        else if (Input.GetButtonUp("Acao"))
        {
            timer = float.PositiveInfinity;
            barraAcao2.SetBool("Misturando", false);
        }
    }
}

