using System.Collections.Generic;
using UnityEngine;
using Vectors;

public class TestHashCode : MonoBehaviour
{
    private const int DICTIONARY_SIZE = 1000;
    private const int TEST_COUNT = 1000;

    void Start()
    {
        CheckNumberCollisions((x, y) => new Vector2(Mathf.Sqrt(x), Mathf.Sqrt(y)));
        CheckNumberCollisions((x, y) => new Vector2Int(x, y));

        CheckNumberCollisions((x, y) => new Vector2D(Mathf.Sqrt(x), Mathf.Sqrt(y)));
        CheckNumberCollisions((x, y) => new VectorInt2D(x, y));

        CheckNumberCollisions((x, y, z) => new Vector3D(Mathf.Sqrt(x), Mathf.Sqrt(y), Mathf.Sqrt(z)));
        CheckNumberCollisions((x, y, z) => new VectorInt3D(x, y, z));
    }

    public delegate object vec2D(int x, int y);

    public delegate object vec3D(int x, int y, int z);


    public static void CheckNumberCollisions(vec2D createObject)
    {
        var collisions = 0;
        var size = DICTIONARY_SIZE * DICTIONARY_SIZE;
        var count = TEST_COUNT;
        var hashCodes = new Dictionary<int, object>(size);

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                var obj = createObject(i, j);
                var hashCode = obj.GetHashCode();
                if (hashCodes.ContainsKey(hashCode))
                {
                    collisions++;
                }
                else
                {
                    hashCodes[hashCode] = null;
                }
            }
        }

        var collisionsPercent = collisions * 100f / size;
        Debug.Log(
            $"{collisionsPercent}% collisions in " +
            $"{createObject(0, 0).GetType().FullName} ({collisions} matches out of {size} checks)");
    }

    public static void CheckNumberCollisions(vec3D createObject)
    {
        var collisions = 0;
        var size = DICTIONARY_SIZE * DICTIONARY_SIZE;
        var count = TEST_COUNT;
        var hashCodes = new Dictionary<int, object>(size);

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                var obj = createObject(i, j, (i + j));
                var hashCode = obj.GetHashCode();
                if (hashCodes.ContainsKey(hashCode))
                {
                    collisions++;
                }
                else
                {
                    hashCodes[hashCode] = null;
                }
            }
        }

        var collisionsPercent = collisions * 100f / size;
        Debug.Log(
            $"{collisionsPercent}% collisions in " +
            $"{createObject(0, 0, 0).GetType().FullName} ({collisions} matches out of {size} checks)");
    }
}