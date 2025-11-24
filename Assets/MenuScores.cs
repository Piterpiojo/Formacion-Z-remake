using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MenuScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoRanking;

    private void Start()
    {
        MostrarRanking();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.M))
        {
            BorrarRanking();
        }
    }

    private void MostrarRanking()
    {
        int total = PlayerPrefs.GetInt("TotalJugadores", 0);

        List<(string nombre, float puntos)> jugadores = new List<(string, float)>();

        for (int i = 0; i < total; i++)
        {
            string nombre = PlayerPrefs.GetString("Jugador_" + i, "SinNombre");
            float puntos = PlayerPrefs.GetFloat("Puntaje_" + i, 0);

            jugadores.Add((nombre, puntos));
        }

        jugadores.Sort((a, b) => b.puntos.CompareTo(a.puntos));

        string ranking = "*Mejores Puntajes*\n";

        for (int i = 0; i < jugadores.Count; i++)
        {
            ranking += $"{i + 1}. {jugadores[i].nombre} - {jugadores[i].puntos:0}\n";
        }

        textoRanking.text = ranking;
    }

    private void BorrarRanking()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        textoRanking.text = "*Mejores Puntajes*\n(No hay jugadores guardados)";
        Debug.Log("Ranking borrado con Alt+Ctrl+M");
    }
}
