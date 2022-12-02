using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using static ImageUtilties;

public class OnceLoad : ILoadOperation
{
    private string urlString;
    private UIControl uiControl;

    private CancellationTokenSource cts;

    public OnceLoad(string url, UIControl uI)
    {
        urlString = url;
        uiControl = uI;
    }
    public void ONCansel()
    {
        cts?.Cancel();
    }

    public async UniTask LoadOperation()
    {
        cts = new CancellationTokenSource();
        for (int i = 0; i < uiControl.cartPanel.carts.Length; i++)
        {
            await uiControl.cartPanel.carts[i].CloseCartShow(0.5f);
            uiControl.cartPanel.carts[i].SetNewImage(await DownloadPNGImage(urlString, "picture" + i.ToString()));
            await uiControl.cartPanel.carts[i].OpenCartShow();
        }
        uiControl.UnLockButtons();
    }

    public async UniTask<Sprite> DownloadPNGImage(string url, string name)
    {
        Texture2D img = await ImageDownloader.DownloadImage(url, name, FileFormat.PNG, cts.Token);
        return Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));
    }


}
