using UnityEngine;
using UnityEngine.UI;

public class NotificationWindow : MonoBehaviour
{
    public Image MyImage;
    public Sprite[] SpriteArray;
    public Button XButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XButton.onClick.AddListener(HideWindow);
        //ShowAd(ImageAdType.AD_2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        ShowAd((ImageAdType)Random.Range((int)ImageAdType.AD_1, (int)ImageAdType.MAX_VALUE));
    }

    public void ShowAd(ImageAdType adType)
    {
        MyImage.sprite = SpriteArray[(int)adType];
        SoundManager.Instance.PlayAudio((SoundType)adType);
    }

    public void HideWindow()
    {
        this.gameObject.SetActive(false);
    }
}
