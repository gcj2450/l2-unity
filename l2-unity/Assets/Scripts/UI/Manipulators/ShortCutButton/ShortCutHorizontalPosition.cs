using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class ShortCutHorizontalPosition : MonoBehaviour
{

    private ShortCutPanel shortCutPanel;
    private VisualElement rootGroupBox;
    private int sizeCell;

    public ShortCutHorizontalPosition(ShortCutPanel shortCutPanel, VisualElement rootGroupBox, int sizeCell)
    {
        this.shortCutPanel = shortCutPanel;
        this.rootGroupBox = rootGroupBox;
        this.sizeCell = sizeCell;

    }

    public void Start()
    {
        if (shortCutPanel.IsVertical())
        {
            ChangePositionHorizontalRootGroupBox();
            RotateHorizontalSlider();
            RotateCellHorizontal();
            test();
            //shortCutPanel.SetPositionVerical(false);
        }
        else
        {
            ChangePositionVerticalRootGroupBox();
            RotateVertiacalSlider();
            RotateCellVertical();
            //shortCutPanel.SetPositionVerical(true);
        }

    }

    private void test()
    {
        var buttonSliderHorizontal = rootGroupBox.Q<VisualElement>(null, "slide-hor-arrow");
        ClickSliderShortCutManipulator slider_horizontal = new ClickSliderShortCutManipulator(ShortCutPanelMinimal.Instance, null);
        buttonSliderHorizontal.AddManipulator(slider_horizontal);
    }

    private void ChangePositionHorizontalRootGroupBox()
    {
      rootGroupBox.transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    private void ChangePositionVerticalRootGroupBox()
    {
        rootGroupBox.transform.rotation = Quaternion.Euler(0, 0, 0);
    }




    public void RotateHorizontalSlider()
    {
        var buttonSliderHorizontal = rootGroupBox.Q<VisualElement>(null, "slide-hor");
        var indexImage = rootGroupBox.Q<VisualElement>(null, "ImageIndex");

        if(buttonSliderHorizontal != null)
        {
            buttonSliderHorizontal.RemoveFromClassList("slide-hor");
            buttonSliderHorizontal.AddToClassList("slide-hor-arrow");
        }
        

        if(indexImage != null) indexImage.transform.rotation = Quaternion.Euler(0, 0, 90);


        var buttonSlider = rootGroupBox.Q<VisualElement>(null, "button-slider");
        if(buttonSlider != null)
        {
            buttonSlider.RemoveFromClassList("button-slider");
            buttonSlider.AddToClassList("button-slider-empty");
        }

    }

    public void RotateVertiacalSlider()
    {
        
        var buttonSliderHorizontal = rootGroupBox.Q<VisualElement>(null, "slide-hor-arrow");

        if (buttonSliderHorizontal != null)
        {
            buttonSliderHorizontal.RemoveFromClassList("slide-hor-arrow");
            buttonSliderHorizontal.AddToClassList("slide-hor");
        }

        var indexImage = rootGroupBox.Q<VisualElement>(null, "ImageIndex");
        if (indexImage != null) indexImage.transform.rotation = Quaternion.Euler(0, 0, 0);

        var buttonSlider = rootGroupBox.Q<VisualElement>(null, "button-slider-empty");

        if(buttonSlider != null)
        {
            buttonSlider.RemoveFromClassList("button-slider-empty");
            buttonSlider.AddToClassList("button-slider");
        }
       
    }

    private void RotateCellHorizontal()
    {
        for (int cell = 0; cell <= sizeCell; cell++)
        {
            var row = rootGroupBox.Q(className: "row" + cell);
            row.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    private void RotateCellVertical()
    {
        for (int cell = 0; cell <= sizeCell; cell++)
        {
            var row = rootGroupBox.Q(className: "row" + cell);
            row.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
