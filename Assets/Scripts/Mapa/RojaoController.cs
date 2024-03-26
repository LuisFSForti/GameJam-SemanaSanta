using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RojaoController : MonoBehaviour
{
    [SerializeField] private int Quantidade;
    [SerializeField] private GameObject ExplosaoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Quaternion angulo = new Quaternion();
        for (int i = 0; i < Quantidade; i++)
        {
            for (int j = 0; j < Quantidade; j++)
            {
                angulo.eulerAngles = new Vector3(360 * i/Quantidade, 360*j/Quantidade, 0);
                Instantiate(ExplosaoPrefab, transform.position, angulo);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject);
    }
}
