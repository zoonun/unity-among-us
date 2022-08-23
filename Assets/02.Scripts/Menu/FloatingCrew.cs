using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    public EPlayerColor playerColor;
    
    private SpriteRenderer _spriteRenderer;
    private Vector3 dir;
    private float floatSpeed;
    private float rotateSpeed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFloatingCrew(Sprite sprite, EPlayerColor playerColor, Vector3 dir, float floatSpeed,
        float rotateSpeed, float size)
    {
        this.playerColor = playerColor;
        this.dir = dir;
        this.floatSpeed = floatSpeed;
        this.rotateSpeed = rotateSpeed;

        _spriteRenderer.sprite = sprite;
        _spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.getColor(playerColor));

        transform.localScale = new Vector3(size, size, size);
        _spriteRenderer.sortingOrder = (int)Mathf.Lerp(1, 32767, size);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * floatSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotateSpeed));
    }
}
