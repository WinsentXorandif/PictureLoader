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
        LoadOperationsDict.Add(LoadOperation.allAtOnce, new MultyLoad(ImageURLs, uiControl));
        LoadOperationsDict.Add(LoadOperation.whenImageReady, new MultyLoad(ImageURLs, uiControl));
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
        //Debug.Log($"OnLoadPicture =>> opt = {opt}");
        //_ = DownloadImagesAsync();

        LoadOperationsDict[(LoadOperation)opt].LoadOperation();

    }

    private void OnCancel()
    {
        Debug.Log("OnCancel");
    }

    //=================================================
    /*
    private async void Start()
    {
        var textures =
            await UniTask.WhenAll(_imageUrls.Select(DownloadImageAsync));

        for (var i = 0; i < textures.Length; i++)
        {
            _images[i].texture = textures[i];
        }
    }


    public async UniTaskVoid StartOperation(CancellationToken token = default)
    {
        _image.texture = await DownloadImageAsync(_imageUrl, token);
    }
    //----------------------------------------------------
    private async UniTask<Texture2D> DownloadImageAsync(string imageUrl,
       CancellationToken token)
    {
        var request = UnityWebRequestTexture.GetTexture(imageUrl);

        try
        {
            await request.SendWebRequest().WithCancellation(token);

            return request.result == UnityWebRequest.Result.Success
                ? DownloadHandlerTexture.GetContent(request)
                : null;
        }
        finally
        {
            request.Dispose();
        }
    }
    */
    //=================================================
    /*
    public async UniTask DownloadImagesAsync()
    {
        //image1.texture = await DownloadJPGImage(firstImageURL, "first");
        //image2.texture = await DownloadJPGImage(secondImageURL, "second");
        //image3.sprite = await DownloadPNGImage(spriteImageURL, "unity");

        for (int i = 0; i < uiControl.carts.Length; i++)
        {
            uiControl.carts[i].SetNewImage(await DownloadPNGImage(ImageURL, "picture" + i.ToString()));
        }
        //        Sprite sp = await DownloadPNGImage(ImageURL, "unity");
        //uiControl.carts[0].SetNewImage(sp);

    }

    /*
    public async UniTask<Texture2D> DownloadJPGImage(string url, string name)
    {
        Texture2D img = await ImageDownloader.DownloadImage(url, name, FileFormat.JPG);

        return img;
    }
    */
    /*
    public async UniTask<Sprite> DownloadPNGImage(string url, string name)
    {
        Texture2D img = await ImageDownloader.DownloadImage(url, name, FileFormat.PNG);
        return Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));
    }
    */
}
