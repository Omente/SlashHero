using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerPos;

    [SerializeField] private float offsetX = -6f;

    private Vector3 tempPos;

    private void LateUpdate()
    {
        FollowPlayer();
    }

    public void FindPlayerReference()
    {
        playerPos = GameObject.FindWithTag(TagManager.TAG_PLAYER).transform;
    }

    private void FollowPlayer()
    {
        if (!playerPos) 
            return;

        tempPos = transform.position;
        tempPos.x = playerPos.transform.position.x - offsetX;
        transform.position = tempPos;
    }
}
