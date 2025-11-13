using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public SlotItemPrefab[] slots;
    public Inventory myInven;

    public Sprite dirtSprite;
    public Sprite grassSprite;
    public Sprite waterSprite;


    public void UpdateInventoryUI()
    {
        // 모든 슬롯 초기화
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].ItemSetting(null, "");
        }

        //  Dictionary에 있는 아이템들을 순서대로 표시
        int index = 0;
        foreach (var item in myInven.items)
        {
            if (index >= slots.Length)
                break;

            Sprite icon = null;
            switch (item.Key)
            {
                case BlockType.Dirt: icon = dirtSprite; break;
                case BlockType.Grass: icon = grassSprite; break;
                case BlockType.Water: icon = waterSprite; break;
            }

            string text = $"{item.Value}";
            slots[index].ItemSetting(icon, text);
            index++;
        }
    }
}