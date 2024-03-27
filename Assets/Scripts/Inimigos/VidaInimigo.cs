using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    [SerializeField] private float VidaMaxima;
    [SerializeField] private float VidaAtual;

    // Start is called before the first frame update
    void Start()
    {
        VidaAtual = VidaMaxima;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Tiro")
        {
            if (VidaAtual > 0)
            {
                float multiplicador = 1;
                switch (collision.GetContact(0).thisCollider.tag)
                {
                    default:
                    case "Corpo":
                        break;
                    case "Critico":
                        multiplicador = 2;
                        break;
                    case "ExtraCritico":
                        multiplicador = 10;
                        break;
                    case "Nulo":
                        multiplicador = 0;
                        break;
                }

                VidaAtual = collision.collider.GetComponent<Tiro>().CausarDano(VidaAtual, multiplicador);

                if (VidaAtual > VidaMaxima)
                    VidaAtual = VidaMaxima;

                if (VidaAtual <= 0)
                {
                    GameObject.Find("Controlador").GetComponent<Controlador>().Abate();
                    Destroy(this.gameObject);
                }
            }
            else
            {
                collision.collider.GetComponent<Tiro>().CausarDano(0, 1);
            }
        }
    }
}
