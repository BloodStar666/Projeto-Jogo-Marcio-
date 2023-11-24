using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{

    [SerializedField] private float velocidadeInicial = 10;
    [SerializedField] private float aumentoDeVelocidade = 0.25f;
    [SerializedField] private Text Pontuacaodojogador1;
     [SerializedField] private Text Pontuacaodojogador2;

     private int hitCounter;
     private RigidBody2D rb;



    void Start()
    {
        rb = GetComponent<RigidBody2D>(); 
        Invoke("BolaInicial", 2f); 
    }

    private void FixedUpdate(){
        rb.velocidade = Vector2.ClampMagnitude(rb.velocidade, velocidadeInicial + (aumentoDeVelocidade + hitCounter));
    }

    privat void BolaInicial{
        rb.velocidade = new Vector2(-1, 0) * (velocidadeInicial + aumentoDeVelocidade + hitCounter); 
    }

    private void ResetarBola()
    {
        rb.velocidade = new Vector2(0, 0);
        transform.position = new Vector2(0, 0); 
        hitCounter = 0;
        Invoke("BolaInicial", 2f); 
    }

    private void quicar(Transform myObject)
    {
        hitCounter++;

        Vector2 bolaPosicao = transform.position;
        Vector2 jogador1Posicao = myObject.position; 
        Vector2 jogador2Posicao = myObject.position; 

        float direcaoX , direcaoY;
        if(transform.position.x > 0){
            direcaoX = -1; 
        }
        else
        {
            direcaoX = 1; 
        }
        direcaoY = (bolaPosicao.y - jogador1Posicao.y) / myObject.GetComponent<Collider2D>.bounds.size.y;
        if(direcaoY == 0){
            direcaoY = 0.25f;
        }

        direcaoY = (bolaPosicao.y - jogador2Posicao.y) / myObject.GetComponent<Collider2D>.bounds.size.y;
        if(direcaoY == 0){
            direcaoY = 0.25f;
        }

        rb.velocidade = new Vector2(direcaoX, direcaoY) * (velocidadeInicial + (aumentoDeVelocidade + hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Raquete1" || collision.gameObject.name == "Raquete2"){
            quicar(collision.transform);
        }
    }

    private void OnTrigggerEnter2D(Collider2D collision){
        if(transform.position.x > 0){
            ResetarBola();
            Pontuacaodojogador1.text = (int.Parse(Pontuacaodojogador2.text) + 1).ToString(); 
        }
    }

}
