using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab; // 生成するキューブのプレハブ
    [SerializeField] private string _inputButton = "Fire1"; // ユーザー入力を検出するボタン名
    [SerializeField] private float _outlineWidth = 0.1f; // 輪郭線の幅
    [SerializeField] private Color _outlineColor = Color.yellow; // 輪郭線の色
    [SerializeField] private float _blinkSpeed = 1.0f; // 点滅の速さ

    private bool _isOutlineVisible = false; // 輪郭線の表示フラグ
    private Renderer _cubeRenderer; // 生成キューブのレンダラー
    private MaterialPropertyBlock _propertyBlock;

    private void Start()
    {
        _cubeRenderer = _cubePrefab.GetComponent<Renderer>();
        _propertyBlock = new MaterialPropertyBlock();
        SetOutlineVisible(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown(_inputButton))
        {
            GenerateCube();
        }

        // キューブの位置に輪郭線を表示
        if (_isOutlineVisible)
        {
            UpdateOutline();
        }
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

    // 輪郭線の表示を点滅させる
    private void UpdateOutline()
    {
        // 輪郭線の幅を点滅させる
        float outlineWidthOffset = Mathf.PingPong(Time.time * _blinkSpeed, _outlineWidth);
        SetOutlineWidth(outlineWidthOffset);
    }

    // 輪郭線の幅を設定する
    private void SetOutlineWidth(float width)
    {
        _propertyBlock.SetFloat("_OutlineWidth", width);
        _cubeRenderer.SetPropertyBlock(_propertyBlock);
    }

    // 輪郭線の表示/非表示を切り替える
    private void SetOutlineVisible(bool visible)
    {
        if (visible)
        {
            _propertyBlock.SetFloat("_OutlineWidth", _outlineWidth);
            _propertyBlock.SetColor("_OutlineColor", _outlineColor);
        }
        else
        {
            _propertyBlock.SetFloat("_OutlineWidth", 0f);
        }

        _cubeRenderer.SetPropertyBlock(_propertyBlock);
    }
}
