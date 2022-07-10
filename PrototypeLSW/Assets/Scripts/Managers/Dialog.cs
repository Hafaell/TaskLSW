using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Managers
{
    public class Dialog : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textDisplay;
        [SerializeField] private float typingSpeed;
        [SerializeField, TextArea] private string[] sentences;
        [SerializeField] private UnityEvent finishEvent;
        private int index;

        public void StartDialog()
        {
            StopAllCoroutines();
            index = 0;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        public void NextSentences()
        {
            StopAllCoroutines();

            if (index < sentences.Length - 1)
            {
                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else
            {
                textDisplay.text = "";
                finishEvent?.Invoke();
            }
        }

        IEnumerator Type()
        {
            foreach (var letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}
