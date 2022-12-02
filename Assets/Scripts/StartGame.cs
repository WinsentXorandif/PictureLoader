using System;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using static ImageUtilties;

public class StartGame : MonoBehaviour
{
    private const string ImageURL = "https://picsum.photos/200";

    private readonly List<string> ImageURLs = new();

    private Dictionary<LoadOperation, ILoadOperation> LoadOperationsDict = new();

    [SerializeField]
    private UIControl uiControl;



    private void InitURLlist() 
    {
        for (int i = 0; i < uiControl.cartPanel.carts.Length; i++)
        {
            ImageURLs.Add(ImageURL);
        }
    }

    private void InitOperationDict() 
    {
        LoadOperationsDict.Add(LoadOperation.oneByOne, new OnceLoad(ImageURL, uiControl));
        LoadOperationsDict.Add(LoadOperation.allAtOnce, new MultyLoad(ImageURL, uiControl));
        LoadOperationsDict.Add(LoadOperation.whenImageReady, new ReadyLoad(ImageURL, uiControl));
    }

    private void Awake()
    {
        InitURLlist();
        InitOperationDict();
    }

    private void OnEnable()
    {
        uiControl.OnLoadButton += OnLoadPicture;
        uiControl.OnCancelButton += OnCancel;
    }

    private void OnDisable()
    {
        uiControl.OnLoadButton -= OnLoadPicture;
        uiControl.OnCancelButton -= OnCancel;
    }

    private void OnLoadPicture(int opt)
    {
        LoadOperationsDict[(LoadOperation)opt].LoadOperation();
    }

    private void OnCancel()
    {
        Debug.Log("OnCancel");
    }

}
