using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popupcycle : MonoBehaviour
{
    public GameObject[] PopUps; 
    float tiempoDeEspera = 10.0f;

    private int indiceActual = 0;

    private void Start()
    {
        DesactivarTodosLosObjetos();

        InvokeRepeating("CambiarObjetoActivo", 0f, tiempoDeEspera);
    }

    private void CambiarObjetoActivo()
    {
        PopUps[indiceActual].SetActive(false);

        indiceActual = (indiceActual + 1) % PopUps.Length;

        PopUps[indiceActual].SetActive(true);
    }

    private void DesactivarTodosLosObjetos()
    {
        // Desactiva todos los objetos en el array
        foreach (var objeto in PopUps)
        {
            objeto.SetActive(false);
        }
    }
}
