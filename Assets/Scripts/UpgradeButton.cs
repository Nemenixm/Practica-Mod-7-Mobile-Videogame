// ==========================
// UpgradeButton.cs
// ==========================

using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

public class UpgradeButton : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public enum TipoMejora
    {
        Click,
        Automatico,
        Abuela
    }

    [Header("Referencias")]
    public GameManager gameManager;

    [Header("Texto Precio")]
    public TextMeshProUGUI textoPrecio;

    [Header("Tooltip")]
    public GameObject tooltipPanel;

    public TextMeshProUGUI tooltipTexto;

    [Header("Datos")]
    public string nombreMejora;

    public TipoMejora tipoMejora;

    public int aumento = 1;

    public int precioInicial = 10;

    public float multiplicadorPrecio = 1.5f;

    private int precioActual;

    void Start()
    {
        precioActual = precioInicial;

        ActualizarUI();

        if (tooltipPanel != null)
        {
            tooltipPanel.SetActive(false);
        }
    }

    public void Comprar()
    {
        if (gameManager.GastarPanes(precioActual))
        {
            switch (tipoMejora)
            {
                case TipoMejora.Click:

                    gameManager.panesPorClick += aumento;

                    break;

                case TipoMejora.Automatico:

                    gameManager.panesPorSegundo += aumento;

                    break;

                case TipoMejora.Abuela:

                    StartCoroutine(ProduccionAbuela());

                    break;
            }

            precioActual =
                Mathf.RoundToInt(precioActual * multiplicadorPrecio);

            ActualizarUI();
        }
    }

    IEnumerator ProduccionAbuela()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            gameManager.panes += 5;

            gameManager.ActualizarTexto();
        }
    }

    void ActualizarUI()
    {
        textoPrecio.text = precioActual.ToString();

        switch (tipoMejora)
        {
            case TipoMejora.Click:

                tooltipTexto.text =
                    "Añade +" + aumento + " panes por click";

                break;

            case TipoMejora.Automatico:

                tooltipTexto.text =
                    "Genera +" + aumento + " panes por segundo";

                break;

            case TipoMejora.Abuela:

                tooltipTexto.text =
                    "Genera 5 panes cada 5 segundos";

                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tooltipPanel != null)
        {
            tooltipPanel.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tooltipPanel != null)
        {
            tooltipPanel.SetActive(false);
        }
    }
}