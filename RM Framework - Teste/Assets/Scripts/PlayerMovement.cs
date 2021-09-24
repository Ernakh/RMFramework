using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 6.0f;
    public float gravity = 20.0f;
    public float lookDirection = 0.2f;

    private Vector3 moveDirection = Vector3.zero;
    float timer = 0;
    float holdDur = 3f;
    public GameObject trocador1;
    private GameObject _barraAcao1;
    private Animator barraAcao1;

    void Start()
    {
        _barraAcao1 = GameObject.Find("BarraAcao1");
        barraAcao1 = _barraAcao1.GetComponent<Animator>();
        trocador1 = GameObject.Find("CaixaDeAção(Clone)");
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

        if (Input.GetKeyDown(KeyCode.B) && TrocarCor.possoFazerAcao && TrocarCor.playerNaCaixa)
        {
            barraAcao1.SetBool("Misturando", true);
            timer = Time.time;
        }
        else if (Input.GetKey(KeyCode.B) && TrocarCor.possoFazerAcao && TrocarCor.playerNaCaixa)
        {
            if (Time.time - timer > holdDur)
            {
                barraAcao1.SetBool("Misturando", false);
                timer = float.PositiveInfinity;
                TrocarCor.possoFazerAcao = false;
                trocador1.SendMessage("CriarPedido"); //manda mensagem pro objeto
            }
        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            timer = float.PositiveInfinity;
            barraAcao1.SetBool("Misturando", false);
        }

    }
}

