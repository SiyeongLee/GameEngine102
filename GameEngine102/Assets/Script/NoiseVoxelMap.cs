using UnityEngine;

public class NoiseVoxelMap : MonoBehaviour
{
    public GameObject grassPrefab;
    public GameObject dirtPrefab;
    public GameObject waterPrefab;
    public int width = 20;
    public int depth = 20;
    public int maxHeight = 16; // Y
    public int dirtHeight;
    public int waterHeight = 5;
    [SerializeField] float noiseScale = 20f;

    void Start()
    {
        dirtHeight = maxHeight - 1;

        float offsetX = Random.Range(-9999f, 9999f);
        float offsetZ = Random.Range(-9999f, 9999f);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float nx = (x + offsetX) / noiseScale;
                float nz = (z + offsetZ) / noiseScale;

                float noise = Mathf.PerlinNoise(nx, nz);

                int h = Mathf.FloorToInt(noise * maxHeight);

                if (h < 0) continue;

                for (int y = 0; y <= h; y++)
                {

                    if (y == h)
                    {
                        Place(x, y, z);
                    }
                    else
                    {
                        SetDirt(x, y, z);
                    }
                }
                for (int wh = h+1; wh <= waterHeight; wh++)
                {
                    if (waterHeight >= wh)
                    {
                        SetWater(x, wh, z);
                    }
                }
            }
        }
    }

    private void Place(int x, int y, int z)
    {
        var go = Instantiate(grassPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
        go.name = $"B_{x}_{y}_{z}_g";
    }
    private void SetDirt(int x, int y, int z)
    {
        var go = Instantiate(dirtPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
        go.name = $"B_{x}_{y}_{z}_D";

        
    }
    private void SetWater(int x, int y, int z)
    {
        var go = Instantiate(waterPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
        go.name = $"B_{x}_{y}_{z}_W";
    }
}