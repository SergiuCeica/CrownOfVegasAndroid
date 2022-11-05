using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamble : MonoBehaviour
{
    static public int credit;
    static int win;
    static int bet;
    GameObject[] carti,lastcards,items;
    GameObject carte,loc1,loc2,loc3,loc4,loc5;
    GameObject gobj;
    // Start is called before the first frame update
    void Start()
    {
        loc1 = GameObject.Find("loc1");
        loc2 = GameObject.Find("loc2");
        loc3 = GameObject.Find("loc3");
        loc4 = GameObject.Find("loc4");
        loc5 = GameObject.Find("loc5");
        lastcards = new GameObject[6];
        items = new GameObject[5];
        items[1] = GameObject.Find("clubsvg");
        items[2] = GameObject.Find("diamondsvg");
        items[3] = GameObject.Find("heartsvg");
        items[4] = GameObject.Find("spadesvg");
        carti = new GameObject[5];
        carti[1] = GameObject.FindWithTag("diamond");
        carti[2] = GameObject.FindWithTag("spade");
        carti[3] = GameObject.FindWithTag("heart");
        carti[4] = GameObject.FindWithTag("club");
        carte = GameObject.FindWithTag("card");
        credit = Elements.credit;
        win = Elements.win;
        bet = Elements.bet;
        gobj = new GameObject();
        Verif();
        GameObject.FindWithTag("wintxt").GetComponent<Text>().text = "WIN: " + (win / 100).ToString() + "." + (win % 100).ToString();
        GameObject.FindWithTag("towin").GetComponent<Text>().text = "TO WIN: " + (2 * win / 100).ToString() + "." + (2 * win % 100).ToString();
        try
        {
            GameObject go1 = GameObject.Instantiate(items[PlayerPrefs.GetInt("ucarte1")], new Vector3(loc1.transform.position.x, loc1.transform.position.y, loc1.transform.position.z + 2.0f), Quaternion.identity);
            go1.transform.SetParent(loc1.transform);
        }
        catch { }
        try
        {
            GameObject go2 = GameObject.Instantiate(items[PlayerPrefs.GetInt("ucarte2")], new Vector3(loc2.transform.position.x, loc2.transform.position.y, loc2.transform.position.z + 2.0f), Quaternion.identity);
            go2.transform.SetParent(loc2.transform);
        }
        catch { }
        try
        {
            GameObject go3 = GameObject.Instantiate(items[PlayerPrefs.GetInt("ucarte3")], new Vector3(loc3.transform.position.x, loc3.transform.position.y, loc3.transform.position.z + 2.0f), Quaternion.identity);
            go3.transform.SetParent(loc3.transform);
        }
        catch { }
        try
        {
            GameObject go4 = GameObject.Instantiate(items[PlayerPrefs.GetInt("ucarte4")], new Vector3(loc4.transform.position.x, loc4.transform.position.y, loc4.transform.position.z + 2.0f), Quaternion.identity);
            go4.transform.SetParent(loc4.transform);
        }
        catch { }
        try { 
            GameObject go5 = GameObject.Instantiate(items[PlayerPrefs.GetInt("ucarte5")], new Vector3(loc5.transform.position.x, loc5.transform.position.y, loc5.transform.position.z + 2.0f), Quaternion.identity);
            go5.transform.SetParent(loc5.transform);
        }
        catch
        {

        }
    }
    public void GambleRed()
    {
        GameObject.Find("Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Button1").GetComponent<Button>().enabled = false;
        GameObject.Find("Button2").GetComponent<Button>().enabled = false;
        int x = Random.Range(1, 5);
        carte.SetActive(false);
        GameObject card = GameObject.Instantiate(carti[x], carte.transform.position, Quaternion.identity);
        card.transform.SetParent(gobj.transform);
        LastCard();
        if(x==1 || x == 3)
        {
            GameObject.Find("dark").GetComponent<AudioSource>().Play();
            win = 2 * win;
            GameObject.FindWithTag("wintxt").GetComponent<Text>().text = "WIN: " + (win / 100).ToString() + "." + (win % 100).ToString();
            GameObject.FindWithTag("towin").GetComponent<Text>().text = "TO WIN: " + (2 * win / 100).ToString() + "." + (2 * win % 100).ToString();
            Invoke("Shuffle", 0.8f);
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
            win = 0;
            Elements.win = 0;
            Invoke("Lost",1f);
        }
        
    }
    void Shuffle()
    {

        GameObject.Destroy(gobj.transform.GetChild(gobj.transform.childCount - 1).gameObject);
        carte.SetActive(true);
        GameObject.Find("Button").GetComponent<Button>().enabled = true;
        GameObject.Find("Button1").GetComponent<Button>().enabled = true;
        GameObject.Find("Button2").GetComponent<Button>().enabled = true;
    }
    public void GambleBlack()
    {
        GameObject.Find("Button").GetComponent<Button>().enabled = false;
        GameObject.Find("Button1").GetComponent<Button>().enabled = false;
        GameObject.Find("Button2").GetComponent<Button>().enabled = false;
        int x = Random.Range(1, 5);
        carte.SetActive(false);
        GameObject card = GameObject.Instantiate(carti[x], carte.transform.position, Quaternion.identity);
        card.transform.SetParent(gobj.transform);
        LastCard();
        if (x == 2 || x == 4)
        {
            GameObject.Find("dark").GetComponent<AudioSource>().Play();
            win = 2 * win;
            GameObject.FindWithTag("wintxt").GetComponent<Text>().text = "WIN: " + (win/100).ToString()+"."+(win%100).ToString();
            GameObject.FindWithTag("towin").GetComponent<Text>().text = "TO WIN: " + (2 * win/100).ToString()+"."+(2*win%100).ToString();
            Invoke("Shuffle", 0.8f);

        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
            win = 0;
            Elements.win = 0;
            Invoke("Lost",1f);
        }
        
    }
    void LastCard()
    {

        try
        {
            Destroy(loc5.transform.GetChild(loc5.transform.childCount - 1).gameObject);
        }
        catch { Debug.Log("N a mers 5"); }
        try { 
            loc4.transform.GetChild(loc4.transform.childCount - 1).transform.position = new Vector3(loc5.transform.position.x,loc5.transform.position.y,loc5.transform.position.z+2.0f);
            loc4.transform.GetChild(loc4.transform.childCount - 1).SetParent(loc5.transform);
            if (loc5.transform.GetChild(loc5.transform.childCount - 1).tag == "clubsvg") PlayerPrefs.SetInt("ucarte5", 1);
            else if(loc5.transform.GetChild(loc5.transform.childCount - 1).tag == "diamondsvg") PlayerPrefs.SetInt("ucarte5", 2);
            else if (loc5.transform.GetChild(loc5.transform.childCount - 1).tag == "heartsvg") PlayerPrefs.SetInt("ucarte5", 3);
            else if (loc5.transform.GetChild(loc5.transform.childCount - 1).tag == "spadesvg") PlayerPrefs.SetInt("ucarte5", 4);
        }
        catch { Debug.Log("N a mers 4"); }
        try
        {
            loc3.transform.GetChild(loc3.transform.childCount - 1).transform.position = new Vector3(loc4.transform.position.x, loc4.transform.position.y, loc4.transform.position.z + 2.0f);
            loc3.transform.GetChild(loc3.transform.childCount - 1).SetParent(loc4.transform);
            if (loc4.transform.GetChild(loc4.transform.childCount - 1).tag == "clubsvg") PlayerPrefs.SetInt("ucarte4", 1);
            else if (loc4.transform.GetChild(loc4.transform.childCount - 1).tag == "diamondsvg") PlayerPrefs.SetInt("ucarte4", 2);
            else if (loc4.transform.GetChild(loc4.transform.childCount - 1).tag == "heartsvg") PlayerPrefs.SetInt("ucarte4", 3);
            else if (loc4.transform.GetChild(loc4.transform.childCount - 1).tag == "spadesvg") PlayerPrefs.SetInt("ucarte4", 4);
        }
        catch { Debug.Log("N a mers 3"); }
        try
        {
            loc2.transform.GetChild(loc2.transform.childCount - 1).transform.position = new Vector3(loc3.transform.position.x, loc3.transform.position.y, loc3.transform.position.z + 2.0f);
            loc2.transform.GetChild(loc2.transform.childCount - 1).SetParent(loc3.transform);
            if (loc3.transform.GetChild(loc3.transform.childCount - 1).tag == "clubsvg") PlayerPrefs.SetInt("ucarte3", 1);
            else if (loc3.transform.GetChild(loc3.transform.childCount - 1).tag == "diamondsvg") PlayerPrefs.SetInt("ucarte3", 2);
            else if (loc3.transform.GetChild(loc3.transform.childCount - 1).tag == "heartsvg") PlayerPrefs.SetInt("ucarte3", 3);
            else if (loc3.transform.GetChild(loc3.transform.childCount - 1).tag == "spadesvg") PlayerPrefs.SetInt("ucarte3", 4);
        }
        catch { Debug.Log("N a mers 2"); }
        try
        {
            loc1.transform.GetChild(loc1.transform.childCount - 1).transform.position = new Vector3(loc2.transform.position.x, loc2.transform.position.y, loc2.transform.position.z + 2.0f);
            loc1.transform.GetChild(loc1.transform.childCount - 1).SetParent(loc2.transform);
            if (loc2.transform.GetChild(loc2.transform.childCount - 1).tag == "clubsvg") PlayerPrefs.SetInt("ucarte2", 1);
            else if (loc2.transform.GetChild(loc2.transform.childCount - 1).tag == "diamondsvg") PlayerPrefs.SetInt("ucarte2", 2);
            else if (loc2.transform.GetChild(loc2.transform.childCount - 1).tag == "heartsvg") PlayerPrefs.SetInt("ucarte2", 3);
            else if (loc2.transform.GetChild(loc2.transform.childCount - 1).tag == "spadesvg") PlayerPrefs.SetInt("ucarte2", 4);
        }
        catch { Debug.Log("N a mers 1"); }
        if (gobj.transform.GetChild(gobj.transform.childCount - 1).tag=="club")
        {
            GameObject go1 = GameObject.Instantiate(items[1], new Vector3(loc1.transform.position.x,loc1.transform.position.y,loc1.transform.position.z+2.0f), Quaternion.identity);
            go1.transform.SetParent(loc1.transform);
            PlayerPrefs.SetInt("ucarte1", 1);
        }else if (gobj.transform.GetChild(gobj.transform.childCount - 1).tag=="heart") {
            GameObject go1 = GameObject.Instantiate(items[3], new Vector3(loc1.transform.position.x, loc1.transform.position.y, loc1.transform.position.z + 2.0f), Quaternion.identity);
            go1.transform.SetParent(loc1.transform);
            PlayerPrefs.SetInt("ucarte1", 3);
        }
        else if (gobj.transform.GetChild(gobj.transform.childCount - 1).tag=="diamond")
        {
            GameObject go1 = GameObject.Instantiate(items[2], new Vector3(loc1.transform.position.x, loc1.transform.position.y, loc1.transform.position.z + 2.0f), Quaternion.identity);
            go1.transform.SetParent(loc1.transform);
            PlayerPrefs.SetInt("ucarte1", 2);
        }
        else if (gobj.transform.GetChild(gobj.transform.childCount - 1).tag=="spade")
        {
            GameObject go1 = GameObject.Instantiate(items[4], new Vector3(loc1.transform.position.x, loc1.transform.position.y, loc1.transform.position.z + 2.0f), Quaternion.identity);
            go1.transform.SetParent(loc1.transform);
            PlayerPrefs.SetInt("ucarte1", 4);
        }
        
    }
    public void Verif()
    {
        if (loc1.transform.childCount >= 1)
        {
            Destroy(loc1.transform.GetChild(loc1.transform.childCount - 1).gameObject);
        }
        if (loc2.transform.childCount >= 1)
        {
            Destroy(loc2.transform.GetChild(loc1.transform.childCount - 1).gameObject);
        }
        if (loc3.transform.childCount >= 1)
        {
            Destroy(loc3.transform.GetChild(loc1.transform.childCount - 1).gameObject);
        }
        if (loc4.transform.childCount >= 1)
        {
            Destroy(loc4.transform.GetChild(loc1.transform.childCount - 1).gameObject);
        }
        if (loc5.transform.childCount >= 1)
        {
            Destroy(loc5.transform.GetChild(loc1.transform.childCount - 1).gameObject);
        }

    }
    public void TakeWin()
    {
        Elements.credit += win;
        Elements.bet = bet;
        
        SceneManager.LoadScene("SampleScene");

    }
    void Lost()
    {
        Elements.credit = credit;
        
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
