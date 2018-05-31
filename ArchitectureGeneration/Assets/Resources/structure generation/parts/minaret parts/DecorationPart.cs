using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationPart: MinaretPart {

	GameObject decorShaftPrefab;
	GameObject decorSpherePrefab;

    private void Start()
    {
        build();
    }

    public void build()
    {
        initData ();
        decorShaftPrefab = GenericUtils.loadPrefab("generic", "cylinder12");
        decorSpherePrefab = GenericUtils.loadPrefab("generic", "icosphere");
        Vector3 basePosition = new Vector3(transform.position.x, 0, transform.position.z);
		float baseHeight = transform.position.y;
		float currentHeight = baseHeight;
		for (int i = 0; i < data.decorSequence.Count-1; i++) {
			float size = data.decorSequence [i] * 0.1f;
			currentHeight += 0.1f;
			myInstantiate (decorSpherePrefab, basePosition + Vector3.up * (currentHeight +  (size/2f)), size, size);
			currentHeight += size;
		}
		currentHeight += 0.1f;
		myInstantiate (data.decorPrefab, basePosition + Vector3.up * currentHeight, data.decorWidth, data.decorHeight);
		myInstantiate (decorShaftPrefab, basePosition + Vector3.up * baseHeight, 0.1f, currentHeight - baseHeight);
	}
	
}
