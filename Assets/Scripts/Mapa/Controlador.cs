using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    [SerializeField] GameObject[] Armas;
    [SerializeField] Material MaterialParedes;
    private int Indice, Abates;

    private void Start()
    {
        Indice = 0;
        TrocarArma();
    }

    void Update()
    {
        int minutos = TempoEfetivo();
        if (GameObject.FindGameObjectsWithTag("Inimigo").Length < 5 * minutos)
        {
            foreach (GameObject gerador in GameObject.FindGameObjectsWithTag("Gerador"))
            {
                gerador.GetComponent<Gerador>().Invocar();
            }
        }
        MaterialParedes.color = Color.white * (6-minutos)/8 + Color.red * minutos/8;
        Debug.Log(minutos + ":" + Time.timeSinceLevelLoad);
    }

    public void Abate()
    {
        Abates++;
    }

    public int TempoEfetivo()
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
