using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultyLoad : ILoadOperation
{
    private List<string> urlStringList;
    private UIControl uIControl;

    public MultyLoad(List<string> urls, UIControl uI)
    {
        urlStringList = urls;
        uIControl = uI;
    }

    public void LoadOperation()
    {
        Debug.Log("MultyLoad");
    }
}
