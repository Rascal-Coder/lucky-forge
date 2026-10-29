using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HyperlinksTMP : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private TextMeshProUGUI textMessage;

	private void Start()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
