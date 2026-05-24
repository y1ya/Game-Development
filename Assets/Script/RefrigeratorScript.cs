using UnityEngine;

public class RefrigeratorScript : MonoBehaviour
{
    public SpriteRenderer currentSpriteRenderer;

    public GameObject refrigeratorObject;
    public GameObject topShelfObjects, bottomShelfObjects;

    public Sprite closedRefrigerator, openRefrigerator;

    private bool isOpen = false;

    private void Start()
    {
        currentSpriteRenderer = refrigeratorObject.GetComponent<SpriteRenderer>();
        currentSpriteRenderer.sprite = closedRefrigerator;
    }

    public void ToggleRefrigerator()
    {
        // Toggle sprite when clicked
        if (isOpen)
        {
            currentSpriteRenderer.sprite = closedRefrigerator;

            for (int i = 0; i < topShelfObjects.transform.childCount; i++)
            {
                Transform child = topShelfObjects.transform.GetChild(i);
                BoxCollider2D childCollider = child.GetComponent<BoxCollider2D>();

                if (childCollider != null)
                {
                    childCollider.enabled = false; // disable collider
                }
            }

            for (int i = 0; i < bottomShelfObjects.transform.childCount; i++)
            {
                Transform child = bottomShelfObjects.transform.GetChild(i);
                BoxCollider2D childCollider = child.GetComponent<BoxCollider2D>();
                if (childCollider != null)
                {
                    childCollider.enabled = false; // disable collider
                }
            }

            isOpen = false;
        }
        else
        {
            currentSpriteRenderer.sprite = openRefrigerator;

            for (int i = 0; i < topShelfObjects.transform.childCount; i++)
            {
                Transform child = topShelfObjects.transform.GetChild(i);
                BoxCollider2D childCollider = child.GetComponent<BoxCollider2D>();

                if (childCollider != null)
                {
                    childCollider.enabled = true; // enable collider
                }
            }

            for (int i = 0; i < bottomShelfObjects.transform.childCount; i++)
            {
                Transform child = bottomShelfObjects.transform.GetChild(i);
                BoxCollider2D childCollider = child.GetComponent<BoxCollider2D>();
                if (childCollider != null)
                {
                    childCollider.enabled = true; // enable collider
                }
            }

            isOpen = true;
        }
    }
}
