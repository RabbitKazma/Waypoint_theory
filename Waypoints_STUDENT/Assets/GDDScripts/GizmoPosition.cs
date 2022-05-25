/*
* Copyright 2013 Autodesk, Inc. All rights reserved.
* Use of this software is subject to the terms of the Autodesk license agreement and any attachments or Appendices thereto provided at the time of installation or download,
* or which otherwise accompanies this software in either electronic or hard copy form, or which is signed by you and accepted by Autodesk.
*/

using UnityEngine;

public class GizmoPosition : MonoBehaviour
{
	private float height = 1.5f;
	private float pinHeadSize = 0.5f;
	private float markerSize = 0.2f;
	
	void OnDrawGizmos () {
		if(tag == "path_01")
		{
			Gizmos.color = Color.blue;
		}
		else if (tag == "path_02")
		{
			Gizmos.color = Color.red;
		}
		Gizmos.DrawCube(transform.position + Vector3.up * height, new Vector3(pinHeadSize, pinHeadSize, pinHeadSize));
		Gizmos.DrawLine(transform.position, transform.position + Vector3.up * (height-pinHeadSize*0.5f));
		Gizmos.DrawLine(transform.position - Vector3.right * markerSize, transform.position - Vector3.right * markerSize);
		Gizmos.DrawCube(transform.position, new Vector3(pinHeadSize, 0.1f, pinHeadSize));
	}
}