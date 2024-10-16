
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // Text Fields
    public TextMeshProUGUI levelText, hitPointText, moneyText, upgradeCostText, xptext;

    // Logic Fields
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // Character selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;

            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;

            if (currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }

    // Weapon upgrade

    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();

    }


    // Update Character Info
    public void UpdateMenu()
    {
        // Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        upgradeCostText.text = "Not Implemented";

        // Meta
        hitPointText.text = GameManager.instance.player.hitPoints.ToString();
        moneyText.text = GameManager.instance.moneyTotal.ToString();
        levelText.text = GameManager.instance.xpTotal.ToString();

        // xp Bar
        xptext.text = "Not Implemented";
        xpBar.localScale = new Vector3(0.5f,1,1);
    }
}
