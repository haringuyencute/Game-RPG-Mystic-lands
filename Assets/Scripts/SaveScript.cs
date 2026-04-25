using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int pchar = 0;
    public static string pname = "player";
    public static GameObject spawnPoint;
    public static GameObject theTarget;
    public static float manaAmt = 1.0f;
    public static float staminaAmt = 1.0f;
    public static bool invisible = false;
    public static bool invulnerable = false;
    public static float strengthAmt = 0.1f;
    public static float manaPowerAmt = 0.1f;
    public static float staminaPowerAmt = 0.1f;
    public static int killAmt = 0;
    public static int weaponChoice = 0;
    public static bool weaponChange = false;
    public static bool carryingWeapon = false;
    public static int armor = 0;
    public static bool changeArmor = false;
    private int checkAmt = 1;
    public static float playerLevel = 0.1f;
    public static int weaponIncrease;
    public static float playerHealth = 1.0f;
    public static int strengthIncrease = 0;
    public static float armorValue = 0;
    public static int enemiesOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        if (manaAmt < 1.0)
        {
            manaAmt += (manaPowerAmt / 10 + 0.04f) * Time.deltaTime;
        }
        if (manaAmt <= 0)
        {
            manaAmt = 0;
        }
        if (manaAmt < 0.03)
        {
            invisible = false;
            invulnerable = false;
            strengthIncrease = 0;
        }
        if (staminaAmt < 1.0)
        {
            staminaAmt += (staminaPowerAmt / 10 + 0.04f) * Time.deltaTime;
        }
        if (staminaAmt <= 0)
        {
            staminaAmt = 0;
        }
        if (killAmt == checkAmt)
        {
            playerLevel += 0.1f;
            checkAmt = killAmt + 10;
            strengthAmt = playerLevel;
            manaPowerAmt = playerLevel;
            staminaPowerAmt = playerLevel;
            weaponIncrease = System.Convert.ToInt32(strengthAmt * 90);
        }
        if (armor == 1)
        {
            armorValue = 0.002f;
        }
        if (armor == 2)
        {
            armorValue = 0.004f;
        }
    }
}
