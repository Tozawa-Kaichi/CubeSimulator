using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject _cubePrefab; // 生成するキューブのプレハブ
    public string _inputButton = "Fire1"; // ユーザー入力を検出するボタン名

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GenerateCube();
        }
    }

    private void GenerateCube()
    {
        // このスクリプトがアタッチされているオブジェクトの位置を生成位置として使用
        Vector3 spawnPosition = transform.position;

        GameObject newCube = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);

        Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();
        if (cubeRigidbody != null)
        {
            cubeRigidbody.useGravity = true;
        }
    }
}