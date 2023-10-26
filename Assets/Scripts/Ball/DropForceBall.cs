using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class DropForceBall : DropObject, IDropHandler
{
    private Image background;
    private RectTransform rectTransform;
    private Ball ballData;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        ballData = _interactableObject.GetComponent<Ball>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        background = GetComponentInChildren<Image>();

        string testText = eventData.pointerDrag.GetComponentInChildren<TextMeshProUGUI>().GetParsedText();

        // Parse String to Vector2
        testText = testText.Substring(1, testText.Length - 2);
        string[] forces = testText.Split(',');

        float valueX, valueY;
        float.TryParse(forces[0], out valueX);
        float.TryParse(forces[1], out valueY);

        Vector2 force = new Vector2(valueX, valueY);

		ballData.gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }

	private void Update() {
		rectTransform.position = ballData.gameObject.transform.position;
	}
}

