using UnityEngine;
using UnityEngine.UI;

public enum GeneratorState
{
    NONE = 0,
    HIDDEN = 1,
    READY_TO_UNLOCK = 2,
    UNLOCKED = 3
}

public class GeneratorManager : MonoBehaviour
{
    public Generator[] GeneratorArray;
    public GeneratorState[] GeneratorStateArray;
    public GameObject EmailNotificationText;

    public Button EmailNotificationButton;

    void Start()
    {
        EmailNotificationButton.onClick.AddListener(ClickEmailNotificationButton);

        for(int i = 0; i < GeneratorStateArray.Length; i++)
        {
            GeneratorStateArray[i] = GeneratorState.HIDDEN;
        }

        GeneratorStateArray[0] = GeneratorState.UNLOCKED;
        GeneratorArray[0].gameObject.SetActive(true);
    }

    void Update()
    {
        EmailNotificationText.SetActive(false);
        RunGenerateState();
    }

    public void SetGeneratorState(int index, GeneratorState generatorState)
    {
        GeneratorStateArray[index] = generatorState;
        switch (GeneratorStateArray[index])
        {
            case GeneratorState.NONE:
                break;
            case GeneratorState.HIDDEN:
                break;
            case GeneratorState.READY_TO_UNLOCK:
                break;
            case GeneratorState.UNLOCKED:
                break;
        }
    }

    public void RunGenerateState()
    {
        for (int i = 0; i < GeneratorStateArray.Length; i++)
        {
            switch (GeneratorStateArray[i])
            {
                case GeneratorState.NONE:
                    break;
                case GeneratorState.HIDDEN:
                    if (Main.Instance.TotalProfit >= GeneratorArray[i].MinProfitToUnlock)
                    {
                        GeneratorStateArray[i] = GeneratorState.READY_TO_UNLOCK;
                    }
                    break;
                case GeneratorState.READY_TO_UNLOCK:
                    EmailNotificationText.SetActive(true);
                    //GeneratorArray[i].gameObject.SetActive(true);
                    break;
                case GeneratorState.UNLOCKED:
                    break;
            }
        }
    }

    public void ClickEmailNotificationButton()
    {
        for(int i = 0;i < GeneratorStateArray.Length;i++)
        {
            if (GeneratorStateArray[i] == GeneratorState.READY_TO_UNLOCK)
            {
                SetGeneratorState(i, GeneratorState.UNLOCKED);
                GeneratorArray[i].gameObject.SetActive(true);
                WinManager.Instance.ShowWin(WinType.POP_UP_BUBBLE);
            }
        }
    }
}
