using UnityEngine;
using UnityEngine.UI;

public class ClickCounter : MonoBehaviour
{
    public Image flameImage;
    public Text counterText;
    public Button upgradeButton;
    private long clickCount = 0;
    private int upgradeLevel = 0;
    private int clicksPerIncrement = 1;
    private int upgradeThreshold = 100;

    void Start()
    {
        UpdateCounterText();
        flameImage.GetComponent<Button>().onClick.AddListener(OnImageClick);
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        upgradeButton.gameObject.SetActive(false);
        InvokeRepeating("IncrementClickCount", 1f, 1f);
    }

    void OnImageClick()
    {
        clickCount += clicksPerIncrement;
        CheckForUpgrade();
        UpdateCounterText();
    }

    void IncrementClickCount()
    {
        clickCount += clicksPerIncrement;
        CheckForUpgrade();
        UpdateCounterText();
    }

    void CheckForUpgrade()
    {
        if (clickCount >= upgradeThreshold)
            upgradeButton.gameObject.SetActive(true);
    }

    void OnUpgradeButtonClick()
    {
        upgradeLevel++;
        clicksPerIncrement += 1000;
        clickCount -= upgradeThreshold;
        upgradeThreshold += 100;
        upgradeButton.gameObject.SetActive(false);
        Debug.Log("Upgraded to level " + upgradeLevel + "! Clicks per increment: " + clicksPerIncrement);
        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        counterText.text = clickCount.ToString() + " m";
    }
}
