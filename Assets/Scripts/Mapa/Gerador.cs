using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    [SerializeField] private GameObject PrefabPadrao, PrefabRapido, PrefabPequeno, PrefabGrande, PrefabInvocador, PrefabChefe;

    public void Invocar()
    {
        int minutos = GameObject.Find("Controlador").GetComponent<Controlador>().TempoEfetivo();
        if (minutos < 4)
            if (Random.Range(0, 100) < 25 * minutos)
            {
                return;
            }

        for (int i = 0; i < minutos*10; i++)
        {
            switch (Random.Range(minutos, 5 * minutos))
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    Instantiate(PrefabPadrao, transform);
                    i++;
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    Instantiate(PrefabRapido, transform);
                    i += 2;
                    break;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    Instantiate(PrefabPequeno, transform);
                    i += 3;
                    break;
                case 21:
                case 22:
                
                    Instantiate(PrefabGrande, transform);
                    i += 5;
                    break;
                case 23:
                case 24:
                case 25:
                default:
                    Instantiate(PrefabInvocador, transform);
                    i += 7;
                    break;
            }
        }
    }

    public void InvocarChefe()
    {
        Instantiate(PrefabChefe, transform);
    }
}
