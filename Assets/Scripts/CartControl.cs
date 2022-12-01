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


    public void SetNewImage(Sprite newSprite)
    {
        loadImage.sprite = newSprite;
    }


    private void Start()
    {
        //_ = ShowEffects();
        //ShowEffects();


        transform.DOScale(1.2f, 1.0f).SetLoops(-1, LoopType.Yoyo);
        StartRotate();

    }

    private void StartRotate() 
    {
        forwardImage.sprite = forwardSprite;
        //transform.DOLocalRotate(new Vector3(0, 90f, 0), 2f, RotateMode.Fast).SetEase(Ease.Linear, 0.1f).OnComplete(() => FinishRotate());
        transform.DOLocalRotate(new Vector3(0, 90f, 0), 2f, RotateMode.Fast).SetEase(Ease.InOutSine).OnComplete(() => FinishRotate());
    }

    private void FinishRotate() 
    {
        forwardImage.sprite = backSprite;
        transform.DOLocalRotate(new Vector3(0, -90f, 0), 2f, RotateMode.Fast).SetEase(Ease.Linear, 0.1f).OnComplete(() => StartRotate());


    }

    /*
    private async UniTask ShowEffects()
    {
        await transform.DOLocalRotate(new Vector3(0, 90f, 0), 4f, RotateMode.LocalAxisAdd);


    }
    */

    //private async void ShowEffects()
    private void ShowEffects()
    {
        Sprite sprite = backImage.sprite;

        //Tweener twiner= new Tweener();

        //backImage.enabled = false;
        //SetNewImage(backImage.sprite);

        //        transform.DOScale(0.95f, 0.5f).SetEase(Ease.Linear, 2.0f).SetLoops(-1);

        //transform.DOLocalRotate(new Vector3(0, 180f, 0), 4f, RotateMode.LocalAxisAdd).ChangeValues(forwardImage.sprite = backSprite, forwardImage.sprite = forwardSprite, 2f);//ChangeEndValue(forwardImage.sprite = backImage.sprite);

        //transform.DOScale(1.5f, 0.5f).SetEase(Ease.Linear, 0.1f).SetLoops(-1);


        //    myTransform.DOScale(new Vector3(0.75f, 0.5f, 1f), duration)
        //        .SetEase(Ease.InOutSine)
        //        .SetLoops(-1, LoopType.Yoyo);

        transform.DOScale(1.2f, 1.0f).SetLoops(-1, LoopType.Yoyo);

        /*
        mySequence.Append(transform.DOScale(ActualEndScale, GrowthTime))
                .Join(transform.DOLocalRotate(new Vector3(0, degrees, 0), GrowthTime, RotateMode.FastBeyond360).SetEase(Ease.OutElastic))
                .OnComplete(() => After());
        */


        // Tweener tweener = transform.DOLocalRotate(new Vector3(0, 90f, 0), 2f, RotateMode.Fast).SetEase(Ease.Linear, 0.1f);

        //  var duration = 1f;
        //  transform.DOScale(1.2f, duration).OnUpdate(() => duration = 0).SetLoops(-1, LoopType.Yoyo);

        // transform.DOScale(1.2f, 1).SetLoops(-1, LoopType.Yoyo);


        //tweener.AsyncWaitForPosition
        /*
    while (sprite != null)
    {

        //transform.DOScale(1.2f, 0.5f).SetEase(Ease.Linear, 2.0f).SetLoops(1);

        await transform.DOLocalRotate(new Vector3(0, 90f, 0), 2f, RotateMode.Fast).SetEase(Ease.Linear, 0.1f).AsyncWaitForCompletion();//SetLoops(1).AsyncWaitForCompletion();
                                                                                                                                       //Debug.Log($"transform.rotation = {transform.rotation.y}");
        forwardImage.sprite = backSprite;

        await transform.DOLocalRotate(new Vector3(0, 180f, 0), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear, 0.1f).AsyncWaitForCompletion();
        forwardImage.sprite = forwardSprite;

        //transform.DOScale(0.8f, 0.5f).SetEase(Ease.Linear, 2.0f).ChangeEndValue

    }
        */
        //await transform.DOLocalRotate(new Vector3(0, 90f, 0), 4f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear, 0.5f);

        // await transform.DOLocalRotate(new Vector3(0, -90f, 0), 4f, RotateMode.Fast).SetEase(Ease.InElastic, 1f).AsyncWaitForCompletion();//SetLoops(1).AsyncWaitForCompletion();
        // forwardImage.sprite = forwardSprite;


    }

    void Update()
    {

    }
}
