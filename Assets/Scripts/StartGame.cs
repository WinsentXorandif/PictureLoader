using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private const string ImageURL = "https://picsum.photos/200";

    private Dictionary<LoadOperation, ILoadOperation> LoadOperationsDict = new();

    private LoadOperation tmpOper;

    [SerializeField]
    private UIControl uiControl;

    private void InitOperationDict()
    {
        LoadOperationsDict.Add(LoadOperation.none, new NoneLoad());
        LoadOperationsDict.Add(LoadOperation.oneByOne, new OnceLoad(ImageURL, uiControl));
        LoadOperationsDict.Add(LoadOperation.allAtOnce, new MultyLoad(ImageURL, uiControl));
        LoadOperationsDict.Add(LoadOperation.whenImageReady, new ReadyLoad(ImageURL, uiControl));
    }

    private void Awake()
    {
        tmpOper = LoadOperation.none;
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
        tmpOper = (LoadOperation)opt;
        LoadOperationsDict[tmpOper].LoadOperation();
    }

    private void OnCancel()
    {
        LoadOperationsDict[tmpOper].ONCansel();
    }
}
