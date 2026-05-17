using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textoNumero;

    public int panes = 0;

    [Header("Producción")]
    public int panesPorClick = 1;
    public int panesPorSegundo = 1;

    public ParticleSystem panParticles;

    void Start()
    {
        InvokeRepeating(nameof(SumarPanAutomatico), 1f, 1f);

        ActualizarTexto();
    }

    void SumarPanAutomatico()
    {
        panes += panesPorSegundo;

        ActualizarTexto();
    }

    public void ClickPan()
    {
        panes += panesPorClick;

        ActualizarTexto();

        panParticles.Play();
    }

    public bool GastarPanes(int cantidad)
    {
        if (panes >= cantidad)
        {
            panes -= cantidad;

            ActualizarTexto();

            return true;
        }

        return false;
    }

    public void ActualizarTexto()
    {
        textoNumero.text = panes.ToString();
    }
}