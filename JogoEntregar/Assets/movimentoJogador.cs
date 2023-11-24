using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float velocidadeMovimentoJogador1;
    [SerializeField] private float velocidadeMovimentoJogador2;
    [SerializeField] private GameObject ball; 

    private RigidBody2D rb;
    private Vector2 movimentoJogador; 

    void Start()
    {
      rb = GetComponent<RigidBody>();  
    }

    void Update()
    {
        
    }

    private void ControleJogador1(){

        movimentoJogador = new Vector2(0, Input.GetAxisRaw("vertical")); 
   
    }

    private void ControleJogador2(){

        movimentoJogador = new Vector2(0, Input.GetAxisRaw("vertical")); 
   
    }

}
