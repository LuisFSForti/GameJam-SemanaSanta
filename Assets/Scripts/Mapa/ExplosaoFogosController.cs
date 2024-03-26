using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoFogosController : MonoBehaviour
{
    [SerializeField] private float Velocidade, TempoDeVida, TempoNascimento;

    private void Start()
    {
        TempoNascimento = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        transform.position += transform.forward * Velocidade * Time.deltaTime;
        if (Time.timeSinceLevelLoad >= TempoNascimento + TempoDeVida)
            Destroy(this.gameObject);
    }
}
