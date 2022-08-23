using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrewFloater : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private List<Sprite> sprites;
    private bool[] crewStates = new bool[12];
    private float timer = 0.5f;
    private float distance = 11f;

    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            SpawnFloatingCrew((EPlayerColor)i, Random.Range(0f, distance));
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnFloatingCrew((EPlayerColor)Random.Range(0,12), distance);
            timer = 0.5f;
        }
    }

    public void SpawnFloatingCrew(EPlayerColor playerColor, float dist)
    {
        if (!crewStates[(int)playerColor])
        {
            crewStates[(int)playerColor] = true;
            float angle = Random.Range(0f, 360f);
            Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * dist;
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            float floatSpeed = Random.Range(1f, 4f);
            float rotateSpeed = Random.Range(-4f, 4f);

            var crew = Instantiate(prefab, spawnPos, Quaternion.identity).GetComponent<FloatingCrew>();
            crew.SetFloatingCrew(sprites[Random.Range(0, sprites.Count)], playerColor, direction, floatSpeed, rotateSpeed, Random.Range(0.5f, 1f));
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        var crew = coll.GetComponent<FloatingCrew>();
        if (crew != null)
        {
            crewStates[(int)crew.playerColor] = false;
            Destroy(crew.gameObject);
        }
    }
}
