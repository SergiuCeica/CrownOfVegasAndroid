using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Element11 : MonoBehaviour
{
    public Vector3 poz;
    public static List<GameObject> elemente;
    GameObject[] coloana1,coloana2,coloana3,coloana4,coloana5;
    void Start()
    {
        elemente = new List<GameObject>();
        poz = this.transform.position;
        coloana1 = new GameObject[101];
        coloana2 = new GameObject[101];
        coloana3 = new GameObject[101];
        coloana4 = new GameObject[101];
        coloana5 = new GameObject[101];
        seteazacoloane();
        elemente.Add( GameObject.Find("cherry"));
        elemente.Add(GameObject.Find("lemon-fruit-png-clipart-9"));
        elemente.Add(GameObject.Find("peach"));
        elemente.Add(GameObject.Find("plum"));
        elemente.Add(GameObject.Find("bell"));
        elemente.Add(GameObject.Find("dollar sign"));
        elemente.Add(GameObject.Find("watermelon"));
        elemente.Add(GameObject.Find("grapes"));
        elemente.Add(GameObject.Find("unnamed"));
        elemente.Add( GameObject.Find("sevenn"));
        elemente.Add(GameObject.Find("crown"));
      
    }
    // Update is called once per frame
    void Update()
    {

    }
    public GameObject returnelement() {
        return elemente[Random.Range(0, 11)];
    }
    public  void Spin(Vector3 position) {
                
           GameObject Element = GameObject.Instantiate(elemente[Random.Range(0, 11)], position, Quaternion.identity) as GameObject;
           Element.transform.SetParent(this.transform);
    }
    public void ExceptionSpin(Vector3 position)
    {
        int x = Random.Range(0, 11);
        while (x == 5 || x == 8 || x==10) {
            x = Random.Range(0,11);
        }
        GameObject Element = GameObject.Instantiate(elemente[x], position, Quaternion.identity) as GameObject;
        Element.transform.SetParent(this.transform);
    }
    public void SetCrown(Vector3 position)
    {
        GameObject Element = GameObject.Instantiate(elemente[10], position, Quaternion.identity) as GameObject;
        Element.transform.SetParent(this.transform);
    }
    public void spincol1(Vector3 position)
    {
        try
        {
            GameObject Element = GameObject.Instantiate(coloana1[Random.Range(1, 101)], position, Quaternion.identity) as GameObject;
            Element.transform.SetParent(this.transform);
        }
        catch {}
    }
    public void spincol2(Vector3 position)
    {
        try
        {
            GameObject Element = GameObject.Instantiate(coloana2[Random.Range(1, 101)], position, Quaternion.identity) as GameObject;
        Element.transform.SetParent(this.transform);
        }
        catch { Debug.Log("Coloana 2"); }
    }
    public void spincol3(Vector3 position)
    {
            try
            {
                GameObject Element = GameObject.Instantiate(coloana3[Random.Range(1, 101)], position, Quaternion.identity) as GameObject;
        Element.transform.SetParent(this.transform);
            }
            catch { Debug.Log("Coloana 3"); }
        }
    public void spincol4(Vector3 position)
    {
                try
                {
                    GameObject Element = GameObject.Instantiate(coloana4[Random.Range(1, 101)], position, Quaternion.identity) as GameObject;
        Element.transform.SetParent(this.transform);
        }
        catch { Debug.Log("Coloana 4"); }
    }
    public void spincol5(Vector3 position)
    {
                    try
                    {
                        GameObject Element = GameObject.Instantiate(coloana5[Random.Range(1, 101)], position, Quaternion.identity) as GameObject;
        Element.transform.SetParent(this.transform);
        }
        catch { Debug.Log("Coloana 5"); }
    }
    public void seteazacoloane()
    {
        //-----COLOANA 1-----
        for (int i = 1; i <= 10; i++) coloana1[i] = GameObject.Find("cherry");
        for (int i = 11; i <= 20; i++)coloana1[i] = GameObject.Find("lemon-fruit-png-clipart-9");
        for (int i = 21; i <= 30; i++) coloana1[i] = GameObject.Find("peach");
        for (int i = 31; i <= 40; i++) coloana1[i] = GameObject.Find("plum");
        for (int i = 41; i <= 50; i++) coloana1[i] = GameObject.Find("bell");
        for (int i = 51; i <= 60; i++) coloana1[i] = GameObject.Find("dollar sign");
        for (int i = 61; i <= 70; i++) coloana1[i] = GameObject.Find("watermelon");
        for (int i = 71; i <= 80; i++)coloana1[i] = GameObject.Find("grapes");
        for (int i = 81; i <= 90; i++)coloana1[i] = GameObject.Find("unnamed");
        for (int i = 91; i <= 100; i++) coloana1[i] = GameObject.Find("sevenn");
        //------COLOANA 2------
        for (int i = 1; i <= 12; i++) coloana2[i] = GameObject.Find("cherry");
        for (int i = 13; i <= 24; i++) coloana2[i] = GameObject.Find("lemon-fruit-png-clipart-9");
        for (int i = 25; i <= 34; i++) coloana2[i] = GameObject.Find("peach");
        for (int i = 35; i <= 44; i++) coloana2[i] = GameObject.Find("plum");
        for (int i = 45; i <= 54; i++) coloana2[i] = GameObject.Find("bell");
        for (int i = 55; i <= 64; i++) coloana2[i] = GameObject.Find("dollar sign");
        for (int i = 65; i <= 70; i++) coloana2[i] = GameObject.Find("watermelon");
        for (int i = 71; i <= 76; i++) coloana2[i] = GameObject.Find("grapes");
        for (int i = 77; i <= 86; i++) coloana2[i] = GameObject.Find("crown");
        for (int i = 87; i <= 94; i++) coloana2[i] = GameObject.Find("sevenn");
        for (int i = 95; i <= 100; i++) coloana2[i] = GameObject.Find("cherry");
        //-------COLOANA 3------
        for (int i = 1; i <= 12; i++) coloana3[i] = GameObject.Find("cherry");
        for (int i = 13; i <= 24; i++) coloana3[i] = GameObject.Find("lemon-fruit-png-clipart-9");
        for (int i = 25; i <= 33; i++) coloana3[i] = GameObject.Find("peach");
        for (int i = 34; i <= 43; i++) coloana3[i] = GameObject.Find("plum");
        for (int i = 44; i <= 52; i++) coloana3[i] = GameObject.Find("bell");
        for (int i = 53; i <= 62; i++) coloana3[i] = GameObject.Find("dollar sign");
        for (int i = 63; i <= 69; i++) coloana3[i] = GameObject.Find("watermelon");
        for (int i = 70; i <= 75; i++) coloana3[i] = GameObject.Find("grapes");
        for (int i = 76; i <= 79; i++) coloana3[i] = GameObject.Find("cherry");
        for (int i = 80; i <= 84; i++) coloana3[i] = GameObject.Find("crown");
        for (int i = 85; i <= 93; i++) coloana3[i] = GameObject.Find("sevenn");
        for (int i = 94; i <= 100; i++) coloana3[i] = GameObject.Find("unnamed");
        //------COLOANA 4------
        for (int i = 1; i <= 14; i++) coloana4[i] = GameObject.Find("cherry");
        for (int i = 15; i <= 28; i++) coloana4[i] = GameObject.Find("lemon-fruit-png-clipart-9");
        for (int i = 29; i <= 37; i++) coloana4[i] = GameObject.Find("peach");
        for (int i = 38; i <= 47; i++) coloana4[i] = GameObject.Find("plum");
        for (int i = 48; i <= 56; i++) coloana4[i] = GameObject.Find("bell");
        for (int i = 57; i <= 64; i++) coloana4[i] = GameObject.Find("dollar sign");
        for (int i = 65; i <= 72; i++) coloana4[i] = GameObject.Find("watermelon");
        for (int i = 73; i <= 80; i++) coloana4[i] = GameObject.Find("grapes");
        for (int i = 81; i <= 86; i++) coloana4[i] = GameObject.Find("lemon-fruit-png-clipart-9");
        for (int i = 87; i <= 91; i++) coloana4[i] = GameObject.Find("crown");
        for (int i = 92; i <= 100; i++) coloana4[i] = GameObject.Find("sevenn");
        //-------COLOANA 5------
        for (int i = 1; i <= 19; i++) coloana5[i] = GameObject.Find("cherry");
        for (int i = 20; i <= 38; i++) coloana5[i] = GameObject.Find("lemon-fruit-png-clipart-9");
        for (int i = 39; i <= 42; i++) coloana5[i] = GameObject.Find("peach");
        for (int i = 43; i <= 56; i++) coloana5[i] = GameObject.Find("plum");
        for (int i = 57; i <= 67; i++) coloana5[i] = GameObject.Find("bell");
        for (int i = 68; i <= 74; i++) coloana5[i] = GameObject.Find("dollar sign");
        for (int i = 75; i <= 80; i++) coloana5[i] = GameObject.Find("watermelon");
        for (int i = 81; i <= 88; i++) coloana5[i] = GameObject.Find("grapes");
        for (int i = 89; i <= 94; i++) coloana5[i] = GameObject.Find("sevenn");
        for (int i = 95; i <= 100; i++) coloana5[i] = GameObject.Find("unnamed");
    }
}
