using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    [TextArea(3, 10)]
    public string[] lines;
    public float textSpeed;
    public bool passIn;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComp.text = string.Empty;
        StartDialogue();
        passIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (textComp.text == lines[index]) {
                NextLine();
            } else {
                StopAllCoroutines();
                textComp.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() 
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    void NextLine() 
    {
        if (index < lines.Length - 1) {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            gameObject.SetActive(false);
            passIn = false;
        }
    }
}
