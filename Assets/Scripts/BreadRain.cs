using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BreadRain : MonoBehaviour
{
    [Header("Referencias")]
    public RectTransform contenedor;

    public GameObject panPrefab;

    [Header("Cantidad")]
    public int cantidadPanes = 25;

    [Header("Velocidad")]
    public float duracionMin = 5f;
    public float duracionMax = 12f;

    [Header("Escala")]
    public float escalaMin = 0.4f;
    public float escalaMax = 1.3f;

    [Header("Rotación")]
    public float rotacionMin = -360f;
    public float rotacionMax = 360f;

    void Start()
    {
        for (int i = 0; i < cantidadPanes; i++)
        {
            CrearPan();
        }
    }

    void CrearPan()
    {
        GameObject pan =
            Instantiate(panPrefab, contenedor);

        RectTransform rect =
            pan.GetComponent<RectTransform>();

        Image img =
            pan.GetComponent<Image>();

        float ancho =
            Screen.width;

        float alto =
            Screen.height;

        float x =
            Random.Range(-ancho / 2f, ancho / 2f);

        float startY =
            Random.Range(alto / 2f, alto);

        rect.anchoredPosition =
            new Vector2(x, startY);

        float escala =
            Random.Range(escalaMin, escalaMax);

        rect.localScale =
            Vector3.one * escala;

        Color c = img.color;

        c.a = Random.Range(0.15f, 0.5f);

        img.color = c;

        float duracion =
            Random.Range(duracionMin, duracionMax);

        rect
            .DOAnchorPosY(-alto, duracion)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Destroy(pan);

                CrearPan();
            });

        rect
            .DORotate(
                new Vector3(
                    0,
                    0,
                    Random.Range(rotacionMin, rotacionMax)
                ),
                duracion,
                RotateMode.FastBeyond360
            )
            .SetEase(Ease.Linear);

        rect
            .DOAnchorPosX(
                rect.anchoredPosition.x +
                Random.Range(-100f, 100f),
                Random.Range(2f, 4f)
            )
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}