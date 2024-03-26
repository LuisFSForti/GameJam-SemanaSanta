using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasController : MonoBehaviour
{
    private bool Ativo;
    private MeshRenderer Textura;
    private BoxCollider Colisao;
    private float TempoColisao, TempoInativo;

    void Start()
    {
        Ativo = true;
        Textura = GetComponent<MeshRenderer>();
        Colisao = GetComponent<BoxCollider>();
        TempoColisao = 0;
        TempoInativo = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Ativo)
            if(Time.timeSinceLevelLoad >= TempoColisao + TempoInativo)
            {
                Textura.enabled = true;
                Colisao.enabled = true;
                Ativo = true;
            }
    }

    public void Desativar()
    {
        Textura.enabled = false;
        Colisao.enabled = false;
        Ativo = false;
        TempoColisao = Time.timeSinceLevelLoad;
    }
}
