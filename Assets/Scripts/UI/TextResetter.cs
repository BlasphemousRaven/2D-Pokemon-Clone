using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextResetter : MonoBehaviour
{
    void OnDisable(){
        GetComponent<TMP_Text>().text = "";
    }
}

