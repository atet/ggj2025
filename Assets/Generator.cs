using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ScamType
{
    NONE = 0,
    BAIL = 1,
    PRINCE = 2,
    ROMANCE = 3,
    CRYPTO_INVESTMENT = 4,
    BANK = 5,
    PHISHING = 6,
}

public class Generator : MonoBehaviour
{
    public string TitleText;
    public GeneratorState CurrentGeneratorState;
    public float MinProfitToUnlock;

    public TextMeshProUGUI TitleTextLabel;
    public TextMeshProUGUI CurrentLevelLabel;
    public TextMeshProUGUI UpgradeLevelCostLabel;
    public TextMeshProUGUI EarningsLabel;

    public RectTransform ProgressBar;
    public float ProgressBarFullWidth;


    public int CurrentLevel;
    public float EarningsPerLevel;

    public float TotalEarnings;

    public ScamType MyScamType;
    public float CompletionSpeed;
    public float CurrentTime;
    public float CurrentTotalCompletionTime;
    public float UpgradeLevelBaseCost;
    public float UpgradeLevelCost;

    public bool shouldRunCounter;

    public Button TakeAction;
    public Button UpgradeLevelButton;

    public void Start()
    {
        TitleTextLabel.text = TitleText;
        CurrentLevel = 1;

        UpgradeLevelBaseCost = 100;
        UpgradeLevelCost = UpgradeLevelBaseCost * CurrentLevel;

        UpgradeLevelCostLabel.text = UpgradeLevelCost.ToString();
        ProgressBarFullWidth = ProgressBar.rect.width;
        ProgressBar.sizeDelta = new Vector2(0, ProgressBar.rect.height);
        Debug.Log(ProgressBar.rect.width);
        TakeAction.onClick.AddListener(ManualEarnButton);
        UpgradeLevelButton.onClick.AddListener(UpgradeLevel);
        EarningsLabel.text = "$" + CurrentLevel * EarningsPerLevel;
    }

    public void Update()
    {
        if (shouldRunCounter == true)
        {
            CurrentTime += CompletionSpeed * Time.deltaTime;
            ProgressBar.sizeDelta = new Vector2(CurrentTime/CurrentTotalCompletionTime * ProgressBarFullWidth, ProgressBar.rect.height);

            if (CurrentTime >= CurrentTotalCompletionTime)
            {
                CurrentTime = 0;
                shouldRunCounter = false;

                ReceiveMoney();

                ProgressBar.sizeDelta = new Vector2(0, ProgressBar.rect.height);
            }
        }

        CheckForUnlock();
    }

    public void CheckForUnlock()
    {
        if (Main.Instance.TotalProfit >= MinProfitToUnlock)
        {
            gameObject.SetActive(true);
        }
    }

    public void ManualEarnButton()
    {
        shouldRunCounter = true;
        SoundManager.Instance.AudioSourceArray[(int)SoundType.UNLOCK_POWER_UP].Play();
    }

    public void UpgradeLevel()
    {
        if (Main.Instance.TotalProfit >= UpgradeLevelCost)
        {
            //play sound
            SoundManager.Instance.AudioSourceArray[(int)SoundType.UNLOCK_POWER_UP].Play();

            CurrentLevel += 1;
            CurrentLevelLabel.text = "LVL: " + CurrentLevel;
            TotalEarnings -= UpgradeLevelCost;
            Main.Instance.SpendMoney(UpgradeLevelCost);

            EarningsLabel.text = "$" + CurrentLevel * EarningsPerLevel;

            UpgradeLevelCost = UpgradeLevelBaseCost * CurrentLevel;
            UpgradeLevelCostLabel.text = UpgradeLevelCost.ToString();
        }
        else
        {
            Debug.Log("not enough money");
        }
    }

    public void ReceiveMoney()
    {
        Debug.Log("receive money");
        TotalEarnings += CurrentLevel * EarningsPerLevel;
        Main.Instance.GainMoney(CurrentLevel * EarningsPerLevel);
    }

    public void SetGeneratorState(GeneratorState generatorState)
    {
        CurrentGeneratorState = generatorState;
        switch (CurrentGeneratorState)
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

    public void RunGeneratorState()
    {
        switch (CurrentGeneratorState)
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
}
