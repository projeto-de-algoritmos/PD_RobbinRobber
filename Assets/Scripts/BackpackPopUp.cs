using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackpackPopUp : MonoBehaviour
{
    [SerializeField] 
    private GameObject _popUpCanvasObject;
    [SerializeField]
    private RectTransform _popUpObject;
    [SerializeField]
    private TextMeshProUGUI _infoText;
    [SerializeField]
    private Vector3 _offset;
    [SerializeField]
    private float _padding;
    private Canvas popUpCanvas;

    public Player player;


    private void Awake () 
    {
        popUpCanvas = _popUpCanvasObject.GetComponent<Canvas>();

    }

/*
    private void Update()
    {
        FollowCursor();
    }

    private void FollowCursor()
    {
        if (!_popUpCanvasObject.activeSelf) { return; }

        Vector3 newPos = Input.mousePosition + _offset;
        newPos.z = 0f;
        float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + _popUpObject.rect.width * popUpCanvas.scaleFactor / 2) - _padding;
        if (rightEdgeToScreenEdgeDistance < 0)
        {
            newPos.x += rightEdgeToScreenEdgeDistance;
        }
        float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - _popUpObject.rect.width * popUpCanvas.scaleFactor / 2) + _padding;
        if (leftEdgeToScreenEdgeDistance > 0)
        {
            newPos.x += leftEdgeToScreenEdgeDistance;
        }
        float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + _popUpObject.rect.height * popUpCanvas.scaleFactor) - _padding;
        if (topEdgeToScreenEdgeDistance < 0)
        {
            newPos.y += topEdgeToScreenEdgeDistance;
        }
        _popUpObject.transform.position = newPos;
    }
*/
    public void DisplayInfo(int storage, int maxCapacity, int maxValue)
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("Capacidade máxima: ").Append(maxCapacity).AppendLine();
        builder.Append("Capacidade preenchida: ").Append(storage).AppendLine();
        builder.Append("Valor máximo: ").Append(maxValue).AppendLine();


        _infoText.text = builder.ToString();

        _popUpCanvasObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(_popUpObject);
    }

    public void HideInfo()
    {
        _popUpCanvasObject.SetActive(false);
    }
}
