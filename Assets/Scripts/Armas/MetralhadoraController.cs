using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MetralhadoraController : MonoBehaviour
{
    [SerializeField] private float Municao, Dano, Velocidade, Intervalo, UltimoTiro, Angulo;
    [SerializeField] private GameObject BalaPrefab, CorpoArma;
    private AudioSource ControleSom;
    private VidaJogador VidaJogador;

    void Start()
    {
        UltimoTiro = Time.timeSinceLevelLoad;
        ControleSom = GetComponent<AudioSource>();
        VidaJogador = GameObject.Find("Jogador").GetComponent<VidaJogador>();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= UltimoTiro + Intervalo && Input.GetKey(KeyCode.Mouse0) && !VidaJogador.EstaMorto())
        {
            Atirar();
            UltimoTiro = Time.timeSinceLevelLoad;
        }
        if (Municao <= 0)
            AcabouMunicao();
    }

    void Atirar()
    {
        if (Municao <= 0)
            return;

        Municao--;

        Quaternion direcao = new Quaternion();
        direcao.eulerAngles = new Vector3(Random.Range(-1f, 1f) * Angulo, Random.Range(-1f, 1f) * Angulo, 0) + transform.rotation.eulerAngles;

        GameObject bala = Instantiate(BalaPrefab, transform.position, direcao);
        bala.GetComponent<Tiro>().Criar(Dano, Velocidade);

        ControleSom.PlayOneShot(ControleSom.clip);
    }

    void AcabouMunicao()
    {
        if (!ControleSom.isPlaying)
        {
            GameObject.Find("Controlador").GetComponent<Controlador>().TrocarArma();
            Destroy(this.gameObject);
        }
        else
            CorpoArma.SetActive(false);
    }
}
