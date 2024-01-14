using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuController : MonoBehaviour
{
    public GameObject AddHealth;
    public GameObject AddDamage;
    public GameObject AddSpeed;
    public GameObject squirrel;
    public GameObject boss1;
    public GameObject successText;
    public GameObject failedText;
    private float timeToAppear = 2f;
    private float currTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        squirrel = GameObject.Find("SCharacter_Squirrel");
        boss1 = GameObject.Find("Boss1");
        failedText.SetActive(false);
        successText.SetActive(false);

        Debug.Log(failedText);
    }

    // Update is called once per frame
    void Update()
    {
        //if (successText.activeSelf == true)
        //{
        //    if (failedText.activeSelf == true)
        //    {
        //        successText.SetActive(false);
        //        currTime = 0f;
        //    }
        //}
        //if (failedText.activeSelf == true)
        //{
        //    currTime += Time.deltaTime;
        //    Debug.Log(Time.time);
        //}
        //if (currTime > timeToAppear)
        //{
        //    currTime = 0f;
        //    successText.SetActive(false);
        //    failedText.SetActive(false);
        //}
    }

    public void BuySpeed()
    {
        int currCount = squirrel.GetComponent<PlayerController>().GetCount();
        if (currCount >= 5)
        {
            squirrel.GetComponent<PlayerController>().speed += 2;
            squirrel.GetComponent<PlayerController>().SetCount(currCount - 5);
            if (successText.activeSelf == false)
            {
                failedText.SetActive(false);
                successText.SetActive(true);
            }
        }
        else
        {
            successText.SetActive(false);
            failedText.SetActive(true);
        }
    }

    public void BuyHealth()
    {
        int currCount = squirrel.GetComponent<PlayerController>().GetCount();
        if (squirrel.GetComponent<PlayerController>().GetCount() >= 5)
        {
            squirrel.GetComponent<PlayerController>().IncreaseCurrHealth(10);
            squirrel.GetComponent<PlayerController>().SetCount(currCount - 5);
            if (successText.activeSelf == false)
            {
                failedText.SetActive(false);
                successText.SetActive(true);

            }
        }
        else
        {
            successText.SetActive(false);
            failedText.SetActive(true);
        }
    }

    public void BuyDamage()
    {
        int currCount = squirrel.GetComponent<PlayerController>().GetCount();
        if (squirrel.GetComponent<PlayerController>().GetCount() >= 5)
        {
            boss1.GetComponent<EnemyFollow>().increaseEnemyDamage(2);
            squirrel.GetComponent<PlayerController>().SetCount(currCount - 5);
            if (successText.activeSelf == false)
            {
                failedText.SetActive(false);
                successText.SetActive(true);

            }
        }
        else
        {
            successText.SetActive(false);
            failedText.SetActive(true);
            //boss1.GetComponent<EnemyFollow>().increaseEnemyDamage(5);
        }
    }
}
