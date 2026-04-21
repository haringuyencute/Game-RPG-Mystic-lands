using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoosePlayer : MonoBehaviour
{
    public GameObject[] characters;
    private int p = 0;
    public Text playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HandleNextButton()
    {
        if(p < characters.Length - 1)
        {
            characters[p].gameObject.SetActive(false);
            p++;
            characters[p].gameObject.SetActive(true);
        }
    }
    public void HandleBackButton()
    {
        if(p > 0)
        {
            characters[p].gameObject.SetActive(false);
            p--;
            characters[p].gameObject.SetActive(true);
        }
    }
    public void HandleAcceptButton()
    {
        SaveScript.pchar = p;
        SaveScript.pname = playerName.text;
        SceneManager.LoadScene(1);
    }
}
