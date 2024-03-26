using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    [SerializeField] private Rigidbody Corpo;
    private float Dano;
    private Vector3 Movimento;
    private bool AcertouInimigo;

    public void Criar(float dano, float velocidade)
    {
        this.Dano = dano;
        Corpo.velocity = velocidade * transform.forward;
        Movimento = Corpo.velocity;
        AcertouInimigo = false;
    }

    private void Update()
    {
        if (transform.position.y < -20)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (AcertouInimigo)
        {
            AcertouInimigo = false;
        }
        else if (collision.collider.tag != "Tiro" && collision.collider.tag != "Player")
        {
            Destroy(this.gameObject);
        }
        
        Corpo.velocity = Movimento;
    }

    public float CausarDano(float vida, float multiplicador)
    {
        float aux = vida;
        vida -= Dano * multiplicador;
        Dano -= aux;

        if (Dano <= 0)
            Destroy(this.gameObject);
        else
            AcertouInimigo = true;

        return vida;
    }
}
