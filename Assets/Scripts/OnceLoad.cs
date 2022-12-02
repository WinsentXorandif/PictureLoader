using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using static ImageUtilties;
using System;

public class OnceLoad : ILoadOperation
{
    private string urlString;
    private UIControl uiControl;

    private CancellationTokenSource cts = new CancellationTokenSource();


    public OnceLoad(string url, UIControl uI) 
    {
        urlString = url;
        uiControl = uI;

        uiControl.OnCancelButton += ONCansel;
    }

    private void ONCansel() 
    {
        Debug.Log("ONCansel()!!! ");
        cts.Cancel();
    }

    public void LoadOperation()
    {
        Debug.Log("OnceLoad");
        _ = DownloadImagesAsync();
    }

    public async UniTask DownloadImagesAsync()
    {
        //for (int i = 0; i < uiControl.carts.Length; i++)
        {
        //    uiControl.carts[i].SetNewImage(await DownloadPNGImage(urlString, "picture" + i.ToString()) );
        }
    }

    public async UniTask<Sprite> DownloadPNGImage(string url, string name)
    {
        Texture2D img = await ImageDownloader.DownloadImage(url, name, FileFormat.PNG, cts.Token);
        return Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));
    }


}
