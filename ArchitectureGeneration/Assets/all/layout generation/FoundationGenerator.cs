using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoundationGenerator : MonoBehaviour {

	private int minLengthR;
	private int maxLengthR;
	private int minLengthS;
	private int maxLengthS;
	private float minRatio;
	private float maxRatio;
	private int maxCornerSize;
	private int minaretSize;

	private int total;
	private int minaretNumber;

	public List<BuildingFoundation> rectangles = new List<BuildingFoundation> ();
	public List<BuildingFoundation> squares = new List<BuildingFoundation> ();
	public List<BuildingFoundation> minarets = new List<BuildingFoundation> ();
	public List<Junction> 	junctions = new List<Junction> ();
	public List<Edge> freeEdges = new List<Edge> ();
	public List<Edge> usedEdges = new List<Edge> ();
	public List<Vector3> allCorners = new List<Vector3> ();
	public List<Vector3> freeCorners = new List<Vector3> ();

	void initData(){
		LayoutGenerationData data = GameObject.Find ("DataHolder").GetComponent<LayoutGenerationData> ();
		minLengthR = data.minLengthR;
		maxLengthR = data.maxLengthR;
		minLengthS = data.minLengthS;
		maxLengthS = data.maxLengthS;
		minRatio = data.minRatio;
		maxRatio = data.maxRatio;
		maxCornerSize = data.maxCornerSize;
		minaretSize = data.minaretSize;
		total = Random.Range (data.total_min, data.total_max + 1);
		minaretNumber = Random.Range (data.minarets_min, data.minarets_max + 1);
	}

	public IEnumerator generateImmediate(){
		initData ();
		int squareChance = (int)(100 / total);
		int steps = 0;
		generateFirstRect ();
		steps++;
		while (steps<total){
			if (Randomiser.rollUnder (squareChance)) {
				yield return StartCoroutine (squareStep (0));
			} else {
				yield return StartCoroutine (rectangleStep (0));
			}
			steps++;
			squareChance = (int)(100  * steps / total);
		}
		while (minaretNumber > 0) {
			yield return StartCoroutine (minaretStep (0));
			minaretNumber--;
		}
		updateFreeCorners ();
		GameObject[] cubes = GameObject.FindGameObjectsWithTag ("temp");
		foreach (GameObject cube in cubes) {
			Destroy (cube);
		}
	}

	void generateFirstRect(){
		int l1 = Randomiser.intBetweenEven (minLengthR, maxLengthR);
		int l2 = Randomiser.intBetweenEven ((int)(l1 * minRatio), (int)(l1 * maxRatio));
		l2 = Randomiser.clampInRange (l2, minLengthR, maxLengthR);
		Vector3 center = Vector3.zero;
		Vector3[] corners = new Vector3[4]; 
		corners[0] = center+(Vector3.forward*l1/2f)+(Vector3.left*l2/2f);
		corners [1] = corners [0] + Vector3.right * l2;
		corners [2] = corners [1] + Vector3.back * l1;
		corners[3] = corners [2] + Vector3.left * l2;
		RectangleFoundation newRect = new RectangleFoundation (corners, center, l2, l1);
		rectangles.Add(newRect);
		freeEdges.AddRange (newRect.getEdges());
		freeCorners.AddRange (newRect.corners);
		allCorners.AddRange (newRect.corners);
	}

	#region update

	void updateLists(BuildingFoundation newFoundation, Edge curEdge, Junction curJunction, List<BuildingFoundation> toUpdate, bool addEdges, bool addFreeCorners){ 
		toUpdate.Add (newFoundation);
		if (addFreeCorners) {
			freeCorners.AddRange (newFoundation.corners);
		}
		allCorners.AddRange (newFoundation.corners);
		List<Edge> newEdges = newFoundation.getEdges ();
		usedEdges.Add (newEdges [3]);
		if (addEdges) {
			newEdges.RemoveAt (3);
			freeEdges.AddRange (newEdges);
		}
		freeEdges.Remove (curEdge);
		usedEdges.Add (curEdge);
		curJunction.adjacentFoundations [0] = curEdge.foundation;
		curJunction.adjacentFoundations [1] = newFoundation;
		junctions.Add (curJunction);
	}

	void addEdges(List<Edge> newEdges){
		foreach (Edge e in newEdges) {
			addEdgeSorted (e);
		}
	}

	void addEdgeSorted(Edge e){
		int i = 0;
		while (i<freeEdges.Count && freeEdges[i].getMidpoint().sqrMagnitude < e.getMidpoint().sqrMagnitude){
			i++;
		}
		freeEdges.Add (e);
	}

	#endregion

	#region rectangle step

	IEnumerator rectangleStep(float stepTime){
		int maxAttempts = 50;
		yield return new WaitForSeconds (stepTime);
		while (maxAttempts>0 && !addNewRectangle ()) {
				maxAttempts--;
		}
	}
		
	bool addNewRectangle(){
		Edge curEdge = freeEdges[Randomiser.intBetween(0,freeEdges.Count/2)];
		Junction junction = new Junction(Randomiser.pointOnEdge (curEdge), curEdge.axisDirection);
		Vector3 measurePoint = junction.position + 0.2f * curEdge.axisDirection;
		if (!checkJunction (measurePoint)) {
			return false;
		}
		int distanceAlongEdge = Mathf.Min (
			Randomiser.measureDistance(measurePoint, GenericUtils.rotateClockwise(curEdge.axisDirection), maxLengthR/2),
			Randomiser.measureDistance(measurePoint, -1*GenericUtils.rotateClockwise(curEdge.axisDirection), maxLengthR/2)
		);
		if (distanceAlongEdge*2<minLengthR) { 
			return false;
		}
		int distanceAlongAxis = Randomiser.measureDistance(measurePoint, curEdge.axisDirection, maxLengthR);
		if (distanceAlongAxis*2<minLengthR) { 
			return false;
		}
		distanceAlongAxis = Randomiser.clampInRange (distanceAlongAxis, minLengthR, (int)(distanceAlongEdge * 2));
		RectangleFoundation rect = RectangleFromJunction (junction, curEdge.axisDirection, distanceAlongEdge * 2, distanceAlongAxis);
		if (!checkRectangleConsistency(rect)) {  
			rect.delete();
			return false;
		}
		if (!checkOverlaps(rect)){
			rect.delete ();
			return false;
		}
		updateLists (rect, curEdge, junction, rectangles, true, true);
		return true;
	}

	RectangleFoundation RectangleFromJunction(Junction j, Vector3 axis, int maxAlongEdge, int maxAlongAxis){
		int alongAxis = Randomiser.intBetweenEven (minLengthR, maxLengthR);
		Vector3 center = j.position + alongAxis/2f * axis;
		int alongEdge = Randomiser.intBetweenEven ((int)(alongAxis*minRatio),(int)(alongAxis*maxRatio));
		alongEdge = Randomiser.clampInRange (alongEdge, minLengthR, maxAlongEdge);
		Vector3[] corners = new Vector3[4];
		corners [0] = j.position + GenericUtils.rotateClockwise (axis) * (-1) * alongEdge / 2f;
		corners [1] = corners [0] + axis * alongAxis;
		corners [2] = corners [1] + GenericUtils.rotateClockwise (axis) * alongEdge;
		corners [3] = corners [2] + axis * alongAxis * (-1);
		if (axis.x!=0){
			return new RectangleFoundation (corners, center, alongAxis, alongEdge);
		}
		return new RectangleFoundation (corners, center, alongEdge, alongAxis);
	}
		
	#endregion

	#region square step

	IEnumerator squareStep(float stepTime){
		int maxAttempts = 50;
		yield return new WaitForSeconds (stepTime);
		while (maxAttempts > 0 && !addNewSquare ()) {
			maxAttempts--;
		}
	}

	bool addNewSquare(){
		Edge curEdge = freeEdges[Randomiser.intBetween(0,freeEdges.Count/2)];
		Junction junction = new Junction(Randomiser.pointOnEdge (curEdge), curEdge.axisDirection);
		Vector3 measurePoint = junction.position + 0.2f * curEdge.axisDirection;
		if (!checkJunction (measurePoint)) {
			return false;
		}
		int distanceAlongEdge = Mathf.Min (
			Randomiser.measureDistance(measurePoint, GenericUtils.rotateClockwise(curEdge.axisDirection), maxLengthR/2),
			Randomiser.measureDistance(measurePoint, -1*GenericUtils.rotateClockwise(curEdge.axisDirection), maxLengthR/2)
		);
		if (distanceAlongEdge<minLengthS) { 
			return false;
		}
		int distanceAlongAxis = Randomiser.measureDistance(measurePoint, curEdge.axisDirection, maxLengthR);
		if (distanceAlongAxis*2<minLengthS) { 
			return false;
		}
		distanceAlongAxis = Randomiser.clampInRange (distanceAlongAxis, minLengthR, (int)(distanceAlongEdge * 2));
		SquareFoundation square = SquareFromJunction (junction, curEdge.axisDirection, Mathf.Min(distanceAlongEdge*2, distanceAlongAxis));
		if (!checkSquareConsistency(square)) {  
			square.delete();
			return false;
		}
		if (!checkOverlaps(square)){
			square.delete ();
			return false;
		}
		updateLists (square, curEdge, junction, squares, true, false);
		return true;
	}

	SquareFoundation SquareFromJunction(Junction j, Vector3 axis, int maxSide){
		int side = Randomiser.intBetweenEven (minLengthS, Mathf.Min(maxSide, maxLengthS));
		Vector3 center = j.position + side/2f * axis;
		Vector3[] corners = new Vector3[4];
		corners [0] = j.position + GenericUtils.rotateClockwise (axis) * (-1) * side / 2f;
		corners [1] = corners [0] + axis * side;
		corners [2] = corners [1] + GenericUtils.rotateClockwise (axis) * side;
		corners [3] = corners [2] + axis * side * (-1);
		return new SquareFoundation (corners, center, side);
	}

	#endregion

	#region minaret step

	IEnumerator minaretStep(float stepTime){
		int maxAttempts = 50;
		yield return new WaitForSeconds (stepTime);
		while (maxAttempts > 0 && !addNewMinaret ()) {
			maxAttempts--;
		}
	}

	bool addNewMinaret(){
		Edge curEdge = freeEdges[Randomiser.intBetween(0,freeEdges.Count/2)];
		Junction junction = new Junction(Randomiser.pointOnEdge (curEdge), curEdge.axisDirection);
		Vector3 measurePoint = junction.position + 0.2f * curEdge.axisDirection;
		if (!checkJunction (measurePoint)) {
			return false;
		}
		int distanceAlongEdge = Mathf.Min (
			Randomiser.measureDistance(measurePoint, GenericUtils.rotateClockwise(curEdge.axisDirection), maxLengthR/2),
			Randomiser.measureDistance(measurePoint, -1*GenericUtils.rotateClockwise(curEdge.axisDirection), maxLengthR/2)
		);
		if (distanceAlongEdge<minLengthS) { 
			return false;
		}
		int distanceAlongAxis = Randomiser.measureDistance(measurePoint, curEdge.axisDirection, minaretSize);
		if (distanceAlongAxis*2<minaretSize) { 
			return false;
		}
		distanceAlongAxis = Randomiser.clampInRange (distanceAlongAxis, minaretSize, (int)(distanceAlongEdge * 2));
		MinaretFoundation minaret = minaretFromJunction (junction, curEdge.axisDirection, Mathf.Min(distanceAlongEdge*2, distanceAlongAxis));
		if (!checkMinaretConsistency(minaret)) {  
			minaret.delete();
			return false;
		}
		if (!checkOverlaps(minaret)){
			minaret.delete ();
			return false;
		}
		minarets.Add (minaret);
		freeEdges.Remove (curEdge);
		usedEdges.Add (curEdge);
		return true;
	}

	MinaretFoundation minaretFromJunction(Junction j, Vector3 axis, int side){
		Vector3 center = j.position + side/2f * axis;
		Vector3[] corners = new Vector3[4];
		corners [0] = j.position + GenericUtils.rotateClockwise (axis) * (-1) * side / 2f;
		corners [1] = corners [0] + axis * side;
		corners [2] = corners [1] + GenericUtils.rotateClockwise (axis) * side;
		corners [3] = corners [2] + axis * side * (-1);
		return new MinaretFoundation (corners, center, side);
	}

	#endregion

	#region checks

	void updateFreeCorners(){
		List<Vector3> newList = new List<Vector3>();
		foreach (Vector3 c in freeCorners) {
			if (Raycaster.isFreeCorner (c,maxCornerSize)) {
				newList.Add (c);
			}
		}
		freeCorners = newList;
	}

	bool checkJunction(Vector3 j){
		foreach (RectangleFoundation r in rectangles) {  
			if (r.containsPoint (j)) {
				return false;
			}
		}
		return true;
	}

	bool checkRectangleConsistency(RectangleFoundation r){
		return r.isConsistent (minLengthR, maxLengthR, minRatio, maxRatio);
	}

	bool checkSquareConsistency(SquareFoundation s){
		return s.isConsistent (minLengthS, maxLengthS);
	}

	bool checkMinaretConsistency(MinaretFoundation m){
		return m.isConsistent (minaretSize, minaretSize);
	}

	bool checkOverlaps(BuildingFoundation newFoundation){
		foreach (Vector3 corner in newFoundation.corners) {
			foreach (RectangleFoundation r in rectangles) {
				if (r.containsPoint (corner))
					return false;
			}
			foreach (SquareFoundation s in squares) {
				if (s.containsPoint (corner))
					return false;
			}
		}
		return true;

	}

	#endregion
				
}
