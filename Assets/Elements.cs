using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;


public class Elements : MonoBehaviour
{
    GameObject[][] matrice1;
     GameObject obj1,obj2,obj3,obj4,obj5,obj6,obj7,obj8,obj9,obj10,obj11,obj12,obj13,obj14,obj15;
    GameObject go,fire,fireparent;
    int spincount;
    int ok;
    static public int win,bet;
    static public int credit;
    static public GameObject bett;
    int[] vectorbet;
    GameObject[] g1;
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        ok = 0;
       // matrice = new Element11[20][];
        matrice1 = new GameObject[21][];
         go=new GameObject();
        bett = GameObject.FindWithTag("GameController");
        fire = GameObject.Find("fire");
        fireparent = GameObject.Find("fireparent");
        vectorbet = new int[12];
        
        vectorbet[1] = 5;
        vectorbet[2] = 10;
        vectorbet[3] = 20;
        vectorbet[4] = 25;
        vectorbet[5] = 40;
        vectorbet[6] = 50;
        vectorbet[7] = 100;
        vectorbet[8] = 200;
        vectorbet[9] = 300;
        vectorbet[10] = 400;
        vectorbet[11] = 500;
        g1 = new GameObject[24]; 
        credit = PlayerPrefs.GetInt("credit");
        
        try
        {
            bet = PlayerPrefs.GetInt("bet");
        }
        catch { bet = 3; }
        GameObject.FindWithTag("credit").GetComponent<Text>().text = (credit/100).ToString()+"."+(credit%100).ToString();
        spincount = 7;
        SetBet();
        Initialize();
        AscundeWins(false);
        FirstSpin();
       
    }
    public void FirstSpin()
    {
        for (int i = 5; i <= 7; i++) {
            for (int j = 1; j <= 5; j++) {
                matrice1[i][j] = GameObject.Instantiate(go,new Vector3(matrice1[i+3][j].transform.position.x,matrice1[i+3][j].transform.position.y+8.35f,matrice1[i+3][j].transform.position.z),Quaternion.identity);
                matrice1[i][j].AddComponent<Element11>();
                matrice1[i][j].GetComponent<Element11>().Spin(new Vector3(matrice1[i + 3][j].transform.position.x, matrice1[i + 3][j].transform.position.y + 8.35f, matrice1[i + 3][j].transform.position.z));
            }
        }
        for (int i = 2; i <= 4; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                matrice1[i][j] = GameObject.Instantiate(go, new Vector3(matrice1[i + 3][j].transform.position.x, matrice1[i + 3][j].transform.position.y + 8.35f, matrice1[i + 3][j].transform.position.z), Quaternion.identity);
                matrice1[i][j].AddComponent<Element11>();
                matrice1[i][j].GetComponent<Element11>().Spin(new Vector3(matrice1[i + 3][j].transform.position.x, matrice1[i + 3][j].transform.position.y + 8.35f, matrice1[i + 3][j].transform.position.z));
            }
        }
        for(int j = 1; j <= 5; j++)
        {
            matrice1[1][j] = GameObject.Instantiate(go, new Vector3(matrice1[2][j].transform.position.x, matrice1[2][j].transform.position.y + 3.35f, matrice1[2][j].transform.position.z), Quaternion.identity);
            matrice1[1][j].AddComponent<Element11>();
            matrice1[1][j].GetComponent<Element11>().Spin(new Vector3(matrice1[2][j].transform.position.x, matrice1[2][j].transform.position.y + 3.35f, matrice1[2][j].transform.position.z));
        }
        matrice1[8][1].GetComponent<Element11>().Spin(obj1.transform.position);
        matrice1[8][2].GetComponent<Element11>().Spin(obj2.transform.position);
        matrice1[8][3].GetComponent<Element11>().Spin(obj3.transform.position);
        matrice1[8][4].GetComponent<Element11>().Spin(obj4.transform.position);
        matrice1[8][5].GetComponent<Element11>().Spin(obj5.transform.position);
        matrice1[9][1].GetComponent<Element11>().Spin(obj6.transform.position);
        matrice1[9][2].GetComponent<Element11>().Spin(obj7.transform.position);
        matrice1[9][3].GetComponent<Element11>().Spin(obj8.transform.position);
        matrice1[9][4].GetComponent<Element11>().Spin(obj9.transform.position);
        matrice1[9][5].GetComponent<Element11>().Spin(obj10.transform.position);
        matrice1[10][1].GetComponent<Element11>().Spin(obj11.transform.position);
        matrice1[10][2].GetComponent<Element11>().Spin(obj12.transform.position);
        matrice1[10][3].GetComponent<Element11>().Spin(obj13.transform.position);
        matrice1[10][4].GetComponent<Element11>().Spin(obj14.transform.position);
        matrice1[10][5].GetComponent<Element11>().Spin(obj15.transform.position);
        for(int i = 11; i <= 13; i++)
        {
            for(int j = 1; j <= 5; j++)
            {
                matrice1[i][j] = GameObject.Instantiate(go, new Vector3(matrice1[i - 3][j].transform.position.x, matrice1[i - 3][j].transform.position.y - 8.35f, matrice1[i - 3][j].transform.position.z), Quaternion.identity);
                matrice1[i][j].AddComponent<Element11>();
            }
        }
        for (int i = 14; i <= 16; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                matrice1[i][j] = GameObject.Instantiate(go, new Vector3(matrice1[i - 3][j].transform.position.x, matrice1[i - 3][j].transform.position.y - 8.35f, matrice1[i - 3][j].transform.position.z), Quaternion.identity);
                matrice1[i][j].AddComponent<Element11>();
            }
        }
        for (int j = 1; j <= 5; j++)
        {
            matrice1[17][j] = GameObject.Instantiate(go, new Vector3(matrice1[16][j].transform.position.x, matrice1[16][j].transform.position.y - 3.35f, matrice1[16][j].transform.position.z), Quaternion.identity);
            matrice1[17][j].AddComponent<Element11>();
        }
            ok = 1;
        Verificare();
    }
    public void NextSpins()
    {

        if (credit >= 0)
        {

       
            if (spincount > 0)
            {

                for (int i = 10; i >= 1; i--)
                {
                    for (int j = 1; j <= 5; j++)
                    {
                        for (int k = matrice1[i][j].transform.childCount - 1; k >= 0; k--)
                        {
                            Transform children = matrice1[i][j].transform.GetChild(k);
                            children.SetParent(matrice1[i + 1][j].transform);
                            if (children.transform.position.y > matrice1[i + 1][j].transform.position.y)
                            {
                                while (children.transform.position.y > matrice1[i + 1][j].transform.position.y)
                                {
                                    children.transform.Translate(0, -0.001f, 0);
                                }
                            }
                            if (children.transform.position.y < -5.20f) GameObject.Destroy(children.gameObject);
                        }
                    }

                }
                spincount--;
            }
        }
        
    }

    public void BigSpin() {
        ok = 2;
        credit -= bet;
    }
    public void ScadeCredit()
    {
        
        credit += win;
        RemoveFire();
            if (credit > 0 && bet <= 500)
            {
                credit -= vectorbet[bet];
                ok = 2;
                win = 0;
                PlayerPrefs.SetInt("credit", credit);
            GameObject.FindWithTag("spinbtn").GetComponent<AudioSource>().Play(0);
        }
            else
            {
                ok = 1;
                Debug.Log("Credint Insuficient");
            }
        
    }
    void TimerFinished()
    {
        GameObject.Find("CreditButton").GetComponent<Button>().enabled = true;
    }
    void Update()
    {
        
        if (ok == 2) {
            GameObject.FindWithTag("credit").GetComponent<Text>().text = (credit/100).ToString()+"."+(credit%100).ToString();

            NextSpins();
        }
        if (spincount == 0)
        {
            ok = 1;
            GameObject.FindWithTag("spinbtn").GetComponent<Button>().enabled = false;
            SetBet();
            GameObject.FindWithTag("credit").GetComponent<Text>().text = (credit / 100).ToString() + "." + (credit % 100).ToString();
            VerificareWinScatter();
            Invoke( "VerificareCoroana",0.5f);
            Invoke("VerificareWin",0.7f);
            Invoke("reactivarebtn", 0.8f);
            MatriceAscunsa();
            Verificare();
            PlayerPrefs.SetInt("credit", credit);
            if (ok == 3) { }
        }
    }
    void reactivarebtn()
    {
        GameObject.FindWithTag("spinbtn").GetComponent<Button>().enabled = true;
    }
    void Verificare()
    {
        for (int col = 1; col <= 5; col++)
        {
            for (int i = 1; i <= 3; i++)
            {
                for (int j = i + 1; j <= 3; j++)
                {
                    if (col == 1 || col==3 || col==5)
                    {
                        if (matrice1[i][col].transform.GetChild(matrice1[i][col].transform.childCount - 1).CompareTag("star") == true && matrice1[j][col].transform.GetChild(matrice1[j][col].transform.childCount - 1).CompareTag("star") == true)
                        {
                            GameObject.Destroy(matrice1[j][col].transform.GetChild(matrice1[j][col].transform.childCount - 1).gameObject);
                            matrice1[j][col].GetComponent<Element11>().ExceptionSpin(matrice1[j][col].transform.position);
                        }
                        if (matrice1[i][col].transform.GetChild(matrice1[i][col].transform.childCount - 1).CompareTag("dollar") == true && matrice1[j][col].transform.GetChild(matrice1[j][col].transform.childCount - 1).CompareTag("dollar") == true)
                        {
                            GameObject.Destroy(matrice1[j][col].transform.GetChild(matrice1[j][col].transform.childCount - 1).gameObject);
                            matrice1[j][col].GetComponent<Element11>().ExceptionSpin(matrice1[j][col].transform.position);
                        }
                        if (matrice1[i][col].transform.GetChild(matrice1[i][col].transform.childCount - 1).CompareTag("crown") == true && matrice1[j][col].transform.GetChild(matrice1[j][col].transform.childCount - 1).CompareTag("crown") == true)
                        {
                            GameObject.Destroy(matrice1[j][col].transform.GetChild(matrice1[j][col].transform.childCount - 1).gameObject);
                            matrice1[j][col].GetComponent<Element11>().ExceptionSpin(matrice1[j][col].transform.position);
                        }
                    }
                    else if (col == 2 || col==4)
                    {
                       
                        if (matrice1[i][col].transform.GetChild(matrice1[i][col].transform.childCount - 1).CompareTag("dollar") == true && matrice1[j][col].transform.GetChild(matrice1[j][col].transform.childCount - 1).CompareTag("dollar") == true)
                        {
                            GameObject.Destroy(matrice1[j][col].transform.GetChild(matrice1[j][col].transform.childCount - 1).gameObject);
                            matrice1[j][col].GetComponent<Element11>().ExceptionSpin(matrice1[j][col].transform.position);
                        }
                        if (matrice1[i][col].transform.GetChild(matrice1[i][col].transform.childCount - 1).CompareTag("crown") == true && matrice1[j][col].transform.GetChild(matrice1[j][col].transform.childCount - 1).CompareTag("crown") == true)
                        {
                            GameObject.Destroy(matrice1[j][col].transform.GetChild(matrice1[j][col].transform.childCount - 1).gameObject);
                            matrice1[j][col].GetComponent<Element11>().ExceptionSpin(matrice1[j][col].transform.position);
                        }
                    }
                }
                if (col == 2 || col == 4) { 
                    if (matrice1[i][col].transform.GetChild(matrice1[i][col].transform.childCount - 1).CompareTag("star") == true)
                    {
                        GameObject.Destroy(matrice1[i][col].transform.GetChild(matrice1[i][col].transform.childCount - 1).gameObject);
                        matrice1[i][col].GetComponent<Element11>().ExceptionSpin(matrice1[i][col].transform.position);
                    }
                }
                if (col == 1 || col == 5)
                {
                    if (matrice1[i][col].transform.GetChild(matrice1[i][col].transform.childCount - 1).CompareTag("crown") == true)
                    {
                        GameObject.Destroy(matrice1[i][col].transform.GetChild(matrice1[i][col].transform.childCount - 1).gameObject);
                        matrice1[i][col].GetComponent<Element11>().ExceptionSpin(matrice1[i][col].transform.position);
                    }
                }
            }
        }
        spincount = 7;
    }
    void VerificareWinScatter()
    {
        VerificareWinDollar();
        VerificareWinStar();
    }
    void VerificareWin()
    {
        VerificareWin("cherry");
        VerificareWin("lemon");
        VerificareWin("peach");
        VerificareWin("plum");
        VerificareWin("bell");
        VerificareWin("watermelon");
        VerificareWin("grapes");
        VerificareWinSeptari("seven");
        GameObject.FindWithTag("win").GetComponent<Text>().text = (win/100).ToString()+"."+(win%100).ToString();
        ok = 3;
    }
    void VerificareWinStar()
    {
        int c = 0;
        for(int i = 8; i <= 10; i++)
        {
            for(int j = 1; j <= 5; j++)
            {
                if (matrice1[i][j].transform.GetChild(matrice1[i][j].transform.childCount - 1).tag == "star") c++;
            }
        }
        if (c == 3) win += 20 * vectorbet[bet];
    }
    void VerificareWinDollar()
    {
        int c = 0;
        for (int i = 8; i <= 10; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                if (matrice1[i][j].transform.GetChild(matrice1[i][j].transform.childCount - 1).tag == "dollar") c++;
            }
        }
        if (c == 5) win += 100 * vectorbet[bet];
        else if (c == 4) win += 20 * vectorbet[bet];
        else if (c == 3) win += 5 * vectorbet[bet];
    }
    void VerificareWin(string item)
    {
        //VERIFICARE CIRESE,LAMAI,PIERSICI,PRUNE,CLOPOTEI,PEPENI,STRUGURI
        //-----LINIA 1-----
        if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item &&( matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == item || matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == "crown") && (matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == item || matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == item || matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == "crown")
            {
                if (matrice1[8][5].transform.GetChild(matrice1[8][5].transform.childCount - 1).tag == item) {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y,matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[8][4].transform.position.x, matrice1[8][4].transform.position.y, matrice1[8][4].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[8][5].transform.position.x, matrice1[8][5].transform.position.y, matrice1[8][5].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    el4.transform.SetParent(fireparent.transform);
                    GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play(0);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 15 * vectorbet[bet];
                    else if (item == "bell") win += 20 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 70 * vectorbet[bet];
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[8][4].transform.position.x, matrice1[8][4].transform.position.y, matrice1[8][4].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 3 * vectorbet[bet];
                    else if (item == "bell") win += 4 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 12 * vectorbet[bet];
                }
            }
            else {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                 el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                el2.transform.SetParent(fireparent.transform);
                if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += vectorbet[bet];
                else if (item == "bell") win += 2 * vectorbet[bet];
                else if (item == "grapes" || item == "watermelon") win += 4 * vectorbet[bet];

            }
        }
        //----LINIA 2-----
        if (matrice1[9][1].transform.GetChild(matrice1[9][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown") && (matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == item || matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == item || matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == "crown")
            {
                if (matrice1[9][5].transform.GetChild(matrice1[9][5].transform.childCount - 1).tag == item)
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[9][4].transform.position.x, matrice1[9][4].transform.position.y, matrice1[9][4].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[9][5].transform.position.x, matrice1[9][5].transform.position.y, matrice1[9][5].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    el4.transform.SetParent(fireparent.transform);
                    GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play(0);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 15 * vectorbet[bet];
                    else if (item == "bell") win += 20 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 70 * vectorbet[bet];
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[9][4].transform.position.x, matrice1[9][4].transform.position.y, matrice1[9][4].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 3 * vectorbet[bet];
                    else if (item == "bell") win += 4 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 12 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                 el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                el2.transform.SetParent(fireparent.transform);
                if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += vectorbet[bet];
                else if (item == "bell") win += 2 * vectorbet[bet];
                else if (item == "grapes" || item == "watermelon") win += 4 * vectorbet[bet];
            }
        }
        //-----LINIA 3-----
        if (matrice1[10][1].transform.GetChild(matrice1[10][1].transform.childCount - 1).tag == item && (matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == item || matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == "crown") && (matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == item || matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == item || matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == "crown")
            {
                if (matrice1[10][5].transform.GetChild(matrice1[10][5].transform.childCount - 1).tag == item)
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[10][4].transform.position.x, matrice1[10][4].transform.position.y, matrice1[10][4].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[10][5].transform.position.x, matrice1[10][5].transform.position.y, matrice1[10][5].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    el4.transform.SetParent(fireparent.transform);
                    GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play(0);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 15 * vectorbet[bet];
                    else if (item == "bell") win += 20 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 70 * vectorbet[bet];
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[10][4].transform.position.x, matrice1[10][4].transform.position.y, matrice1[10][4].transform.position.z + 0.2f), Quaternion.identity);
                     el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 3 * vectorbet[bet];
                    else if (item == "bell") win += 4 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 12 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                el2.transform.SetParent(fireparent.transform);
                if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += vectorbet[bet];
                else if (item == "bell") win += 2 * vectorbet[bet];
                else if (item == "grapes" || item == "watermelon") win += 4 * vectorbet[bet];
            }
        }
        //-----LINIA 4-----
        if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown") && (matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == item || matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == item || matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == "crown")
            {
                if (matrice1[8][5].transform.GetChild(matrice1[8][5].transform.childCount - 1).tag == item)
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[9][4].transform.position.x, matrice1[9][4].transform.position.y, matrice1[9][4].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[8][5].transform.position.x, matrice1[8][5].transform.position.y, matrice1[8][5].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    el4.transform.SetParent(fireparent.transform);
                    GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play(0);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 15 * vectorbet[bet];
                    else if (item == "bell") win += 20 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 70 * vectorbet[bet];
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[9][4].transform.position.x, matrice1[9][4].transform.position.y, matrice1[9][4].transform.position.z + 0.2f), Quaternion.identity);
                     el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 3 * vectorbet[bet];
                    else if (item == "bell") win += 4 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 12 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                 el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                el2.transform.SetParent(fireparent.transform);
                if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += vectorbet[bet];
                else if (item == "bell") win += 2 * vectorbet[bet];
                else if (item == "grapes" || item == "watermelon") win += 4 * vectorbet[bet];
            }
        }
        //-----LINIA 5-----
        if (matrice1[10][1].transform.GetChild(matrice1[10][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown") && (matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == item || matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == item || matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == "crown")
            {
                if (matrice1[10][5].transform.GetChild(matrice1[10][5].transform.childCount - 1).tag == item)
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[9][4].transform.position.x, matrice1[9][4].transform.position.y, matrice1[9][4].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[10][5].transform.position.x, matrice1[10][5].transform.position.y, matrice1[10][5].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    el4.transform.SetParent(fireparent.transform);
                    GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play(0);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 15 * vectorbet[bet];
                    else if (item == "bell") win += 20 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 70 * vectorbet[bet];
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[9][4].transform.position.x, matrice1[9][4].transform.position.y, matrice1[9][4].transform.position.z + 0.2f), Quaternion.identity);
                     el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 3 * vectorbet[bet];
                    else if (item == "bell") win += 4 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 12 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                el2.transform.SetParent(fireparent.transform);
                if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += vectorbet[bet];
                else if (item == "bell") win += 2 * vectorbet[bet];
                else if (item == "grapes" || item == "watermelon") win += 4 * vectorbet[bet];
            }
        }
        //-----LINIA 6-----
        if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == item || matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == "crown") && (matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == item || matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == item || matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == "crown")
            {
                if (matrice1[10][5].transform.GetChild(matrice1[10][5].transform.childCount - 1).tag == item)
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[10][4].transform.position.x, matrice1[10][4].transform.position.y, matrice1[10][4].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[10][5].transform.position.x, matrice1[10][5].transform.position.y, matrice1[10][5].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    el4.transform.SetParent(fireparent.transform);
                    GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play(0);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 15 * vectorbet[bet];
                    else if (item == "bell") win += 20 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 70 * vectorbet[bet];
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[10][4].transform.position.x, matrice1[10][4].transform.position.y, matrice1[10][4].transform.position.z + 0.2f), Quaternion.identity);
                     el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 3 * vectorbet[bet];
                    else if (item == "bell") win += 4 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 12 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                 el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                el2.transform.SetParent(fireparent.transform);
                if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += vectorbet[bet];
                else if (item == "bell") win += 2 * vectorbet[bet];
                else if (item == "grapes" || item == "watermelon") win += 4 * vectorbet[bet];
            }
        }
        //-----LINIA 7-----
        if (matrice1[10][1].transform.GetChild(matrice1[10][1].transform.childCount - 1).tag == item && (matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == item || matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == "crown") && (matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == item || matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == item || matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == "crown")
            {
                if (matrice1[8][5].transform.GetChild(matrice1[8][5].transform.childCount - 1).tag == item)
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[8][4].transform.position.x, matrice1[8][4].transform.position.y, matrice1[8][4].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[8][5].transform.position.x, matrice1[8][5].transform.position.y, matrice1[8][5].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    el4.transform.SetParent(fireparent.transform);
                    GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play(0);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 15 * vectorbet[bet];
                    else if (item == "bell") win += 20 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 70 * vectorbet[bet];
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[8][4].transform.position.x, matrice1[8][4].transform.position.y, matrice1[8][4].transform.position.z + 0.2f), Quaternion.identity);
                     el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 3 * vectorbet[bet];
                    else if (item == "bell") win += 4 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 12 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                 el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                el2.transform.SetParent(fireparent.transform);
                if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += vectorbet[bet];
                else if (item == "bell") win += 2 * vectorbet[bet];
                else if (item == "grapes" || item == "watermelon") win += 4 * vectorbet[bet];
            }
        }
        //-----LINIA 8------
        if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown") && (matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == item || matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == item || matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == "crown")
            {
                if (matrice1[8][5].transform.GetChild(matrice1[8][5].transform.childCount - 1).tag == item)
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[9][4].transform.position.x, matrice1[9][4].transform.position.y, matrice1[9][4].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[8][5].transform.position.x, matrice1[8][5].transform.position.y, matrice1[8][5].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    el4.transform.SetParent(fireparent.transform);
                    GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play(0);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 15 * vectorbet[bet];
                    else if (item == "bell") win += 20 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 70 * vectorbet[bet];
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[9][4].transform.position.x, matrice1[9][4].transform.position.y, matrice1[9][4].transform.position.z + 0.2f), Quaternion.identity);
                     el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 3 * vectorbet[bet];
                    else if (item == "bell") win += 4 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 12 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                el2.transform.SetParent(fireparent.transform);
                if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += vectorbet[bet];
                else if (item == "bell") win += 2 * vectorbet[bet];
                else if (item == "grapes" || item == "watermelon") win += 4 * vectorbet[bet];
            }
        }
        //-----LINIA 9-----
        if (matrice1[9][1].transform.GetChild(matrice1[9][1].transform.childCount - 1).tag == item && (matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == item || matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == "crown") && (matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == item || matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == item || matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == "crown")
            {
                if (matrice1[9][5].transform.GetChild(matrice1[9][5].transform.childCount - 1).tag == item)
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[10][4].transform.position.x, matrice1[10][4].transform.position.y, matrice1[10][4].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[9][5].transform.position.x, matrice1[9][5].transform.position.y, matrice1[9][5].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    el4.transform.SetParent(fireparent.transform);
                    GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play(0);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 15 * vectorbet[bet];
                    else if (item == "bell") win += 20 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 70 * vectorbet[bet];
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[10][4].transform.position.x, matrice1[10][4].transform.position.y, matrice1[10][4].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 3 * vectorbet[bet];
                    else if (item == "bell") win += 4 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 12 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                el2.transform.SetParent(fireparent.transform);
                if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += vectorbet[bet];
                else if (item == "bell") win += 2 * vectorbet[bet];
                else if (item == "grapes" || item == "watermelon") win += 4 * vectorbet[bet];
            }
        }
        //-----LINIA 10-----
        if (matrice1[9][1].transform.GetChild(matrice1[9][1].transform.childCount - 1).tag == item && (matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == item || matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == "crown") && (matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == item || matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == item || matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == "crown")
            {
                if (matrice1[9][5].transform.GetChild(matrice1[9][5].transform.childCount - 1).tag == item)
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[8][4].transform.position.x, matrice1[8][4].transform.position.y, matrice1[8][4].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[9][5].transform.position.x, matrice1[9][5].transform.position.y, matrice1[9][5].transform.position.z + 0.2f), Quaternion.identity);
                    el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    el4.transform.SetParent(fireparent.transform);
                    GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play(0);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 15 * vectorbet[bet];
                    else if (item == "bell") win += 20 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 70 * vectorbet[bet];
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[8][4].transform.position.x, matrice1[8][4].transform.position.y, matrice1[8][4].transform.position.z + 0.2f), Quaternion.identity);
                     el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    el3.transform.SetParent(fireparent.transform);
                    if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += 3 * vectorbet[bet];
                    else if (item == "bell") win += 4 * vectorbet[bet];
                    else if (item == "grapes" || item == "watermelon") win += 12 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                 el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                el2.transform.SetParent(fireparent.transform);
                if (item == "cherry" || item == "lemon" || item == "plum" || item == "peach") win += vectorbet[bet];
                else if (item == "bell") win += 2 * vectorbet[bet];
                else if (item == "grapes" || item == "watermelon") win += 4 * vectorbet[bet];
            }
        }
    }
   
    void VerificareWinSeptari(string item)
    {
        //VERIFICARE SEPTARI
        //-----LINIA 1-----
        if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == item || matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == item || matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == "crown") && (matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == item || matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == "crown"))
            {
                if (matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == item || matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == "crown")
                {
                    if (matrice1[8][5].transform.GetChild(matrice1[8][5].transform.childCount - 1).tag == item)
                    {
                        GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                        GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[8][4].transform.position.x, matrice1[8][4].transform.position.y, matrice1[8][4].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[8][5].transform.position.x, matrice1[8][5].transform.position.y, matrice1[8][5].transform.position.z + 0.2f), Quaternion.identity);
                        el.transform.SetParent(fireparent.transform);
                        el1.transform.SetParent(fireparent.transform);
                        el2.transform.SetParent(fireparent.transform);
                        el3.transform.SetParent(fireparent.transform);
                        el4.transform.SetParent(fireparent.transform);
                        win += 500 * vectorbet[bet];
                    }
                    else
                    {
                        GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                        GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[8][4].transform.position.x, matrice1[8][4].transform.position.y, matrice1[8][4].transform.position.z + 0.2f), Quaternion.identity);
                        el.transform.SetParent(fireparent.transform);
                        el1.transform.SetParent(fireparent.transform);
                        el2.transform.SetParent(fireparent.transform);
                        el3.transform.SetParent(fireparent.transform);
                        win += 25 * vectorbet[bet];
                    }
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[8][3].transform.position.x, matrice1[8][3].transform.position.y, matrice1[8][3].transform.position.z + 0.2f), Quaternion.identity);
                     el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    win += 5 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[8][1].transform.position.x, matrice1[8][1].transform.position.y, matrice1[8][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[8][2].transform.position.x, matrice1[8][2].transform.position.y, matrice1[8][2].transform.position.z + 0.2f), Quaternion.identity);
                 el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                win += vectorbet[bet];
            }
        }
        //----LINIA 2-----
        if (matrice1[9][1].transform.GetChild(matrice1[9][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[9][1].transform.GetChild(matrice1[9][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown") && (matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == item || matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == "crown"))
            {
                if (matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == item || matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == "crown")
                {
                    if (matrice1[9][5].transform.GetChild(matrice1[9][5].transform.childCount - 1).tag == item)
                    {
                        GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                        GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[9][4].transform.position.x, matrice1[9][4].transform.position.y, matrice1[9][4].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[9][5].transform.position.x, matrice1[9][5].transform.position.y, matrice1[9][5].transform.position.z + 0.2f), Quaternion.identity);
                        el.transform.SetParent(fireparent.transform);
                        el1.transform.SetParent(fireparent.transform);
                        el2.transform.SetParent(fireparent.transform);
                        el3.transform.SetParent(fireparent.transform);
                        el4.transform.SetParent(fireparent.transform);
                        win += 500 * vectorbet[bet];
                    }
                    else
                    {
                        GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                        GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[9][4].transform.position.x, matrice1[9][4].transform.position.y, matrice1[9][4].transform.position.z + 0.2f), Quaternion.identity);
                         el.transform.SetParent(fireparent.transform);
                        el1.transform.SetParent(fireparent.transform);
                        el2.transform.SetParent(fireparent.transform);
                        el3.transform.SetParent(fireparent.transform);
                        win += 25 * vectorbet[bet];
                    }
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[9][3].transform.position.x, matrice1[9][3].transform.position.y, matrice1[9][3].transform.position.z + 0.2f), Quaternion.identity);
                     el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    win += 5 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[9][1].transform.position.x, matrice1[9][1].transform.position.y, matrice1[9][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[9][2].transform.position.x, matrice1[9][2].transform.position.y, matrice1[9][2].transform.position.z + 0.2f), Quaternion.identity);
                 el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                win += vectorbet[bet];
            }
        }
        //-----LINIA 3-----
        if (matrice1[10][1].transform.GetChild(matrice1[10][1].transform.childCount - 1).tag == item && (matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == item || matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[10][1].transform.GetChild(matrice1[10][1].transform.childCount - 1).tag == item && (matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == item || matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == "crown") && (matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == item || matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == "crown"))
            {
                if (matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == item || matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == "crown")
                {
                    if (matrice1[10][5].transform.GetChild(matrice1[10][5].transform.childCount - 1).tag == item)
                    {
                        GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                        GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[10][4].transform.position.x, matrice1[10][4].transform.position.y, matrice1[10][4].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el4 = GameObject.Instantiate(fire, new Vector3(matrice1[10][5].transform.position.x, matrice1[10][5].transform.position.y, matrice1[10][5].transform.position.z + 0.2f), Quaternion.identity);
                        el.transform.SetParent(fireparent.transform);
                        el1.transform.SetParent(fireparent.transform);
                        el2.transform.SetParent(fireparent.transform);
                        el3.transform.SetParent(fireparent.transform);
                        el4.transform.SetParent(fireparent.transform);
                        win += 500 * vectorbet[bet];
                    }
                    else
                    {
                        GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                        GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                        GameObject el3 = GameObject.Instantiate(fire, new Vector3(matrice1[10][4].transform.position.x, matrice1[10][4].transform.position.y, matrice1[10][4].transform.position.z + 0.2f), Quaternion.identity);
                         el.transform.SetParent(fireparent.transform);
                        el1.transform.SetParent(fireparent.transform);
                        el2.transform.SetParent(fireparent.transform);
                        el3.transform.SetParent(fireparent.transform);
                        win += 25 * vectorbet[bet];
                    }
                }
                else
                {
                    GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                    GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                    GameObject el2 = GameObject.Instantiate(fire, new Vector3(matrice1[10][3].transform.position.x, matrice1[10][3].transform.position.y, matrice1[10][3].transform.position.z + 0.2f), Quaternion.identity);
                     el.transform.SetParent(fireparent.transform);
                    el1.transform.SetParent(fireparent.transform);
                    el2.transform.SetParent(fireparent.transform);
                    win += 5 * vectorbet[bet];
                }
            }
            else
            {
                GameObject el = GameObject.Instantiate(fire, new Vector3(matrice1[10][1].transform.position.x, matrice1[10][1].transform.position.y, matrice1[10][1].transform.position.z + 0.2f), Quaternion.identity); ;
                GameObject el1 = GameObject.Instantiate(fire, new Vector3(matrice1[10][2].transform.position.x, matrice1[10][2].transform.position.y, matrice1[10][2].transform.position.z + 0.2f), Quaternion.identity);
                el.transform.SetParent(fireparent.transform);
                el1.transform.SetParent(fireparent.transform);
                win += vectorbet[bet];
            }
        }
        //-----LINIA 4-----
        if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown") && (matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == item || matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == "crown"))
            {
                if (matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == item || matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == "crown")
                {
                    if (matrice1[8][5].transform.GetChild(matrice1[8][5].transform.childCount - 1).tag == item)
                    {
                        win += 500 * vectorbet[bet];
                    }
                    else
                    {
                        win += 25 * vectorbet[bet];
                    }
                }
                else
                {
                    win += 5 * vectorbet[bet];
                }
            }
            else
            {
                win += vectorbet[bet];
            }
        }
        //-----LINIA 5-----
        if (matrice1[10][1].transform.GetChild(matrice1[10][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[10][1].transform.GetChild(matrice1[10][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown") && (matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == item || matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == "crown"))
            {
                if (matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == item || matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == "crown")
                {
                    if (matrice1[10][5].transform.GetChild(matrice1[10][5].transform.childCount - 1).tag == item)
                    {
                        win += 500 * vectorbet[bet];
                    }
                    else
                    {
                        win += 25 * vectorbet[bet];
                    }
                }
                else
                {
                    win += 5 * vectorbet[bet];
                }
            }
            else
            {
                win += vectorbet[bet];
            }
        }
        //-----LINIA 6-----
        if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == item || matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == item || matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == "crown") && (matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == item || matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == "crown"))
            {
                if (matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == item || matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == "crown")
                {
                    if (matrice1[10][5].transform.GetChild(matrice1[10][5].transform.childCount - 1).tag == item)
                    {
                        win += 500 * vectorbet[bet];
                    }
                    else
                    {
                        win += 25 * vectorbet[bet];
                    }
                }
                else
                {
                    win += 5 * vectorbet[bet];
                }
            }
            else
            {
                win += vectorbet[bet];
            }
        }
        //-----LINIA 7-----
        if (matrice1[10][1].transform.GetChild(matrice1[10][1].transform.childCount - 1).tag == item && (matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == item || matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[10][1].transform.GetChild(matrice1[10][1].transform.childCount - 1).tag == item && (matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == item || matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == "crown") && (matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == item || matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == "crown"))
            {
                if (matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == item || matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == "crown")
                {
                    if (matrice1[8][5].transform.GetChild(matrice1[8][5].transform.childCount - 1).tag == item)
                    {
                        win += 500 * vectorbet[bet];
                    }
                    else
                    {
                        win += 25 * vectorbet[bet];
                    }
                }
                else
                {
                    win += 5 * vectorbet[bet];
                }
            }
            else
            {
                win += vectorbet[bet];
            }
        }
        //-----LINIA 8------
        if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[8][1].transform.GetChild(matrice1[8][1].transform.childCount - 1).tag == item && (matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == item || matrice1[9][2].transform.GetChild(matrice1[9][2].transform.childCount - 1).tag == "crown") && (matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == item || matrice1[9][3].transform.GetChild(matrice1[9][3].transform.childCount - 1).tag == "crown"))
            {
                if (matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == item || matrice1[9][4].transform.GetChild(matrice1[9][4].transform.childCount - 1).tag == "crown")
                {
                    if (matrice1[8][5].transform.GetChild(matrice1[8][5].transform.childCount - 1).tag == item)
                    {
                        win += 500 * vectorbet[bet];
                    }
                    else
                    {
                        win += 25 * vectorbet[bet];
                    }
                }
                else
                {
                    win += 5 * vectorbet[bet];
                }
            }
            else
            {
                win += vectorbet[bet];
            }
        }
        //-----LINIA 9-----
        if (matrice1[9][1].transform.GetChild(matrice1[9][1].transform.childCount - 1).tag == item && (matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == item || matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[9][1].transform.GetChild(matrice1[9][1].transform.childCount - 1).tag == item && (matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == item || matrice1[10][2].transform.GetChild(matrice1[10][2].transform.childCount - 1).tag == "crown") && (matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == item || matrice1[10][3].transform.GetChild(matrice1[10][3].transform.childCount - 1).tag == "crown"))
            {
                if (matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == item || matrice1[10][4].transform.GetChild(matrice1[10][4].transform.childCount - 1).tag == "crown")
                {
                    if (matrice1[9][5].transform.GetChild(matrice1[9][5].transform.childCount - 1).tag == item)
                    {
                        win += 500 * vectorbet[bet];
                    }
                    else
                    {
                        win += 25 * vectorbet[bet];
                    }
                }
                else
                {
                    win += 5 * vectorbet[bet];
                }
            }
            else
            {
                win += vectorbet[bet];
            }
        }
        //-----LINIA 10-----
        if (matrice1[9][1].transform.GetChild(matrice1[9][1].transform.childCount - 1).tag == item && (matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == item || matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == "crown"))
        {
            if (matrice1[9][1].transform.GetChild(matrice1[9][1].transform.childCount - 1).tag == item && (matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == item || matrice1[8][2].transform.GetChild(matrice1[8][2].transform.childCount - 1).tag == "crown") && (matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == item || matrice1[8][3].transform.GetChild(matrice1[8][3].transform.childCount - 1).tag == "crown"))
            {
                if (matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == item || matrice1[8][4].transform.GetChild(matrice1[8][4].transform.childCount - 1).tag == "crown")
                {
                    if (matrice1[9][5].transform.GetChild(matrice1[9][5].transform.childCount - 1).tag == item)
                    {
                        win += 500 * vectorbet[bet];
                    }
                    else
                    {
                        win += 25 * vectorbet[bet];
                    }
                }
                else
                {
                    win += 5 * vectorbet[bet];
                }
            }
            else
            {
                win += vectorbet[bet];
            }
        }
    }
    public void NextBet()
    {
        if (bet <= 10)
        {
            bet++;
            if (bet == 1)
            {
                GameObject.FindWithTag("GameController").GetComponent<Text>().text = (vectorbet[bet] / 100).ToString() + ".0" + (vectorbet[bet] % 100).ToString();
            }
            else if (bet > 6)
            {
                GameObject.FindWithTag("GameController").GetComponent<Text>().text = (vectorbet[bet] / 100).ToString() + "." + (vectorbet[bet] % 100).ToString()+"0";
            }
            else
            {
                GameObject.FindWithTag("GameController").GetComponent<Text>().text = (vectorbet[bet] / 100).ToString() + "." + (vectorbet[bet] % 100).ToString();
            }
        }
        else
        {
            bet = 1;
            GameObject.FindWithTag("GameController").GetComponent<Text>().text = (vectorbet[bet] / 100).ToString() + ".0" + (vectorbet[bet] % 100).ToString();
        }
        PlayerPrefs.SetInt("bet", bet);
        SetareWins();
    }
    public void SetBet()
    {
        GameObject.FindWithTag("GameController").GetComponent<Text>().text = (vectorbet[bet]/100).ToString()+"."+(vectorbet[bet]%100).ToString();
    }
    void RemoveFire()
    {
        for(int i = fireparent.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(fireparent.transform.GetChild(i).gameObject);
        }
    }
    void VerificareCoroana()
    {
        for(int i = 8; i <= 10; i++)
        {
            for(int j = 2; j <= 4; j++)
            {
                if (matrice1[i][j].transform.GetChild(matrice1[i][j].transform.childCount - 1).CompareTag("crown") == true)
                {
                    GameObject.Find("crown").GetComponent<AudioSource>().Play();
                    if (i == 9)
                    {
                        Transform kid = matrice1[i - 1][j].transform.GetChild(matrice1[i - 1][j].transform.childCount - 1);
                        GameObject.Destroy(kid.gameObject);
                        matrice1[i - 1][j].GetComponent<Element11>().SetCrown(matrice1[i - 1][j].transform.position);
                        kid = matrice1[i + 1][j].transform.GetChild(matrice1[i + 1][j].transform.childCount - 1);
                        GameObject.Destroy(kid.gameObject);
                        matrice1[i + 1][j].GetComponent<Element11>().SetCrown(matrice1[i + 1][j].transform.position);
                    }else if (i == 8)
                    {
                        Transform kid = matrice1[i + 1][j].transform.GetChild(matrice1[i + 1][j].transform.childCount - 1);
                        GameObject.Destroy(kid.gameObject);
                        matrice1[i +1 ][j].GetComponent<Element11>().SetCrown(matrice1[i + 1][j].transform.position);
                        kid = matrice1[i + 2][j].transform.GetChild(matrice1[i + 2][j].transform.childCount - 1);
                        GameObject.Destroy(kid.gameObject);
                        matrice1[i + 2][j].GetComponent<Element11>().SetCrown(matrice1[i + 2][j].transform.position);
                    }else if (i == 10)
                    {
                        Transform kid = matrice1[i - 1][j].transform.GetChild(matrice1[i - 1][j].transform.childCount - 1);
                        GameObject.Destroy(kid.gameObject);
                        matrice1[i - 1][j].GetComponent<Element11>().SetCrown(matrice1[i - 1][j].transform.position);
                        kid = matrice1[i - 2][j].transform.GetChild(matrice1[i - 2][j].transform.childCount - 1);
                        GameObject.Destroy(kid.gameObject);
                        matrice1[i -2][j].GetComponent<Element11>().SetCrown(matrice1[i -2][j].transform.position);
                    }
                }
            }
        }
    }
    void AscundeWins(bool x)
    {
        
        for(int i = 1; i <= 23; i++)
        {
            g1[i].SetActive(x);
        }
    }
    void SetareWins()
    {
        g1[22].GetComponent<Text>().text = (vectorbet[bet]/100).ToString()+"."+ (vectorbet[bet] % 100).ToString();
        g1[19].GetComponent<Text>().text = (vectorbet[bet] / 100).ToString() + "." + (vectorbet[bet] % 100).ToString();
        g1[4].GetComponent<Text>().text = (vectorbet[bet] / 100).ToString() + "." + (vectorbet[bet] % 100).ToString();
        g1[20].GetComponent<Text>().text = (3*vectorbet[bet]/100).ToString()+"."+ (3 * vectorbet[bet] % 100).ToString();
        g1[18].GetComponent<Text>().text = (3 * vectorbet[bet] / 100).ToString() + "." + (3 * vectorbet[bet] % 100).ToString();
        g1[17].GetComponent<Text>().text = (15*vectorbet[bet]/100).ToString()+"."+ (15 * vectorbet[bet] % 100).ToString();
        g1[21].GetComponent<Text>().text = (15 * vectorbet[bet] / 100).ToString() + "." + (15 * vectorbet[bet] % 100).ToString();
        g1[16].GetComponent<Text>().text = (2*vectorbet[bet]/100).ToString()+"."+ (2 * vectorbet[bet] % 100).ToString();
        g1[15].GetComponent<Text>().text = (4*vectorbet[bet]/100).ToString()+"."+ (4 * vectorbet[bet]%100).ToString();
        g1[14].GetComponent<Text>().text = (20*vectorbet[bet]/100).ToString()+"."+ (20 * vectorbet[bet]%100).ToString();
        g1[7].GetComponent<Text>().text = (4 * vectorbet[bet] / 100).ToString() + "." + (4 * vectorbet[bet] % 100).ToString();
        g1[10].GetComponent<Text>().text = (4 * vectorbet[bet] / 100).ToString() + "." + (4 * vectorbet[bet] % 100).ToString();
        g1[9].GetComponent<Text>().text = (12*vectorbet[bet]/100).ToString()+"."+ (12 * vectorbet[bet]%100).ToString();
        g1[6].GetComponent<Text>().text = (12 * vectorbet[bet] / 100).ToString() + "." + (12 * vectorbet[bet] % 100).ToString();
        g1[8].GetComponent<Text>().text = (70*vectorbet[bet]/100).ToString()+"."+ (70 * vectorbet[bet]%100).ToString();
        g1[5].GetComponent<Text>().text = (70 * vectorbet[bet] / 100).ToString() + "." + (70 * vectorbet[bet] % 100).ToString();
        g1[3].GetComponent<Text>().text = (5*vectorbet[bet]/100).ToString()+"."+ (5 * vectorbet[bet]%100).ToString();
        g1[2].GetComponent<Text>().text = (25*vectorbet[bet]/100).ToString()+"."+ (25 * vectorbet[bet]%100).ToString();
        g1[1].GetComponent<Text>().text = (500*vectorbet[bet]/100).ToString()+"."+ (500 * vectorbet[bet] % 100).ToString();
        g1[11].GetComponent<Text>().text = (100*vectorbet[bet]/100).ToString()+"."+ (100 * vectorbet[bet] % 100).ToString();
        g1[12].GetComponent<Text>().text = (20 * vectorbet[bet] / 100).ToString() + "." + (20 * vectorbet[bet] % 100).ToString();
        g1[13].GetComponent<Text>().text = (5 * vectorbet[bet] / 100).ToString() + "." + (5 * vectorbet[bet] % 100).ToString();
        g1[23].GetComponent<Text>().text = (20 * vectorbet[bet] / 100).ToString() + "." + (20 * vectorbet[bet] % 100).ToString();
    }
    void Initialize()
    {
        g1[1] = GameObject.Find("Sep5");
        g1[2] = GameObject.Find("Sep4");
        g1[3] = GameObject.Find("Sep3");
        g1[4] = GameObject.Find("Sep2");
        g1[5] = GameObject.Find("Str5");
        g1[6] = GameObject.Find("Str4");
        g1[7] = GameObject.Find("Str3");
        g1[8] = GameObject.Find("hrb5");
        g1[9] = GameObject.Find("hrb4");
        g1[10] = GameObject.Find("hrb3");
        g1[11] = GameObject.Find("dlr5");
        g1[12] = GameObject.Find("dlr4");
        g1[13] = GameObject.Find("dlr3");
        g1[14] = GameObject.Find("clp5");
        g1[15] = GameObject.Find("clp4");
        g1[16] = GameObject.Find("clp3");
        g1[17] = GameObject.Find("pr5");
        g1[18] = GameObject.Find("pr4");
        g1[19] = GameObject.Find("pr3");
        g1[20] = GameObject.Find("lm4");
        g1[21] = GameObject.Find("lm5");
        g1[22] = GameObject.Find("lm3");
        g1[23] = GameObject.Find("star");
        matrice1[1] = new GameObject[6];
        matrice1[2] = new GameObject[6];
        matrice1[3] = new GameObject[6];
        matrice1[4] = new GameObject[6];
        matrice1[5] = new GameObject[6];
        matrice1[6] = new GameObject[6];
        matrice1[7] = new GameObject[6];
        matrice1[8] = new GameObject[6];
        matrice1[9] = new GameObject[6];
        matrice1[10] = new GameObject[6];
        matrice1[11] = new GameObject[6];
        matrice1[12] = new GameObject[6];
        matrice1[13] = new GameObject[6];
        matrice1[14] = new GameObject[6];
        matrice1[15] = new GameObject[6];
        matrice1[16] = new GameObject[6];
        matrice1[17] = new GameObject[6];
        matrice1[18] = new GameObject[6];
        matrice1[19] = new GameObject[6];
        matrice1[20] = new GameObject[6];
        obj1 = GameObject.FindWithTag("Element1");
        matrice1[8][1] = GameObject.Instantiate(go, obj1.transform.position, Quaternion.identity);
        obj2 = GameObject.FindWithTag("Element2");
        matrice1[8][2] = GameObject.Instantiate(go, obj2.transform.position, Quaternion.identity);
        obj3 = GameObject.FindWithTag("Element3");
        matrice1[8][3] = GameObject.Instantiate(go, obj3.transform.position, Quaternion.identity);
        obj4 = GameObject.FindWithTag("Element4");
        matrice1[8][4] = GameObject.Instantiate(go, obj4.transform.position, Quaternion.identity);
        obj5 = GameObject.FindWithTag("Element5");
        matrice1[8][5] = GameObject.Instantiate(go, obj5.transform.position, Quaternion.identity);
        obj6 = GameObject.FindWithTag("Element6");
        matrice1[9][1] = GameObject.Instantiate(go, obj6.transform.position, Quaternion.identity);
        obj7 = GameObject.FindWithTag("Element7");
        matrice1[9][2] = GameObject.Instantiate(go, obj7.transform.position, Quaternion.identity);
        obj8 = GameObject.FindWithTag("Element8");
        matrice1[9][3] = GameObject.Instantiate(go, obj8.transform.position, Quaternion.identity);
        obj9 = GameObject.FindWithTag("Element9");
        matrice1[9][4] = GameObject.Instantiate(go, obj9.transform.position, Quaternion.identity);
        obj10 = GameObject.FindWithTag("Element10");
        matrice1[9][5] = GameObject.Instantiate(go, obj10.transform.position, Quaternion.identity);
        obj11 = GameObject.FindWithTag("Elements11");
        matrice1[10][1] = GameObject.Instantiate(go, obj11.transform.position, Quaternion.identity);
        obj12 = GameObject.FindWithTag("Elements12");
        matrice1[10][2] = GameObject.Instantiate(go, obj12.transform.position, Quaternion.identity);
        obj13 = GameObject.FindWithTag("Elements13");
        matrice1[10][3] = GameObject.Instantiate(go, obj13.transform.position, Quaternion.identity);
        obj14 = GameObject.FindWithTag("Elements14");
        matrice1[10][4] = GameObject.Instantiate(go, obj14.transform.position, Quaternion.identity);
        obj15 = GameObject.FindWithTag("Elements15");
        matrice1[10][5] = GameObject.Instantiate(go, obj15.transform.position, Quaternion.identity);
        for (int i = 8; i <= 10; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                matrice1[i][j].gameObject.AddComponent<Element11>();
            }
        }
    }
    void MatriceAscunsa()
    {
         
        for (int i = 1; i <= 7; i++)
        {
            matrice1[i][1].GetComponent<Element11>().spincol1(matrice1[i][1].transform.position);
        }
        for (int i = 1; i <= 7; i++)
        {
            matrice1[i][2].GetComponent<Element11>().spincol2(matrice1[i][2].transform.position);
        }
        for (int i = 1; i <= 7; i++)
        {
            matrice1[i][3].GetComponent<Element11>().spincol3(matrice1[i][3].transform.position);
        }
        for (int i = 1; i <= 7; i++)
        {
            matrice1[i][4].GetComponent<Element11>().spincol4(matrice1[i][4].transform.position);
        }
        for (int i = 1; i <= 7; i++)
        {
            matrice1[i][5].GetComponent<Element11>().spincol5(matrice1[i][5].transform.position);
        }
    }
    public void SchimbaScena(string scena)
    {
        if (win > 0)
        {
            SceneManager.LoadScene(scena);
        }
    }
    public void paylines()
    {
        if (Camera.main.transform.position.y > -24.2f)
        {
            GameObject.FindWithTag("spinbtn").GetComponent<Button>().enabled = false;
            Camera.main.transform.Translate(0, -12.1f, 0);
            if (Camera.main.transform.position.y == -24.2f)
            {
                SetareWins();
                AscundeWins(true);
            }
        }
        else
        {
            Camera.main.transform.position = new Vector3(0, 0, -10f);
             AscundeWins(false);
            GameObject.FindWithTag("spinbtn").GetComponent<Button>().enabled = true;
        }

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("credit", credit);
    }
    // Update is called once per frame

}
