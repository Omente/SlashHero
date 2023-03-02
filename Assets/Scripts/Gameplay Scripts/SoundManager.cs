using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioClip bgMusic, mainMenuMusic, gameOverSound, playerAttackSound, 
        pleyerDeathSound, playerJumpSound, enemyAttackSound, enemyDeathSound, collectableSound;

    private AudioSource bgAudio;

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        bgAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (DataManager.GetData(TagManager.DATA_SOUND_PLAY) != 1) return;

        if (scene.name == TagManager.SCENE_NAME_GAMEPLAY)
        {
            bgAudio.clip = bgMusic;
        }
        else if (scene.name == TagManager.SCENE_NAME_MAIN_MENU)
        {
            bgAudio.clip = mainMenuMusic;
        }

        if(bgAudio.clip)
            bgAudio.Play();
    }

    public void PlayGameOverSound()
    {
        AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
    }

    public void PlayPlayerAttackSound()
    {
        AudioSource.PlayClipAtPoint(playerAttackSound, transform.position);
    }

    public void PlayPlayerJumpSound()
    {
        AudioSource.PlayClipAtPoint(playerJumpSound, transform.position);
    }

    public void PlayPlayerDeathSound()
    {
        AudioSource.PlayClipAtPoint(pleyerDeathSound, transform.position);
    }

    public void PlayEnemyDeathSound()
    {
        AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
    }
    public void PlayEnemyAttackSound()
    {
        AudioSource.PlayClipAtPoint(enemyAttackSound, transform.position);
    }

    public void PlayCollectableSound()
    {
        AudioSource.PlayClipAtPoint(collectableSound, transform.position);
    }

    public void PlayObstacleDestroySound()
    {
        AudioSource.PlayClipAtPoint(collectableSound, transform.position);
    }

    private void OnOffMusic()
    {

    }
}