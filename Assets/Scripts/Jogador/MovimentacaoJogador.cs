using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    [SerializeField] private Rigidbody Corpo;
    [SerializeField] private float Velocidade, AlturaPulo, TempoDash, VelocidadeDash, UltimoDash, IntervaloDash;
    private bool PodePular;

    private void Start()
    {
        UltimoDash = Time.timeSinceLevelLoad;
        PodePular = true;
    }


    void Update()
    {
        Corpo.velocity = Vector3.Normalize(transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")) * Velocidade + new Vector3(0, Corpo.velocity.y, 0);

        if(Input.GetKey(KeyCode.LeftShift) && Time.timeSinceLevelLoad >= UltimoDash + IntervaloDash)
        {
            StartCoroutine(Dash());
            UltimoDash = Time.timeSinceLevelLoad;
        }
        if (Input.GetKey(KeyCode.Space) && PodePular)
        {
            Corpo.AddForce(new Vector3(0,1,0) * AlturaPulo);
            PodePular=false;
        }
    }

    public void PermitirPulo()
    {
        PodePular = true;
    }

    IEnumerator Dash()
    {
        float tempoInicio = Time.timeSinceLevelLoad;
        Vector3 direcao = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        float velocidadeQueda = Corpo.velocity.y;

        while (Time.timeSinceLevelLoad < tempoInicio + TempoDash)
        {
            Corpo.velocity = direcao * VelocidadeDash;

            yield return null;
        }
        Corpo.velocity = new Vector3(0, velocidadeQueda, 0) + Corpo.velocity;
    }
}
