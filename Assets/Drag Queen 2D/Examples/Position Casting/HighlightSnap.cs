using UnityEngine;

public class HighlightSnap : MonoBehaviour
{
	public GameObject Highlight;


	void OnHoverEnter()
	{
		Highlight.SetActive(true);
	}


	void OnHoverExit()
	{
		Highlight.SetActive(false);
	}


	void OnDrop(object cardObject)
	{
		Highlight.SetActive(false);
		var card = (GameObject)cardObject;
		var differenceX = transform.position.x - card.transform.position.x;
		var differenceY = transform.position.y - card.transform.position.y;
		Vector3 position;
		if (Mathf.Abs(differenceX) > Mathf.Abs(differenceY))
		{
			if (differenceX > 0)
				position = new Vector3(transform.position.x - 1.28f, transform.position.y, 0);
			else
				position = new Vector3(transform.position.x + 1.28f, transform.position.y, 0);
		}
		else
		{
			if (differenceY > 0)
				position = new Vector3(transform.position.x, transform.position.y - 1.28f, 0);
			else
				position = new Vector3(transform.position.x, transform.position.y + 1.28f, 0);
		}
		card.transform.position = position;
	}
}
