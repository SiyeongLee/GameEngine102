using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvester : MonoBehaviour
{
    public float rayDistance = 5f;          //채집 가능 거리
    public LayerMask hitMask = ~0;          //가능한 레이어 전부다
    public int toolDamage = 1;
    public float hitColldown = 0.15f;       //연타 간격
    private float _nextHitTime;
    private Camera _cam;
    public Inventory inventory;             //플레이어 인벤
    public InventoryUI inventoryUI;
    private void Awake()
    {
        _cam = Camera.main;
        if (inventory == null) inventory = gameObject.AddComponent<Inventory>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextHitTime)
        {
            _nextHitTime = Time.time + hitColldown;
            Ray ray = _cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));  //화면 중앙
            if (Physics.Raycast(ray, out var hit, rayDistance, hitMask))
            {
                var block = hit.collider.GetComponent<Block>();
                if (block != null)
                    block.Hit(toolDamage, inventory);

                if (inventoryUI != null)
                    inventoryUI.UpdateInventoryUI();
            }
        }
    }
}