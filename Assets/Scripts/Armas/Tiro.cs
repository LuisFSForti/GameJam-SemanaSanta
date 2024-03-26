using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    [SerializeField] private Rigidbody Corpo;
    private float Dano;
    private Vector3 Movimento;

    public void Criar(float dano, float velocidade)
    {
        this.Dano = dano;
        Corpo.velocity = velocidade * transform.forward;
        Movimento = Corpo.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Inimigo")
        { 
            if (!collision.collider.GetComponent<MovimentacaoInimigo>().EstaMorto())
            {
                float sobra = collision.collider.GetComponent<MovimentacaoInimigo>().CausarDano(Dano);
                Debug.Log(sobra);
                if (sobra > 0)
                    Dano = sobra;
                else
                    Destroy(this.gameObject);
            }   
        }
        else if (collision.collider.tag != "Tiro" && collision.collider.tag != "Player")
        {
            Destroy(this.gameObject);
        }
        
        Corpo.velocity = Movimento;
    }
}
