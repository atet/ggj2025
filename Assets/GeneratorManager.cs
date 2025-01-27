using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public Generator[] GeneratorArray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < GeneratorArray.Length; i++)
        {
            if (Main.Instance.TotalProfit >= GeneratorArray[i].MinProfitToUnlock)
            {
                GeneratorArray[i].gameObject.SetActive(true);
            }
        }
    }
}
