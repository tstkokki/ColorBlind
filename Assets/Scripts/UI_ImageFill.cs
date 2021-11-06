using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class UI_ImageFill : MonoBehaviour
{
    [SerializeField] PaintCollection collection;
    IntReactiveProperty reactiveInt;
    IntReactiveProperty whitePaintAmount;
    IntReactiveProperty redPaintAmount;
    IntReactiveProperty greenPaintAmount;
    IntReactiveProperty bluePaintAmount;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        reactiveInt = new IntReactiveProperty(collection.currentIndex);

        SetReactivePaint();
        reactiveInt.ObserveEveryValueChanged(x => collection.currentIndex)
            .TakeUntilDestroy(gameObject)
            .Subscribe(y => { ChangeColor(); });
    }

    private void ChangeColor()
    {
        FillImage(collection.currentIndex);
        // set fill color to current paint
        image.color = collection.paints[collection.currentIndex]._color;
    }

    private void SetReactivePaint()
    {
        whitePaintAmount = new IntReactiveProperty(collection.paints[0].Amount);
        redPaintAmount = new IntReactiveProperty(collection.paints[1].Amount);
        greenPaintAmount = new IntReactiveProperty(collection.paints[2].Amount);
        bluePaintAmount = new IntReactiveProperty(collection.paints[3].Amount);

        //reactive paint amounts
        whitePaintAmount.ObserveEveryValueChanged(x => collection.paints[0].Amount)
            .TakeUntilDestroy(gameObject)
            .Subscribe(y => FillImage(0));

        redPaintAmount.ObserveEveryValueChanged(x => collection.paints[1].Amount)
                .TakeUntilDestroy(gameObject)
                .Subscribe(y => FillImage(1));

        greenPaintAmount.ObserveEveryValueChanged(x => collection.paints[2].Amount)
                .TakeUntilDestroy(gameObject)
                .Subscribe(y => FillImage(2));

        bluePaintAmount.ObserveEveryValueChanged(x => collection.paints[3].Amount)
                .TakeUntilDestroy(gameObject)
                .Subscribe(y => FillImage(3));
    }

    private void FillImage(int i)
    {
        if (collection.currentIndex == i)
        {
            image.fillAmount = collection.paints[i].Amount * 1.0f / collection.paints[i].maxAmount;

        }
    }
}
