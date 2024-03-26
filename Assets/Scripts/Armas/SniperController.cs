using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SniperController : MonoBehaviour
{
    [SerializeField] private float Municao, Dano, Velocidade, Intervalo, UltimoTiro, Angulo;
    [SerializeField] private GameObject BalaPrefab;

    void Start()
    {
        UltimoTiro = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        if(Time.timeSinceLevelLoad >= UltimoTiro + Intervalo && Input.GetKey(KeyCode.Mouse0))
        {
            Atirar();
            UltimoTiro = Time.timeSinceLevelLoad;
            AcabouMunicao();
        }
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
    }

    void AcabouMunicao()
    {
        if (Municao <= 0)
        {
            GameObject.Find("Controlador").GetComponent<Controlador>().TrocarArma();
            Destroy(this.gameObject);
        }
    }
}
