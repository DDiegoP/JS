using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBox;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private GameObject arrow;

    private string textToShow;
    private bool showText;
    private Coroutine typingCoroutine;
    private bool arrowControl;
    private float arrowTimer;

    public void dialogue(string text)
    {
        textToShow = text;
        showText = true;

        dialogueBox.SetActive(true);
        dialogueText.enabled = true;

        // por si ya hab�a alguna activa se para
        if (typingCoroutine != null) StopCoroutine(typingCoroutine); 

        typingCoroutine = StartCoroutine(TypeText(textToShow));
    }

    // Corrutina para escribir el texto caracter a caracter
    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);// velocidad de aparici�n de los caracteres
        }
        showText = false;
        arrow.SetActive(true);
        arrowControl = true;
        arrowTimer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        dialogueText.enabled = false;
        showText = false;
        arrow.SetActive(false);
        arrowControl = false;
        arrowTimer = 0;

        // Activar el auto size
        dialogueText.enableAutoSizing = true;

        // Definir el tama�o m�nimo y m�ximo de la fuente
        dialogueText.fontSizeMin = 10;
        dialogueText.fontSizeMax = 36;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            if (!showText)
            {
                dialogueText.enabled = false;
                dialogueBox.SetActive(false);
                arrow.SetActive(false);
                arrowControl = false;
            }
            else if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                typingCoroutine = null;
                dialogueText.text = textToShow; // texto completo
                showText = false;
                arrow.SetActive(true);
                arrowControl = true;
                arrowTimer = 0;
            }
        }

        arrowTimer += Time.deltaTime;
        if (arrowControl && arrowTimer >= 0.4)
        {
            arrow.SetActive(!arrow.gameObject.activeSelf);
            arrowTimer = 0;
        }
    }
}