using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBackground : MonoBehaviour
{
    [SerializeField] List<Sprite> SpritesList = new List<Sprite>();
    [SerializeField] bool canTorch;
    [SerializeField] float torchPossibilities = 35;
    [SerializeField] GameObject torch;
    int index;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            index = (int)Random.Range(0, SpritesList.Count);
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = SpritesList[index];
        }

        if (canTorch)
        {
            float random = Random.Range(0, 100);
            if(random < torchPossibilities)
            {
                Instantiate(torch, transform);
            }
        }
    }
}
