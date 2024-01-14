using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GameObject.Find("InGameMenu").GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("Canvas Group Component not found");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Escape)) {
        //    if (canvasGroup.interactable) {
        //        canvasGroup.interactable = false;
        //        canvasGroup.blocksRaycasts = false;
        //        canvasGroup.alpha = 0;
        //        Time.timeScale = 1f;
        //    } else {
        //        canvasGroup.interactable = true;
        //        canvasGroup.blocksRaycasts = true;
        //        canvasGroup.alpha = 1f;
        //        Time.timeScale = 0f;
        //    }
        //}
    }

    public void PauseGame()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
        Time.timeScale = 1f;
    }
}
