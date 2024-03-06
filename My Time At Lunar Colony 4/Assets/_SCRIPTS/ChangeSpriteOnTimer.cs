using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteOnTimer : MonoBehaviour
{
    public float changeTimer = 2.0f;
    public bool timerDone;

    public List<Sprite> spriteList;

    [SerializeField]
    private int spriteIndex;

    [SerializeField]
    private Image image;


    void Start()
    {
        image = GetComponent<Image>();
        StartTimer();
    }

    void Update()
    {
        StartTimer();
    }

    void StartTimer()
    {
        if (changeTimer > 0.0f)
        {
            changeTimer -= Time.deltaTime;
        }
        else
        {
            ChangeSprite();
        }
    }

    public void ChangeSprite()
    {
        if (spriteIndex <= spriteList.Count)
        {
            image.sprite = spriteList[spriteIndex];
            spriteIndex++;
        }
        if (spriteIndex >= spriteList.Count)
        {
            spriteIndex = 0;
        }
        changeTimer = 2.0f;
    }
}