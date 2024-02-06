using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject objPrefab = null; // prefab usado para dar spawn de novos objetos
    [SerializeField] [Range(0f, 360f)] private float angleDegrees = 0f;
    [SerializeField] private float objSpeed = 40f; // velocidade da seta em movimento
    [SerializeField] private float spawnFreq = 1f;
    [SerializeField] private float objLifeTime = 0.5f;

    private Quaternion rotation;
    private Vector3 direction;
    private Vector3 spawnPosition;
    void Awake() {
    }

    void Start() {
        // NOTA: Em jogos 2d, rotação faz-se no eixo z, Vector3.foward = new Vector3(0,0,1) !!!!!!
        this.rotation = Quaternion.Euler(0,0, angleDegrees);
        this.direction = new Vector3((float) Math.Cos(Mathf.Deg2Rad * this.angleDegrees), (float) Math.Sin( Mathf.Deg2Rad * this.angleDegrees),0);
        this.spawnPosition = this.transform.position  + direction * (GetComponent<Collider2D>().bounds.extents.x + 0.5f); // 05f é a distância para além do collider do dispenser, para acomodar tamanho do collider da seta, e não coliderem ao dar spawn
        
        InvokeRepeating("LaunchObject", 1f,spawnFreq);
    }

    void LaunchObject() {

        GameObject newObj = Instantiate(objPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D objRb = newObj.GetComponent<Rigidbody2D>();
        objRb.transform.rotation = rotation;
        objRb.velocity = direction * objSpeed;
        // Collider2D m_Collider = GetComponent<Collider2D>();
        // Debug.Log("extents : " + m_Collider.bounds);
        Destroy(newObj,objLifeTime);
    }
}
