using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static ImageUtilties;

public class ReadyLoad : ILoadOperation
{
    private string urlString;
    private UIControl uiControl;

    private CancellationTokenSource cts = new CancellationTokenSource();
    private int ind;

    public ReadyLoad(string url, UIControl uI)
    {
        ind = 0;
        urlString = url;
        uiControl = uI;

        uiControl.OnCancelButton += ONCansel;

    }

    private void ONCansel()
    {
        cts.Cancel();
    }


    public async UniTask LoadOperation()
    {
        ind = 0;

        foreach (var cc in uiControl.cartPanel.carts) 
        {
            await cc.FinishAllRotateReady(0.6f);
        }

        await UniTask.WhenAll(uiControl.cartPanel.carts.Select(async cart =>
        {
            cart.SetNewImage(await DownloadPNGImage(urlString));
            await cart.OpenCartShow();
        }));

        uiControl.UnLockButtons();
    }

    public async UniTask<Sprite> DownloadPNGImage(string url)
    {
        ind++;
        string name = "Picture" + ind.ToString();
        Texture2D img = await ImageDownloader.DownloadImage(url, name, FileFormat.PNG, cts.Token);
        return Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));
    }

}
