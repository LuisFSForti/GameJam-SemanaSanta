using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvocadorController : MonoBehaviour
{
    [SerializeField] private GameObject PrefabPadrao, PrefabRapido, PrefabPequeno, PrefabGrande;
    [SerializeField] private float UltimaInvocacao, Intervalo, Distancia;

    // Start is called before the first frame update
    void Start()
    {
        UltimaInvocacao = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad >= UltimaInvocacao + Intervalo)
        {
            switch (Random.Range(0, 10))
            {
                default:
                case 0:
                case 1:
                case 2:
                case 3:
                    for (int i = 0; i < Random.Range(0, 5); i++)
                        Instantiate(PrefabPadrao, transform.position + new Vector3(Random.value * Distancia, 1, Random.value * Distancia), Quaternion.identity);
                    break;
                case 4:
                case 5:
                case 6:
                    for (int i = 0; i < Random.Range(0, 4); i++)
                        Instantiate(PrefabRapido, transform.position + new Vector3(Random.value * Distancia, 1, Random.value * Distancia), Quaternion.identity);
                    break;
                case 7:
                case 8:
                    for (int i = 0; i < Random.Range(0, 3); i++)
                        Instantiate(PrefabPequeno, transform.position + new Vector3(Random.value * Distancia, 1, Random.value * Distancia), Quaternion.identity);
                    break;
                case 9:
                    Instantiate(PrefabGrande, transform.position + new Vector3(Random.value * Distancia, 1, Random.value * Distancia), Quaternion.identity);
                    break;
            }
            UltimaInvocacao = Time.timeSinceLevelLoad;
        }
    }
}
