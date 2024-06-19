using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.UI{
    public class UITextHandler: MonoBehaviour
    {
        [SerializeField] TMP_Text text;
        [SerializeField] float textSpeed = 1f;

        
        private void Start() => textSpeed /= 50f;

        //Text erscheint auf der UI 
        public IEnumerator Type(string words){
            string temp = "";
            text.text = "";

            for(int i = 0; i<words.Length;i++){
                temp += words[i];
                text.text = temp;
                yield return new WaitForSeconds(textSpeed);
            }
        }


    }
}
