using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextResetter : MonoBehaviour
{
    void OnDisable(){
        ResetText();
    }

    public void ResetText(){
        GetComponent<TMP_Text>().text = "";
    }
}

