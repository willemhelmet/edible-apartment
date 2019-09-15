using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private int _activeChild;

    private void Start()
    {
        _activeChild = 0;
    }

    public void NextItem()
    {
        this.gameObject.transform.GetChild(_activeChild).gameObject.SetActive(false);
        _activeChild++;
        this.gameObject.transform.GetChild(_activeChild).gameObject.SetActive(true);
    }

    public bool CanGoToNextItem()
    {
        if (this.gameObject.transform.childCount > _activeChild)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
