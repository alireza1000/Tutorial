using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]  List<Blocks> way;

    private Vector3 moveUp = new Vector3(0, 2, 0);
    void Start()
    {
        StartCoroutine(Path());
    }

    IEnumerator Path()
    {
        foreach (Blocks blocks in way)
        {
            transform.position = blocks.transform.position + moveUp;
            yield return new WaitForSeconds(1f);

        }

    }

    
}
