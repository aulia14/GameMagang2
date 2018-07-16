using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	public LayerMask unwalkableMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	Node[,] grid;

	float nodeDiameter;
	int gridSizeX, gridSizeY;

	void Awake() {
		nodeDiameter = nodeRadius*2;
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);
		CreateGrid();
	}

	void CreateGrid() {
		grid = new Node[gridSizeX,gridSizeY];
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;

		for (int x = 0; x < gridSizeX; x ++) {
			for (int y = 0; y < gridSizeY; y ++) {
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
				bool walkable = !(Physics.CheckSphere(worldPoint,nodeRadius,unwalkableMask));
				grid[x,y] = new Node(walkable,worldPoint, x,y);
			}
		}
	}

	public List<Node> GetNeighbours(Node node) {
		List<Node> neighbours = new List<Node>();

		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				if (x == 0 && y == 0)
					continue;

				int checkX = node.gridX + x;
				int checkY = node.gridY + y;

				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY) {
					neighbours.Add(grid[checkX,checkY]);
				}
			}
		}

		return neighbours;
	}
	

	public Node NodeFromWorldPoint(Vector3 worldPosition) {
		float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
		float percentY = (worldPosition.z + gridWorldSize.y/2) / gridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY-1) * percentY);
		return grid[x,y];
	}

	public List<Node> path;
	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,1,gridWorldSize.y));

		if (grid != null) {
			foreach (Node n in grid) {
				Gizmos.color = (n.walkable)?Color.white:Color.red;
				if (path != null)
					if (path.Contains(n))
						Gizmos.color = Color.black;
				Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f));
			}
		}
	}
}
/* 
	public class Grid : MonoBehaviour {
		//public Transform player; //variabel ini hanya untuk mengecek node 
		public LayerMask unwalkable;	//membuat layermask yang tidak bisa dilalui
		public Vector2 gridWorldSize;	//ukuran vector grid yang akan dibuat
		public float nodeRadius;	//Untuk radius antar grid
		Node[,] grid;	//Untuk Membuat ukuran grid
		float nodeDiameter;
		int gridSizeX,gridSizeY;

		private void Start() {
			nodeDiameter = 2*nodeRadius;	//penentuan nilai diameter
			gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter); //memperoleh nilai gridX
			gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);	//memperoleh nilai gridY
			CreateGrid();	//Attach Fungsi membuat grid dan checklayer
		}
		private void CreateGrid()
		{
			grid = new Node[gridSizeX,gridSizeY]; //deklarasi object grid dan inisialisasi
			//Pembuatan nilai ujung kiri grid
			Vector3 bottomLeftWorldGrid = transform.position - Vector3.right*(gridSizeX/2f)- Vector3.forward*(gridSizeY/2f); 
			
			//pembuatan grid 
			for (int x = 0; x < gridSizeX; x++)
			{
				for (int y = 0; y < gridSizeY; y++)
				{	//nilai ujung kiri grid ditambah nilai forward dan right
					Vector3 worldPoint = bottomLeftWorldGrid + Vector3.right*(x*nodeDiameter+nodeRadius)+ Vector3.forward*(y*nodeDiameter+nodeRadius);
					//check apakah grid yang dibuat bertumbukan dengan object lainnya
					bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius,unwalkable));
					//memanggil contructor
					grid[x,y] = new Node(walkable,worldPoint,x,y);
				}
			}
		}

		// fungsi untuk mencari nilai neighbour
		public List<Node> GetNeighbours(Node node){
			List<Node> neighbours = new List<Node>();

			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					if(x == 0 && y ==0) continue; //0 adlah nilai node tengah

					int checkX = node.gridX + x;
					int checkY = node.gridY + y;

					if(checkX>= 0 && checkX< gridSizeX && checkY>= 0&& checkY<gridSizeY)
					{
						neighbours.Add(grid[checkX,checkY]);
					}
				}
			}
			return neighbours;
		}

		//fungsi untuk membuat titik node pada player
		public Node NodeFromWorldPoint(Vector3 worldPosition){
			float percentX = (worldPosition.x + gridWorldSize.x/2)/gridWorldSize.x;
			float percentY = (worldPosition.z + gridWorldSize.y/2)/gridWorldSize.y;
			percentX = Mathf.Clamp01(percentX);//membulatkan nilai interval 0-1
			percentY = Mathf.Clamp01(percentY);//membulatkan nilai interval 0-1

			int x = Mathf.RoundToInt((gridSizeX-1)*percentX);
			int y = Mathf.RoundToInt((gridSizeY-1)*percentY);
			return grid[x,y];
		}

		public List<Node> path;
		//Untuk Menvisualisasi Grid yang akan dibuat
		private void OnDrawGizmos() {

			//Membuat gizmoz
			Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,1,gridWorldSize.y)); 
			//Membuat gridnya atau memvisualisai kannya
			if(grid != null){
				//inisiliasi player to grid
			///	Node playerTransfom = NodeFromWorld(player.position);
				foreach (Node n in grid)
				{
					//Menentukan pewarnaan
					Gizmos.color =(n.walkable)?Color.white:Color.red;
					//Memberikan warna pada gizmoz	
				//	if(playerTransfom == n) Gizmos.color = Color.cyan;	
					if(path != null)
						if(path.Contains(n)) Gizmos.color = Color.black;
					//Membuat Cube Grid
					Gizmos.DrawCube(n.worldPosition, Vector3.one*(nodeDiameter-.1f));
				}
			}


		}

	}
 */