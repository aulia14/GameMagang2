using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class Node {
	
	public bool walkable;
	public Vector3 worldPosition;
	public int gridX;
	public int gridY;

	public int gCost;
	public int hCost;
	public Node parent;
	
	public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY) {
		walkable = _walkable;
		worldPosition = _worldPos;
		gridX = _gridX;
		gridY = _gridY;
	}

	public int fCost {
		get {
			return gCost + hCost;
		}
	}
}
/* 	public class Node 
	{
		public bool walkable; // membuat variable untuk daerah yang walkable
		public Vector3 worldPosition; //menentukan posisi
		public int gCos, hCos; // set nilai gCos, hCos
		public Node parent;
		public int gridX,gridY; 	

	//Buat contructor
		public Node(bool _walkable,Vector3 _worldPos, int _gridX, int _gridY){
			walkable = _walkable;
			worldPosition = _worldPos;
			gridX = _gridX;
			gridY = _gridY;
		}
	//Set Properti fCos
		public int fCos{
			get{
				return gCos+hCos;
			}
		}

	} */
