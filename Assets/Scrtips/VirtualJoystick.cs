using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Thief Kobold's Virtual Joystick for mobile Envi.
/// </summary>
namespace TK_Virtual_Joystick
{
    public class VirtualJoystick : MonoBehaviour , IPointerDownHandler, IDragHandler,IPointerUpHandler
    {
        [SerializeField] private Image bgImage;
        [SerializeField] private Image joyStickImage;
        [SerializeField] private float offset;

        public Vector2 InputDir { get; set; }
        
        private void Start()
        {
            InputDir = Vector2.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos = Vector2.zero;
            float bgImageSizeX = bgImage.rectTransform.sizeDelta.x;
            float bgImageSizeY = bgImage.rectTransform.sizeDelta.y;


            if (RectTransformUtility.ScreenPointToLocalPointInRectangle
                            (
                                bgImage.rectTransform,
                                eventData.position,
                                eventData.pressEventCamera,
                                out pos
                            ))
            {
                pos.x = pos.x / bgImageSizeX;
                pos.y = pos.y / bgImageSizeY;

                InputDir = new Vector2(pos.x, pos.y);

                InputDir = InputDir.magnitude > 1 ? InputDir.normalized : InputDir;


                joyStickImage.rectTransform.anchoredPosition =
                    new Vector2
                    (
                        InputDir.x * (bgImageSizeX/offset),
                        InputDir.y * (bgImageSizeY/offset)
                    );
                
            }
        }       
        public void OnPointerUp(PointerEventData eventData)
        {
            InputDir = Vector2.zero;
            joyStickImage.rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
