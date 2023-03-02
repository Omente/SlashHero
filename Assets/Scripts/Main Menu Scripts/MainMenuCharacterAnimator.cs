using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCharacterAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] animationSprites;
    [SerializeField] private Image currentImage;

    private int currentAnimationImage;
    private float timer;
    private float timerTreshold = 0.08f;

    private void Awake()
    {
        currentAnimationImage = 0;
    }

    private void Start()
    {
        timer = Time.time + timerTreshold;
    }

    private void Update()
    {
        if (Time.time < timer)
            return;

        timer = Time.time + timerTreshold;

        PlayAnimation();
    }

    private void PlayAnimation()
    {
        if (currentAnimationImage == animationSprites.Length)
            currentAnimationImage = 0;

        currentImage.sprite = animationSprites[currentAnimationImage];

        currentAnimationImage++;
    }
}
