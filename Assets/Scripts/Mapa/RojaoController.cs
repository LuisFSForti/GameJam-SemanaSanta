using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RojaoController : MonoBehaviour
{
    [SerializeField] private int Quantidade;
    [SerializeField] private GameObject ExplosaoPrefab;
    private AudioSource ControleSom;

    // Start is called before the first frame update
    void Start()
    {
        ControleSom = GetComponent<AudioSource>();

        Quaternion angulo = new Quaternion();
        for (int i = 0; i < Quantidade; i++)
        {
            for (int j = 0; j < Quantidade; j++)
            {
                angulo.eulerAngles = new Vector3(360 * i/Quantidade, 360*j/Quantidade, 0);
                Instantiate(ExplosaoPrefab, transform.position, angulo);
            }
        }
        StartCoroutine(SomTiro());
    }

    IEnumerator SomTiro()
    {
        ControleSom.PlayOneShot(ControleSom.clip);
        yield return new WaitForSeconds(ControleSom.clip.length);

        Destroy(this.gameObject);
    }
}
