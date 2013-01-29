using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BRigidBody))]
public class BRigidBodyEditor : Editor {

	private SerializedObject serObj;
    
 
	public void OnEnable () 
	{
		serObj = new SerializedObject (target); 
	}
	
	 
}
