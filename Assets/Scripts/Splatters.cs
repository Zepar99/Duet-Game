using UnityEngine;

public class Splatters : SingletonGeneric<Splatters>
{
    [SerializeField] Color[] colors = new Color[2];
    [SerializeField] GameObject splatterPrefab;
    [SerializeField] Sprite[] splatterSprites;

    public void AddSplatter(Transform obstacle, Vector3 pos, int colorIndex)
    {
        GameObject splatter = Instantiate(
            splatterPrefab,
            pos,
            Quaternion.Euler(new Vector3(0, 0, Random.Range(-320f, 320f))), obstacle);
        SpriteRenderer sr = splatter.GetComponent<SpriteRenderer>();
        sr.color = colors[colorIndex];
        sr.sprite = splatterSprites[Random.Range(0, splatterSprites.Length)];
    }
}
