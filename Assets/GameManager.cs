using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI TotalProfitLabel;
    public float TotalProfit;
    public Generator[] GeneratorArray;

    public void Start()
    {
        Instance = this;
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
}
