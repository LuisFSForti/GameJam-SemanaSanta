using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovimentacaoInimigo : MonoBehaviour
{
    [SerializeField] private float Velocidade, Dano, UltimoGolpe, VidaMaxima, VidaAtual;
    [SerializeField] private Rigidbody Corpo;

    private GameObject Jogador;

    void Start()
    {
        Jogador = GameObject.Find("Jogador");
        UltimoGolpe = Time.timeSinceLevelLoad;
        VidaAtual = VidaMaxima;
    }

    void Update()
    {
        Vector3 rota = Jogador.transform.position - Corpo.position;
        rota.y = 0;

        Corpo.velocity = Vector3.Normalize(rota) * Velocidade + new Vector3(0, Corpo.velocity.y, 0);

        Quaternion foco = Quaternion.LookRotation(rota);
        Corpo.rotation = Quaternion.Slerp(Corpo.rotation, foco, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (UltimoGolpe + 2/Velocidade <= Time.timeSinceLevelLoad)
        {
            if (collision.collider.tag == "Player")
            {
                Jogador.GetComponent<VidaJogador>().MudarVida(-Dano);
                UltimoGolpe = Time.timeSinceLevelLoad;
            }
        }
        if (collision.collider.tag == "PlataformaQuebravel")
            collision.collider.GetComponent<PlataformasController>().Desativar();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (UltimoGolpe + 2/Velocidade <= Time.timeSinceLevelLoad)
        {
            if (collision.collider.tag == "Player")
            {
                Jogador.GetComponent<VidaJogador>().MudarVida(-Dano);
                UltimoGolpe = Time.timeSinceLevelLoad;
            }
        }
    }

    public float CausarDano(float valor)
    {
        float sobra = valor - VidaAtual;
        VidaAtual -= valor;

        if (VidaAtual > VidaMaxima)
            VidaAtual = VidaMaxima;

        if (VidaAtual <= 0)
        {
            GameObject.Find("Controlador").GetComponent<Controlador>().Abate();
            Destroy(this.gameObject);
            return sobra;
        }

        return 0;
    }

    public bool EstaMorto()
    {
        if (VidaAtual <= 0)
            return true;

        return false;
    }
}
