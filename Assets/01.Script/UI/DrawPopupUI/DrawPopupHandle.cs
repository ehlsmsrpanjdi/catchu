using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawPopupHandle : UIBase, IPointerDownHandler, IPointerUpHandler
{
    bool isClick = false;

    float startYPos;

    [SerializeField] Image handleImg;

    private void Reset()
    {
        handleImg = GetComponent<Image>();
    }

    private void Awake()
    {
        startYPos = handleImg.rectTransform.position.y;
    }

    private void Start()
    {
        UIManager.Instance.Add(this);
    }

    private void Update()
    {
        if (true == isClick)
        {
            float mouseY = Input.mousePosition.y;
            if (mouseY < startYPos)
            {
                return;
            }
            handleImg.transform.position = new Vector2(handleImg.transform.position.x, mouseY);


            float amount = (220 + startYPos - handleImg.transform.position.y) / 220;

            if (amount < 0.4f)
            {
                isClick = false;
                UIManager.Instance.GetUI<DrawPopupUI>().EndFrontImg();
            }
            else
            {
                UIManager.Instance.GetUI<DrawPopupUI>().FrontImageFilled(amount);
            }
        }
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClick = false;
    }
}
