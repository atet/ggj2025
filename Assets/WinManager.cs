using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static WinManager Instance;
    public GameObject MainMenu;
    public GameObject NotificationWindow;

    public void Start()
    {
        Instance = this;
    }

    public void ShowWin(WinType winType)
    {
        switch (winType)
        {
            case WinType.NONE:
                break;
            case WinType.MAIN_MENU:
                MainMenu.gameObject.SetActive(true);
                break;
            case WinType.POP_UP_BUBBLE:
                NotificationWindow.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void HideWin(WinType winType)
    {
        switch (winType)
        {
            case WinType.NONE:
                break;
            case WinType.MAIN_MENU:
                MainMenu.gameObject.SetActive(false);
                break;
            case WinType.POP_UP_BUBBLE:
                NotificationWindow.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
