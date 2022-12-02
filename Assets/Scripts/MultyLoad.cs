using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using static ImageUtilties;

public class MultyLoad : ILoadOperation
{
    private string urlString;
    private UIControl uiControl;

    private List<Sprite> downloadImageSprite = new();
    private CancellationTokenSource cts;
    private int ind;

    public MultyLoad(string url, UIControl uI)
    {
        ind = 0;
        urlString = url;
        uiControl = uI;
    }
    public void ONCansel()
    {
        cts?.Cancel();
    }
    public async UniTask LoadOperation()
    {
        ind = 0;
        cts = new CancellationTokenSource();
        downloadImageSprite.Clear();

        await UniTask.WhenAll(uiControl.cartPanel.carts.Select(async cart =>
        {
            downloadImageSprite.Add(await DownloadPNGImage(urlString));
        }));

        for (int i = 0; i < uiControl.cartPanel.carts.Length; i++)
        {
            uiControl.cartPanel.carts[i].SetNewImage(downloadImageSprite[i]);
            uiControl.cartPanel.carts[i].FinishAllRotate(0.5f);
        }
    }
    public async UniTask<Sprite> DownloadPNGImage(string url)
    {
        ind++;
        string name = "Picture" + ind.ToString();
        Texture2D img = await ImageDownloader.DownloadImage(url, name, FileFormat.PNG, cts.Token);
        return Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));
    }

}
