using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJogador : MonoBehaviour
{
    [SerializeField] private float VidaMaxima;
    [SerializeField] private Material CorJogador;
    [SerializeField] private AudioClip[] Gritos;
    [SerializeField] private AudioClip Morte;
    private AudioSource ControleSom;
    private float VidaAtual;
    private bool JaMorreu;

    void Start()
    {
        VidaAtual = VidaMaxima;
        CorJogador.color = Color.blue;
        ControleSom = GetComponent<AudioSource>();
        JaMorreu = false;
    }

    public void MudarVida(float valor)
    {
        VidaAtual += valor;
        CorJogador.color = Color.black * (VidaMaxima - VidaAtual) / VidaMaxima + Color.blue * VidaAtual / VidaMaxima;

        if(valor < 0 && VidaAtual > 0)
        {
            ControleSom.Stop();
            ControleSom.PlayOneShot(Gritos[Random.Range(0, Gritos.Length)]);
        }

        if (VidaAtual <= 0 && !JaMorreu)
        {
            GameObject.Find("CameraMorte").GetComponent<CameraMorteController>().Iniciar();
            ControleSom.Stop();
            ControleSom.PlayOneShot(Morte);
            JaMorreu = true;
        }
    }

    public bool EstaMorto()
    {
        return JaMorreu;
    }
}
