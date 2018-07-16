using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PathFinding : MonoBehaviour {

	public Transform seeker, target;
	Grid grid;

	void Awake() {
		grid = GetComponent<Grid> ();
	}

	void Update() {
		FindPath (seeker.position, target.position);
	}

	void FindPath(Vector3 startPos, Vector3 targetPos) {
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);

		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0) {
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i ++) {
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost) {
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode) {
				RetracePath(startNode,targetNode);
				return;
			}

			foreach (Node neighbour in grid.GetNeighbours(node)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
	}

	void RetracePath(Node startNode, Node endNode) {
		List<Node> path = new List<Node>();
		Node currentNode = endNode;

		while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();

		grid.path = path;

	}

	int GetDistance(Node nodeA, Node nodeB) {
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14*dstY + 10* (dstX-dstY);
		return 14*dstX + 10 * (dstY-dstX);
	}
}
/* 
	public class PathFinding : MonoBehaviour {

		public Transform seeker, target;
		Grid grid;

		private void Awake() {
			grid = GetComponent<Grid>();
		}
		private void Update() {
			FindPath(seeker.position,target.position);
		}

	//Class untuk mencari posisi seeker dengan psisi target
		void FindPath(Vector3 startPos, Vector3 endPos){
			Node startNode = grid.NodeFromWorldPoint(startPos); //inisialisasi posisi seeker
			Node targetNode = grid.NodeFromWorldPoint(endPos); //inisialisasi posisi target

			List<Node> openSet  = new List<Node>(); // set untuk menampung node yang akan disearch
			HashSet<Node> closeSet = new HashSet<Node>(); //set untuk menampung node yang sudah disearch
			openSet.Add(startNode); // menambahkan startNode kedalam openSet
			
			//Melakukan perhitungan fCos
			while(openSet.Count>0){
				Node currentNode = openSet[0]; //set awal node seeker
				for (int i = 1; i < openSet.Count; i++) 
				{	//mencari nilai fcos terendah dari openSet Node
					if(openSet[i].fCos<currentNode.fCos || openSet[i].fCos == currentNode.fCos && openSet[i].hCos<currentNode.hCos){
						currentNode = openSet[i];
					}
				}
				openSet.Remove(currentNode); // menghapus node dari openSetyang sudah dicari
				closeSet.Add(currentNode);	//dan disimpan dalam closeNode
				if(currentNode == targetNode){
					RetracePath(currentNode,targetNode);
					return ;//jika nilai currentNode == targetNode /path sudah ditemukan
				}
					
				

				foreach(Node neighbour in grid.GetNeighbours(currentNode)){//mengecek apakah tetangga itu walkable dan terdapt dalam closet
					if(!neighbour.walkable && closeSet.Contains(neighbour)) continue;

					int newMovementCostToNeighbour = currentNode.gCos + GetDistance(currentNode,neighbour);
					if(newMovementCostToNeighbour <= neighbour.gCos || !openSet.Contains(neighbour)){
						neighbour.gCos = newMovementCostToNeighbour;
						neighbour.hCos = GetDistance(neighbour,targetNode);
						neighbour.parent = currentNode;

						if(!openSet.Contains(neighbour)){
							openSet.Add(currentNode);
						}
					}
				}
			}
		}

		void RetracePath(Node startNode, Node endNode){
			List<Node> path = new List<Node>();
			Node currentNode = endNode;

			while(currentNode!=startNode){
				path.Add(currentNode);
				currentNode = currentNode.parent;
			}	
			path.Reverse();
			grid.path = path;
		}

		int GetDistance(Node nodeA, Node nodeB){
			int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
			int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

			if(dstX> dstY) return 14*dstY + 10*(dstX-dstY);
				return 14*dstX + 10*(dstY-dstX);
		}
	}
 */


