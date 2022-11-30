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


    public void SetNewImage(Sprite newSprite)
    {
        loadImage.sprite = newSprite;
    }


    void Start()
    {
        backImage.enabled = false;
        //SetNewImage(backImage.sprite);
    }

    void Update()
    {

    }
}
