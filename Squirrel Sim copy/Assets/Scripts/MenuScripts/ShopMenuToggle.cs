using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ShopMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public GameObject success;
    public GameObject failed;

    private void Awake()
    {
        canvasGroup = GameObject.Find("ShopMenu").GetComponent<CanvasGroup>();

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
    //void Update()
    //{
    //}

    public void OpenShopMenu()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Time.timeScale = 0f;
    }

    public void ExitShopMenu()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
        Time.timeScale = 1f;
        success.SetActive(false);
        failed.SetActive(false);
    }
}
