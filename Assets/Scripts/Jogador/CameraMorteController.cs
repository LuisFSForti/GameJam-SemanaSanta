using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMorteController : MonoBehaviour
{
    [SerializeField] private Camera VisaoMorte, VisaoPadrao;
    [SerializeField] private Material TelaTransicao;
    [SerializeField] private float Velocidade, TempoTransicao;
    private bool Escurecendo;

    // Start is called before the first frame update
    void Start()
    {
        VisaoMorte.enabled = false;
        VisaoPadrao.enabled = true;
        TelaTransicao.color = new Color(0, 0, 0, 0);
        Escurecendo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(VisaoMorte.enabled)
        {
            if (transform.position.y < 140)
            {
                transform.position += new Vector3(0, Velocidade, 0) * Time.deltaTime;
            }
            else if(!Escurecendo)
            {
                StartCoroutine(Sleep(TempoTransicao));
                Escurecendo = true;
            }                
            else
                TelaTransicao.color += new Color(0, 0, 0, 1.5f / TempoTransicao * Time.deltaTime);
        }
    }

    public void Iniciar()
    {
        VisaoMorte.enabled = true;
        VisaoPadrao.enabled = false;
        VisaoPadrao.GetComponent<CameraJogador>().enabled = false;
    }

    private IEnumerator Sleep(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
