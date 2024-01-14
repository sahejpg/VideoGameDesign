using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenuScript : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private CanvasGroup pauseGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
        Time.timeScale = 1f;
    }

    private void Awake()
    {
        canvasGroup = GameObject.Find("ControlsMenu").GetComponent<CanvasGroup>();
        pauseGroup = GameObject.Find("InGameMenu").GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("Canvas Group Component not found");
        }
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    public void showControls()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        pauseGroup.interactable = false;
        pauseGroup.blocksRaycasts = false;
        pauseGroup.alpha = 0;
        Time.timeScale = 0f;
    }

    public void hideControls()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
        Time.timeScale = 1f;
    }
}
