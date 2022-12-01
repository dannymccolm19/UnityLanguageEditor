using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{

    public English english;
    public French french;
    public German german;
    public Spanish spanish;
    public Italian italian;

    public TMP_Text textm;
    public TMP_Dropdown drop;
    public Button next;
    public Button back;

    public int maxIndex = 99;
    int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
      next.onClick.AddListener(Next);
      back.onClick.AddListener(Back);

    }

    void Next(){
        index++;
        if(index>maxIndex){
            index = 0;
        }
    }
    void Back(){
        index--;
        if(index<0){
            index++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //string[] values;
        string message = "";
        switch (drop.value){
            case 0:
                message = english.Values[index];
                break;
            case 1:
                message = french.Values[index];
                break;
            case 2:
                message = spanish.Values[index];
                break;
            case 3:
                message = german.Values[index];
                break;
            case 4:
                message = italian.Values[index];
                break;
        }
       
        textm.text =  message;
    }
}
