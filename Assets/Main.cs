using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    NONE = 0,
    MAIN_MENU = 1,
    GAME = 2,
    END_SCREEN = 3
}

public enum WinType
{
    NONE = 0,
    MAIN_MENU = 1,
    POP_UP_BUBBLE = 2,
}

public class Main : MonoBehaviour
{
    public GameState CurrentGameState;

    public GameObject MainMenu;
    public GameObject PopupBubble;

    public static Main Instance;
    public TextMeshProUGUI TotalProfitLabel;
    public float TotalProfit;
    public Generator[] GeneratorArray;

    public void Start()
    {
        Instance = this;
        SetGameState(GameState.MAIN_MENU);
        WinManager.Instance.ShowWin(WinType.MAIN_MENU);
    }

    public void Update()
    {
        RunGameState();
    }

    public void GainMoney(float amount)
    {
        TotalProfit += amount;
        TotalProfitLabel.text = "$" + TotalProfit;
    }

    public void SpendMoney(float amount)
    {
        TotalProfit -= amount;
        TotalProfitLabel.text = "$" + TotalProfit;
    }

    public void SetGameState(GameState gameState)
    {
        CurrentGameState = gameState;
        switch (CurrentGameState)
        {
            case GameState.NONE:

                break;
            case GameState.MAIN_MENU:
                MainMenu.SetActive(true);
                break;
            case GameState.GAME:

                break;
            case GameState.END_SCREEN:

                break;
        }
    }

    public void RunGameState()
    {
        switch (CurrentGameState)
        {
            case GameState.NONE:

                break;
            case GameState.MAIN_MENU:
                Debug.Log("MAIN_MENU");
                break;
            case GameState.GAME:
                Debug.Log("GAME");
                break;
            case GameState.END_SCREEN:

                break;
        }
    }
}
