using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject screw; // Đối tượng screw
    [SerializeField] private Collider2D holeCollider; // Collider của đối tượng Hole
    private bool playerPassed = false; // Cờ để theo dõi trạng thái của player

    void Start()
    {
        // Lấy Collider2D của đối tượng Hole
        holeCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Kiểm tra nếu screw không hoạt động thì bật Collider2D của Hole
        if (screw != null && !screw.activeInHierarchy)
        {
            holeCollider.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra va chạm với player
        if (other.CompareTag("Player"))
        {
            if (!playerPassed)
            {
                // Lần đầu tiên player đi qua
                playerPassed = true;
            }
            else
            {
                // Player quay lại
                if (screw != null)
                {
                    screw.SetActive(true);
                    holeCollider.enabled = false;
                    playerPassed = false; // Reset cờ để có thể kích hoạt lại khi player đi qua lần nữa
                }
            }
        }
    }
    public float gridSize = 0.5f;  // Kích thước lưới mà bạn muốn snap tới

    void OnDrawGizmos()
    {
        // Vẽ một ô lưới trong Scene View
        Gizmos.color = Color.green;  // Đặt màu cho gizmos
        Vector3 snapPosition = new Vector3(
            Mathf.Round(transform.position.x / gridSize) * gridSize,
            Mathf.Round(transform.position.y / gridSize) * gridSize,
            transform.position.z
        );
        transform.position = snapPosition;
        // Vẽ một quả cầu gizmo tại vị trí snap
        Gizmos.DrawSphere(snapPosition, 0.1f);
    }
}
