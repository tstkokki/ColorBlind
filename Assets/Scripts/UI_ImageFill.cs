using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class UI_ImageFill : MonoBehaviour
{
    [SerializeField] PaintCollection collection;
    IntReactiveProperty reactiveInt;
    IntReactiveProperty paintAmount;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        
        image = GetComponent<Image>();
        reactiveInt = new IntReactiveProperty(collection.currentIndex);
        reactiveInt.ObserveEveryValueChanged(x => collection.currentIndex)
            .TakeUntilDestroy(this)
            .Subscribe(y =>
            {
                Fill();
            });
    }

    private void Fill()
    {
        image.fillAmount =
                        collection.paints[collection.currentIndex].Amount * 1.0f / collection.paints[collection.currentIndex].maxAmount;
        image.color = collection.paints[collection.currentIndex]._color;
    }
}
