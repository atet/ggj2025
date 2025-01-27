using UnityEngine;

public enum SoundType
{
    NONE = 0,
    ARCADE_BONUS_ALERT = 1,
    BONUS_POWER_UP = 2,
    JACKPOT_WITH_COINS = 3,
    JACKPOT_WITH_COINS_LONG = 4,
    UNLOCK_POWER_UP = 5,

    AD_1 = 6,
    AD_2 = 7,
    AD_3 = 8
}

public enum ImageAdType
{
    MIN_VALUE = 5,
    AD_1 = 6,
    AD_2 = 7,
    AD_3 = 8,
    MAX_VALUE = 9
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource[] AudioSourceArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(SoundType soundType)
    {
        AudioSourceArray[(int)soundType].Play();
    }
}
