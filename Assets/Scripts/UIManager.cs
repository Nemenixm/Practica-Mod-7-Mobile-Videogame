using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panel")]
    public GameObject panelMejoras;

    void Start()
    {
        panelMejoras.SetActive(false);
    }

    public void AbrirMejoras()
    {
        panelMejoras.SetActive(true);
    }

    public void CerrarMejoras()
    {
        panelMejoras.SetActive(false);
    }
}