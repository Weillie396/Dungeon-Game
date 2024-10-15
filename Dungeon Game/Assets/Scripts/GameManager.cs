using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {

        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }


    // Resources for the game

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References for the game
    public Player player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;
    public RectTransform hitpointBar;

    // Logic for the game
    public int moneyTotal;
    public int xpTotal;

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
 
    // Upgrade Weapon

    public bool TryUpgradeWeapon()
    {
        // Is the Weapon Max Level
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;

        if(moneyTotal >= weaponPrices[weapon.weaponLevel])
        {
            moneyTotal -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }

    public void OnHitPointChange()
    {
        float ratio = (float)player.hitPoints / (float)player.maxHitpoint;
        hitpointBar.localScale = new Vector3(ratio, 1, 1);
    }
    //Save state functions
    /* 
  * INT preferedSkin
  * INT Money
  * INT xp
  * INT weaponLevel
  */

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += moneyTotal.ToString() + "|";
        s += xpTotal.ToString() + "|";
        s += weapon.weaponLevel.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // Change player Skin
        moneyTotal = int.Parse(data[1]);
        xpTotal = int.Parse(data[2]);
        weapon.SetWeaponLevel(int.Parse(data[3]));
    }
}
