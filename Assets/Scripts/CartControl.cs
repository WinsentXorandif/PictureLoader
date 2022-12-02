using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;



public class CartControl : MonoBehaviour
{

    [SerializeField]
    private Image forwardImage;
    [SerializeField]
    private Image loadImage;
    [SerializeField]
    private Image backImage;

    [SerializeField]
    private Sprite forwardSprite;
    [SerializeField]
    private Sprite backSprite;

    private Sprite tmpSprite;

    private void Start()
    {
        forwardImage.sprite = forwardSprite;
        transform.DOScale(1.05f, 1.5f).SetEase(Ease.InOutBack).SetLoops(-1, LoopType.Yoyo);
    }

    public void SetNewImage(Sprite newSprite)
    {
        tmpSprite = newSprite;
    }


    private async void OpenCartShow() 
    {
        await transform.DOLocalRotate(new Vector3(0, 90f, 0), 2f, RotateMode.Fast).SetEase(Ease.Linear).AsyncWaitForCompletion();
        forwardImage.sprite = forwardSprite;
        loadImage.sprite = tmpSprite;
        await transform.DOLocalRotate(new Vector3(0, 0f, 0), 2f, RotateMode.Fast).SetEase(Ease.Linear).AsyncWaitForCompletion();
        //uiControl.UnLockButtons();
    }

    private async void CloseCartShow()
    {
        await transform.DOLocalRotate(new Vector3(0, 90f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.Linear).AsyncWaitForCompletion();
        forwardImage.sprite = backSprite;
        transform.DOLocalRotate(new Vector3(0, 0f, 0), 1f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(() => OpenCartShow());
    }

}
