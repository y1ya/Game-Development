using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public GameObject settingPanels;

    public GameObject buttonForCategs;

    public List<Sprite> categoryPanels;

    public void ChangePanel(GameObject button)
    {
        string name = button.name;

        if (name.Equals("Back Button"))
        {
            DisableAllChildren(settingPanels);
            settingPanels.SetActive(false);
            buttonForCategs.SetActive(true);
            return;
        }

        buttonForCategs.SetActive(false);
        settingPanels.SetActive(true);

        if (name.Equals("Pantry Staple"))
        { 
            settingPanels.GetComponent<Image>().sprite = categoryPanels[0];
            EnableChildButton(0);
        }
        else if (name.Equals("Candies"))
        { 
            settingPanels.GetComponent<Image>().sprite = categoryPanels[1];
            EnableChildButton(1);
        }
        else if (name.Equals("Snacks"))
        { 
            settingPanels.GetComponent<Image>().sprite = categoryPanels[2];
            EnableChildButton(2);
        }
        else if (name.Equals("Drinks")) 
        { 
            settingPanels.GetComponent<Image>().sprite = categoryPanels[3];
            EnableChildButton(3);
        }
        else if (name.Equals("Instant Noodles"))
        { 
            settingPanels.GetComponent<Image>().sprite = categoryPanels[4];
            EnableChildButton(4);
        }

        Debug.Log($"[ShopScript] ChangePanel: Button is Clicked {name}");
    }

    private void EnableChildButton(int childIndex)
    {
        Transform childButton = settingPanels.transform.GetChild(childIndex);
        childButton.gameObject.SetActive(true);
    }

    private void DisableAllChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            if (!child.gameObject.name.Equals("Back Button"))
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
