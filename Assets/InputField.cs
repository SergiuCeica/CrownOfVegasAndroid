using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public InputField input;
    public string ftext;
    // Start is called before the first frame update
    void Start()
    {
        input = GameObject.FindWithTag("Player").GetComponent<InputField>();
        ftext = "1";
    }
    private void SetBet()
    {

    }
    // Update is called once per frame
    void Update()
    {
        ftext = GameObject.FindWithTag("Finish").GetComponent<Text>().text;
        GameObject btn = GameObject.FindWithTag("GameController");
        btn.GetComponent<Text>().text = ftext;
    }
}
