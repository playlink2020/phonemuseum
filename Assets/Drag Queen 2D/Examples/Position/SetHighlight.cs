using UnityEngine;

public class SetHighlight : MonoBehaviour
{
	public GameObject Highlight;


	void OnHoverEnter()
	{
		Highlight.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
		Highlight.SetActive(true);
	}


	void OnHoverExit()
	{
		Highlight.SetActive(false);
	}


	void OnDrop(object card)
	{
		Highlight.SetActive(false);
		((GameObject)card).transform.position = new Vector3(transform.position.x, transform.position.y, -1);
	}
}
