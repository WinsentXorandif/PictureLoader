using Cysharp.Threading.Tasks;
using UnityEngine;
using static ImageUtilties;

public class StartGame : MonoBehaviour
{
    private const string ImageURL = "https://picsum.photos/200";

    [SerializeField]
    private UIControl uiControl;



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
        Debug.Log($"OnLoadPicture =>> opt = {opt}");
        _ = DownloadImagesAsync();

    }

    private void OnCancel()
    {
        Debug.Log("OnCancel");
    }



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

    public async UniTask<Sprite> DownloadPNGImage(string url, string name)
    {
        Texture2D img = await ImageDownloader.DownloadImage(url, name, FileFormat.PNG);
        return Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));
    }



    void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    void Update()
    {

    }
}
