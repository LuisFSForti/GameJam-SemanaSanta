using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] GameObject Jogador;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plataforma" || other.tag == "PlataformaQuebravel")
        {
            Jogador.GetComponent<MovimentacaoJogador>().PermitirPulo();
        }
    }
}
