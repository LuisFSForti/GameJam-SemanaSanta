using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    [SerializeField] GameObject[] Armas;
    [SerializeField] Material MaterialParedes;
    [SerializeField] float IntervaloMinimoInvocacao;
    private int Indice, Abates;
    private float ProximaRodadaDeInvocacao;
    private bool ChefeNasceu, ChefeMorreu;

    private void Start()
    {
        Indice = 0;
        TrocarArma();
        ChefeNasceu = false;
        ChefeMorreu = false;
        ProximaRodadaDeInvocacao = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        int minutos = TempoEfetivo();

        if (!ChefeNasceu)
        {
            if (GameObject.FindGameObjectsWithTag("Inimigo").Length < 5 * minutos && Time.timeSinceLevelLoad >= ProximaRodadaDeInvocacao)
            {
                foreach (GameObject gerador in GameObject.FindGameObjectsWithTag("Gerador"))
                {
                    StartCoroutine(gerador.GetComponent<Gerador>().Invocar(minutos));
                }
                ProximaRodadaDeInvocacao = Time.timeSinceLevelLoad + IntervaloMinimoInvocacao;
            }
            MaterialParedes.color = Color.white * (6 - minutos) / 8 + Color.red * minutos / 8;
        }
        else
        {
            if (GameObject.FindGameObjectsWithTag("Chefe").Length <= 0)
                ChefeMorreu = true;
        }

        if (minutos >= 8 && !ChefeNasceu)
        {
            ChefeNasceu = true;
            GameObject.FindGameObjectWithTag("GeradorChefe").GetComponent<Gerador>().InvocarChefe();
        }
        if (ChefeMorreu)
        {
            if (GameObject.FindGameObjectsWithTag("Inimigo").Length <= 0)
            {
                GameObject.Find("CameraVitoria").GetComponent<CameraVitoriaController>().Iniciar();
            }
        }
    }

    public void Abate()
    {
        Abates++;
    }

    int TempoEfetivo()
    {
        return (int)Mathf.Round(Time.timeSinceLevelLoad / 60) + 1 + Abates / 100;
    }

    public void TrocarArma()
    {
        StartCoroutine(Sleep(1.5f));
    }

    private IEnumerator Sleep(float tempo)
    {
        yield return new WaitForSeconds(tempo);

        GameObject cabeca = GameObject.Find("Main Camera");
        Instantiate(Armas[Indice], cabeca.transform);
        Indice++;
        if (Indice >= Armas.Length)
        {
            Indice = 0;
        }
    }
}
