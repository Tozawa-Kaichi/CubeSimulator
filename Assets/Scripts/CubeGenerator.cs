using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] GameObject _cubePrefab; // 生成するキューブのプレハブ
    [SerializeField] string _inputButton = "Fire1"; // ユーザー入力を検出するボタン名
    [SerializeField] Material _previewMaterial; // プレビューオブジェクトのマテリアル

    private GameObject _previewCube; // 生成位置のプレビューオブジェクト

    private void Start()
    {
        CreatePreviewCube();
    }

    private void Update()
    {
        if (Input.GetButtonDown(_inputButton))
        {
            GenerateCube();
        }

        // プレビューオブジェクトをジェネレーターの位置に表示
        _previewCube.transform.position = transform.position;
    }

    // プレビューオブジェクトの作成
    private void CreatePreviewCube()
    {
        _previewCube = Instantiate(_cubePrefab, Vector3.zero, Quaternion.identity);

        // プレビューオブジェクトのレンダラーを取得
        Renderer previewRenderer = _previewCube.GetComponent<Renderer>();

        // レンダラーにプレビューマテリアルを適用
        previewRenderer.material = _previewMaterial;
    }

    // キューブを生成する
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
