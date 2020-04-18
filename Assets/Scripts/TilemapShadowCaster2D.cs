using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TilemapShadowCaster2D : MonoBehaviour
{
    public void Start()
    {
        var tilemapCollider = GetComponent<CompositeCollider2D>();
        for (int i = 0; i < tilemapCollider.pathCount; i++)
        {
            Vector2[] pathVertices = new Vector2[tilemapCollider.GetPathPointCount(i)];
            tilemapCollider.GetPath(i, pathVertices);
            GameObject shadowCaster = new GameObject("shadow_caster_" + i);
            PolygonCollider2D shadowPolygon = (PolygonCollider2D) shadowCaster.AddComponent(typeof(PolygonCollider2D));
            shadowPolygon.points = pathVertices;
            shadowPolygon.enabled = false;
            ShadowCaster2D shadowCasterComponent = shadowCaster.AddComponent<ShadowCaster2D>();
            shadowCasterComponent.selfShadows = true;
        }
    }
}
