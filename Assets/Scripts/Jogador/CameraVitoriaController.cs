using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraVitoriaController : MonoBehaviour
{
    [SerializeField] private GameObject RojaoPrefab;
    [SerializeField] private GameObject[] Geradores;
    [SerializeField] private Camera VisaoVitoria, VisaoPadrao;
    [SerializeField] private Material TelaTransicao;
    [SerializeField] private float Velocidade, TempoTransicao, IntervaloRojoes, UltimoRojao;
    private bool Escurecendo;

    // Start is called before the first frame update
    void Start()
    {
        VisaoVitoria.enabled = false;
        VisaoPadrao.enabled = true;
        TelaTransicao.color = new Color(0, 0, 0, 0);
        Escurecendo = false;
        UltimoRojao = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if(VisaoVitoria.enabled)
        {
            if (transform.position.y < 140)
                transform.position += new Vector3(0, Velocidade, 0) * Time.deltaTime;
            else if(!Escurecendo)
            {
                StartCoroutine(Sleep(TempoTransicao));
                Escurecendo = true;
            }                
            else
            {
                TelaTransicao.color += new Color(0, 0, 0, 1.1f / TempoTransicao * Time.deltaTime);
            }

            if (Time.timeSinceLevelLoad > UltimoRojao + IntervaloRojoes && Escurecendo)
            {
                UltimoRojao = Time.timeSinceLevelLoad;
                Instantiate(RojaoPrefab, Geradores[Random.Range(0, Geradores.Length - 1)].transform);
            }
        }
    }

    public void Iniciar()
    {
        VisaoVitoria.enabled = true;
        VisaoPadrao.enabled = false;
        VisaoPadrao.GetComponent<CameraJogador>().enabled = false;
    }

    private IEnumerator Sleep(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
