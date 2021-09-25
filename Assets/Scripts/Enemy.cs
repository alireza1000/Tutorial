using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    [SerializeField] List<Blocks> way;
    
    
    
    private Dictionary<Vector2, Blocks> saveWay = new Dictionary<Vector2, Blocks>();
    private Vector3 moveUp = new Vector3(0, 2, 0);

    void Start()
    {
        TopColor(Color.blue);
        gameObject.transform.position = Vector3.up;
        //StartCoroutine(Path());
    }

    /*IEnumerator Path()
    {
        foreach (Blocks blocks in way)
        {
            transform.position = blocks.transform.position + moveUp;
            yield return new WaitForSeconds(1f);

        }

    }*/

    void AddBlocks()
    {
        var targetBlock = FindObjectsOfType<Blocks>();

        foreach (Blocks blocks in targetBlock)
        {
            bool overlap = saveWay.ContainsKey(blocks.GetPosition());

            if (overlap)
            {
                Debug.LogWarning("Overlap");
            }

            else
            {
                saveWay.Add(blocks.GetPosition(), blocks);
            }
        }
    }

    void TopColor(Color color)
    {
        GameObject gameObject = GameObject.FindWithTag("start");
        var meshrenderer = gameObject.GetComponent<MeshRenderer>();
        meshrenderer.material.color = color;
    }
}