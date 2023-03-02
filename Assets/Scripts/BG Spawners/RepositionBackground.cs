using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBackground : MonoBehaviour
{
    [SerializeField] private string bgTag;

    private GameObject[] backgrounds;
    private float highestXPosition;
    private float offsetValue;
    private float newXPos;
    private Vector3 newPosition;

    private void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag(bgTag);
        offsetValue = backgrounds[0].GetComponent<BoxCollider2D>().bounds.size.x;
        highestXPosition = backgrounds[0].transform.position.x;

        foreach (var background in backgrounds)
        {
            if(background.transform.position.x > highestXPosition)
            {
                highestXPosition = background.transform.position.x;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(bgTag))
        {
            newXPos = highestXPosition + offsetValue;
            highestXPosition = newXPos;
            newPosition = collision.transform.position;
            newPosition.x = newXPos;
            collision.transform.position = newPosition;
        }
    }
}
