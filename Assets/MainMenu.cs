using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    static int credit;
    void Start()
    {
        credit = PlayerPrefs.GetInt("credit");
        Elements.credit = credit;
       // GameObject.FindWithTag("GameController").GetComponent<Text>().text = "CREDIT: " + credit.ToString();
    }
    public void GetCredit()
    {
        credit = PlayerPrefs.GetInt("credit");
        if (credit <= 0)
        {
            GameObject.FindWithTag("credit").GetComponent<Text>().text = (credit / 100).ToString() + "." + (credit % 100).ToString();
            credit += 1000;
            PlayerPrefs.SetInt("credit", 1000);
        }
        Elements.credit = credit;
      //  GameObject.FindWithTag("GameController").GetComponent<Text>().text="CREDIT: "+credit.ToString();
    }
    public void StartJoc()
    {
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
