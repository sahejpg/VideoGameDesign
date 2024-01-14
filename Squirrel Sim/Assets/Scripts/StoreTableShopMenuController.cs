using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StoreTableShopMenuController : MonoBehaviour
{
    public CanvasGroup shopMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            shopMenu.interactable = true;
            shopMenu.blocksRaycasts = true;
            shopMenu.alpha = 1f;
            Time.timeScale = 0f;
        }
    }
}
