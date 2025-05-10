using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI kickMessage;
    public TextMeshProUGUI winMessage;

    void Awake()
    {
        Instance = this;
    }

    public void ResetUI()
    {
        ShowKickMessage(true);
        ShowWinMessage(false);
    }

    public void ShowKickMessage(bool show) => kickMessage.gameObject.SetActive(show);
    public void ShowWinMessage(bool show) => winMessage.gameObject.SetActive(show);
}
