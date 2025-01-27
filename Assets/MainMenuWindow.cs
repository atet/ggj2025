using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : MonoBehaviour
{
    public Button PlayButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayButton.onClick.AddListener(HideWin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWin()
    {
    
    }

    public void HideWin()
    {
        this.gameObject.SetActive(false);
        Main.Instance.SetGameState(GameState.GAME);
    }
}
