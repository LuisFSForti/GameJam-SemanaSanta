using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJogador : MonoBehaviour
{
    [SerializeField] private float VidaMaxima;
    [SerializeField] private Material CorJogador;
    private float VidaAtual;

    void Start()
    {
        VidaAtual = VidaMaxima;
        CorJogador.color = Color.blue;
    }

    public void MudarVida(float valor)
    {
        VidaAtual += valor;
        CorJogador.color = Color.black * (VidaMaxima - VidaAtual) / VidaMaxima + Color.blue * VidaAtual / VidaMaxima;

        if (VidaAtual <= 0)
            GameObject.Find("CameraMorte").GetComponent<CameraMorteController>().Iniciar();
    }
}
