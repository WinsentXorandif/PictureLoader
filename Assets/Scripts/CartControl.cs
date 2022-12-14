using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

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
    private CartPanelControl panelControl;


    private void Awake()
    {
        panelControl = GetComponentInParent<CartPanelControl>();
    }

    private void Start()
    {
        forwardImage.sprite = forwardSprite;
        transform.DOScale(1.05f, 1.5f).SetEase(Ease.InOutBack).SetLoops(-1, LoopType.Yoyo);
    }

    public void SetNewImage(Sprite newSprite)
    {
        tmpSprite = newSprite;
    }

    public async UniTask OpenCartShow()
    {
        await transform.DOLocalRotate(new Vector3(0, 90f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.Linear).AsyncWaitForCompletion();
        forwardImage.sprite = forwardSprite;
        loadImage.sprite = tmpSprite;
        await transform.DOLocalRotate(new Vector3(0, 0f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.Linear).AsyncWaitForCompletion();
    }

    public async UniTask CloseCartShow(float dd)
    {
        await transform.DOLocalRotate(new Vector3(0, 90f, 0), dd, RotateMode.Fast).SetEase(Ease.Linear).AsyncWaitForCompletion();
        forwardImage.sprite = backSprite;
        await transform.DOLocalRotate(new Vector3(0, 0f, 0), dd, RotateMode.Fast).SetEase(Ease.Linear).AsyncWaitForCompletion();
    }
    private async void StartAllRotate()
    {
        await transform.DOLocalRotate(new Vector3(0, 90f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.InOutSine).AsyncWaitForCompletion();
        forwardImage.sprite = forwardSprite;
        loadImage.sprite = tmpSprite;
        await transform.DOLocalRotate(new Vector3(0, 0f, 0), 2f, RotateMode.Fast).SetEase(Ease.InSine).AsyncWaitForCompletion();
        panelControl.UnLockUIButtons();

    }

    public async void FinishAllRotate(float dd)
    {
        await transform.DOLocalRotate(new Vector3(0, 90f, 0), dd, RotateMode.Fast).SetEase(Ease.InOutSine).AsyncWaitForCompletion();
        forwardImage.sprite = backSprite;
        transform.DOLocalRotate(new Vector3(0, 0, 0), 2f, RotateMode.Fast).SetEase(Ease.InSine).OnComplete(() => StartAllRotate());
    }

    public async UniTask FinishAllRotateReady(float dd)
    {
        await transform.DOLocalRotate(new Vector3(0, 90f, 0), dd, RotateMode.Fast).SetEase(Ease.InOutCirc).AsyncWaitForCompletion();
        forwardImage.sprite = backSprite;
        await transform.DOLocalRotate(new Vector3(0, 0, 0), dd, RotateMode.Fast).SetEase(Ease.InCirc).AsyncWaitForCompletion();
    }


}
