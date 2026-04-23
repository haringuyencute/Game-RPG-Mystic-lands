using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int pchar = 0;
    public static string pname = "player";
    public static GameObject spawnPoint;
    public static GameObject theTarget;
    public static float manaAmt = 1f;
    public static bool invisible = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if(manaAmt < 1.0)
        {
            manaAmt += 0.04f * Time.deltaTime;
        }
        if(manaAmt <= 0)
        {
            manaAmt = 0;
        }
        if(manaAmt < 0.03)
        {
            invisible = false;
        }
    }
}
