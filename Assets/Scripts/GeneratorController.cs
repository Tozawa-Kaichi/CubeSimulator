using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f; // 移動速度
    [SerializeField] private float ascendSpeed = 5.0f; // 上昇速度
    [SerializeField] private float descendSpeed = 5.0f; // 下降速度

    private void Update()
    {
        // ジェネレーターの移動
        MoveGenerator();

        // ジェネレーターの上昇と下降
        AscendDescendGenerator();
    }

    private void MoveGenerator()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 移動ベクトルの計算
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection.Normalize();

        // ジェネレーターの移動
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void AscendDescendGenerator()
    {
        // ジェネレーターの上昇
        if (Input.GetButtonDown("Jump")) // Jump ボタンはデフォルトでスペースキーにマップされています
        {
            transform.Translate(Vector3.up * ascendSpeed * Time.deltaTime);
        }
        // ジェネレーターの下降
        else if (Input.GetButtonDown("Fire3")) // Fire3 ボタンはデフォルトで左Shiftにマップされています
        {
            transform.Translate(Vector3.down * descendSpeed * Time.deltaTime);
        }
    }
}
