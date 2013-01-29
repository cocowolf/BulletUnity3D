using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BulletCSharp;

[AddComponentMenu("BulletPhysics/BCollisionShape")]
public class BCollisionShape : MonoBehaviour {
	

	public enum CollisionShapeType
	{
		// dynamic
		BoxShape = 0,
		SphereShape = 1,
		CapsuleShape = 2,
		CylinderShape = 3,
		ConeShape = 4,
		ConvexHull = 5,
		CompoundShape = 6,
		
		// static
		BvhTriangleMeshShape = 7,
		StaticPlaneShape = 8, 
	};
	
	private MeshFilter meshFilter = null;
	private MeshRenderer meshRender = null;
	
	private SWIGTYPE_p_btCollisionShape collisionShapePtr = null;	
	public CollisionShapeType ShapeType = CollisionShapeType.BoxShape;
    private bool bDebugDrawOnOff = true;
	
	// box shape
	private btBoxShape  boxShape = null;
	public Vector3 BoxShapeVec = new Vector3(0.5f,0.5f,0.5f);
	
	//sphere shape
	private btSphereShape sphereShape = null;
	public float SphereShapeRadius = 0.5f;
	
	//capsule shape
	private btCapsuleShape capsuleShape = null;
	public float CapsuleRadius = 0.5f;
	public float CapsuleHeight = 1.0f;
	
	//cylinder shape
	private btCylinderShape cylinderShape = null;
	public float CylinderRadius = 0.5f;
	public float CylinderHeight = 1.0f;
 
	//cone shape
	private btConeShape coneShape = null;
	public float ConeRadius = 0.5f;
	public float ConeHeight = 1.0f; 
	
	//ConvexHull
	private btConvexHullShape convexHull = null;
	private btPolyhedralConvexShape convexPolyhedral = null;
	//CompoundShape
	private btCompoundShape compoundShape = null;
	public BCollisionShape[] CollisionShapeArray = null;
	
	//btBvhTriangleMeshShape
	private btBvhTriangleMeshShape bvhTriangleMeshShape = null;
	private btTriangleIndexVertexArray triangleArray = null;
	private float[] meshVertexArray = null;  // the two must be save,for gabage collection!!!, bullet just copy pointer 
	private int[]  meshIndexArray = null;
	
	//static plane
	private btStaticPlaneShape staticPlaneShape = null;
	public Vector3 StaticPlaneNormal = new Vector3(0,1,0);
	public float StaticPlaneConstant = 1.0f;
	
	public void SetDebugDraw(bool bOnOff)
	{
		bDebugDrawOnOff = bOnOff;
	}
	
	void OnDrawGizmos() 
	{
		if( bDebugDrawOnOff )
	        DebugDraw(transform.position,transform.rotation,transform.localScale,Color.gray); // no rigidbody related to it ,so draw itself..	
	}
	public void DebugDraw(Vector3 position,Quaternion rotation,Vector3 scale, Color color)
	{
		if( collisionShapePtr == null ) // on editor..
		{
			if( ShapeType == CollisionShapeType.BoxShape )
			{
				BUtility.DebugDrawBox(position,rotation,scale,BoxShapeVec,color);
			}
			else if( ShapeType == CollisionShapeType.SphereShape)
			{
				Gizmos.color = color;
				float maxFactor = Mathf.Max(scale.x,scale.y);
			    maxFactor = Mathf.Max(scale.z,maxFactor);
				Gizmos.DrawWireSphere(position,SphereShapeRadius*maxFactor);
			}
			else if( ShapeType == CollisionShapeType.CapsuleShape)
			{			
				float maxFactor = Mathf.Max(scale.x,scale.z);
				BUtility.DebugDrawCapsule(position,rotation,scale,CapsuleRadius*maxFactor,CapsuleHeight*scale.y/2,1,color);
			}
			else if( ShapeType == CollisionShapeType.CylinderShape )
			{
				float maxFactor = Mathf.Max(scale.x,scale.z);
				BUtility.DebugDrawCylinder(position,rotation,scale,CylinderRadius*maxFactor,CylinderHeight*scale.y,1,color);
			}
			else if( ShapeType == CollisionShapeType.ConeShape )
			{
				float maxFactor = Mathf.Max(scale.x,scale.z);
				BUtility.DebugDrawCone(position,rotation,scale,ConeRadius*maxFactor,ConeHeight*scale.y,1,color);
			}
			else if( ShapeType == CollisionShapeType.CompoundShape )
			{
				if( CollisionShapeArray != null && CollisionShapeArray.Length > 0)
				{
					foreach( BCollisionShape shape in CollisionShapeArray )
					{
						if( shape == null )
							continue;
						Matrix4x4 localMatrix = Matrix4x4.TRS(shape.transform.localPosition,Quaternion.identity,Vector3.one);
						scale.Scale(shape.transform.localScale);
						shape.DebugDraw(localMatrix.MultiplyPoint(position),rotation * shape.transform.localRotation,scale,color);
					}
				}
			}
			else if( ShapeType == CollisionShapeType.StaticPlaneShape )
			{
				BUtility.DebugDrawPlane(position,rotation,scale,StaticPlaneNormal,StaticPlaneConstant,color);
			}
			
		}
		else  // on game running...
		{
			if( ShapeType == CollisionShapeType.BoxShape )
			{
				btVector3 vec = btVector3.GetObjectFromSwigPtr(boxShape.getHalfExtentsWithMargin());
				Vector3 v = new Vector3(vec.x()/scale.x,vec.y()/scale.y,vec.z()/scale.z);
				BUtility.DebugDrawBox(position,rotation,scale,v,color);
			}
			else if( ShapeType == CollisionShapeType.SphereShape)
			{
				Gizmos.color = color;
				float radius = sphereShape.getMargin();
				Gizmos.DrawWireSphere(position,radius);
			}
			else if( ShapeType == CollisionShapeType.CapsuleShape )
			{
                float radius = capsuleShape.getRadius();
                float halfHeight = capsuleShape.getHalfHeight();              
				BUtility.DebugDrawCapsule(position,rotation,scale,radius,halfHeight,1,color);
			}
			else if( ShapeType == CollisionShapeType.CylinderShape )
			{
				float radius = cylinderShape.getRadius();
				btVector3 vec = btVector3.GetObjectFromSwigPtr(cylinderShape.getHalfExtentsWithMargin());
                float halfHeight = vec.y();
				BUtility.DebugDrawCylinder(position,rotation,scale,radius,halfHeight,1,color);
			}
			else if ( ShapeType == CollisionShapeType.ConeShape )
			{
				float radius = coneShape.getRadius();
                float height = coneShape.getHeight();
				BUtility.DebugDrawCone(position,rotation,scale,radius,height,1,color);
			}
			else if ( ShapeType == CollisionShapeType.CompoundShape )
			{
				if( CollisionShapeArray != null && CollisionShapeArray.Length > 0)
				{
					foreach( BCollisionShape shape in CollisionShapeArray )
					{
						if( shape == null )
							continue;
						Matrix4x4 localMatrix = Matrix4x4.TRS(shape.transform.localPosition,Quaternion.identity,Vector3.one);
						scale.Scale(shape.transform.localScale);
						shape.DebugDraw(localMatrix.MultiplyPoint(position),rotation * shape.transform.localRotation,scale,color);
					}
				}
			}
			else if( ShapeType == CollisionShapeType.ConvexHull )
			{
				//BUtility.DebugDrawPolyhedron(position,rotation,scale,convexPolyhedral,color);
			}
			else if( ShapeType == CollisionShapeType.StaticPlaneShape )
			{
				float planeConst = staticPlaneShape.getPlaneConstant();
                btVector3 planeNormal = btVector3.GetObjectFromSwigPtr(staticPlaneShape.getPlaneNormal());
				Vector3 vec = new Vector3(planeNormal.x(),planeNormal.y(),planeNormal.z());
				BUtility.DebugDrawPlane(position,rotation,scale,vec,planeConst,color);
			}
			
		}
	}
	
	public bool OnBulletCreate()
	{
		if( collisionShapePtr != null ) // can't be created multi-times
			return true;
		
		if( ShapeType == CollisionShapeType.BoxShape)
		{
			btVector3 vec = new btVector3(BoxShapeVec.x*transform.localScale.x,BoxShapeVec.y*transform.localScale.y,BoxShapeVec.z*transform.localScale.z);
            boxShape = new btBoxShape(vec.GetSwigPtr());
			collisionShapePtr = boxShape.GetSwigPtr();
		}
		else if( ShapeType == CollisionShapeType.SphereShape)
		{
			float maxFactor = Mathf.Max(transform.localScale.x,transform.localScale.y);
			maxFactor = Mathf.Max(transform.localScale.z,maxFactor);
			sphereShape = new btSphereShape(SphereShapeRadius*maxFactor);
			collisionShapePtr = sphereShape.GetSwigPtr();
		}
		else if( ShapeType == CollisionShapeType.CapsuleShape)
		{
			float maxFactor = Mathf.Max(transform.localScale.x,transform.localScale.z);
			
			capsuleShape = new btCapsuleShape(CapsuleRadius*maxFactor,CapsuleHeight*transform.localScale.y);
			collisionShapePtr = capsuleShape.GetSwigPtr();
		}
		else if( ShapeType == CollisionShapeType.CylinderShape)
		{
			float maxFactor = Mathf.Max(transform.localScale.x,transform.localScale.z);
			btVector3 vec = new btVector3(CylinderRadius*maxFactor,CylinderHeight*transform.localScale.y,CylinderRadius*maxFactor);
			cylinderShape = new btCylinderShape(vec.GetSwigPtr());
			collisionShapePtr = cylinderShape.GetSwigPtr();
		}
		else if( ShapeType == CollisionShapeType.ConeShape)
		{
			float maxFactor = Mathf.Max(transform.localScale.x,transform.localScale.z);
			coneShape = new btConeShape(ConeRadius*maxFactor,ConeHeight*transform.localScale.y);
			collisionShapePtr = coneShape.GetSwigPtr();
		}
		else if( ShapeType == CollisionShapeType.ConvexHull )
		{
			if(CheckUnityMesh() == false)
				return false;
			
			List<float> vertexposList = new List<float>();
		 
			for(int index=0;index<meshFilter.mesh.vertexCount;index++)
			{
				Vector3 vec = meshFilter.mesh.vertices[index];
				vertexposList.Add(vec.x);
				vertexposList.Add(vec.y);
				vertexposList.Add(vec.z);
			}
			
			convexHull = new btConvexHullShape(vertexposList.ToArray(),meshFilter.mesh.vertexCount,3*sizeof(float));
			convexPolyhedral = convexHull.GetPolihedralConvexShape();
			//convexPolyhedral.initializePolyhedralFeatures();
			collisionShapePtr = convexHull.GetSwigPtr();
			
		}
		else if( ShapeType == CollisionShapeType.CompoundShape )
		{
			// use all its children's collision shapes to create itself...
			if( CollisionShapeArray == null || CollisionShapeArray.Length == 0 )
			{
				Debug.Log("There is no child collision shapes to use CompoundShape!");
				return false;
			}
			
			compoundShape = new btCompoundShape();
			
			for( int i=0;i<CollisionShapeArray.Length;i++)
			{
				if( CollisionShapeArray[i] == null )
					continue;
				
				if( CollisionShapeArray[i].gameObject == gameObject )
					continue;
				
				bool result = CollisionShapeArray[i].OnBulletCreate();
				if( result == false )
				{
					Debug.Log(" Bullet Collision Create Error!");
					return false;
				}

				Transform t = CollisionShapeArray[i].transform;
			    Matrix4x4 objMatrix = Matrix4x4.TRS(t.localPosition,t.localRotation,t.localScale);
			 
				btVector3 pos = new btVector3(t.localPosition.x,t.localPosition.y,t.localPosition.z);
				btQuaternion rot = new btQuaternion(t.localRotation.x,t.localRotation.y,t.localRotation.z,t.localRotation.w);
 
				btTransform trans = new btTransform(rot,pos);
	 
				compoundShape.addChildShape(trans.GetSwigPtr(),CollisionShapeArray[i].GetCollisionShapePtr());
			}
			
			collisionShapePtr = compoundShape.GetSwigPtr();
			
		}
		else if( ShapeType == CollisionShapeType.BvhTriangleMeshShape )
		{
			if(CheckUnityMesh() == false)
				return false;
			List<float> verList = new List<float>();
			for(int index=0;index<meshFilter.mesh.vertexCount;index++)
			{
				Vector3 vec = meshFilter.mesh.vertices[index];
			    //vec = transform.TransformPoint(vec);
				verList.Add(vec.x);
				verList.Add(vec.y);
				verList.Add(vec.z);
			}
			
			meshVertexArray = verList.ToArray();
			
			List<int> indexList = new List<int>();
			// Unity3D counter clock-wise to Bullet's clock wise.
			for( int i=0;i< meshFilter.mesh.triangles.Length;i+=3)
			{
				indexList.Add(meshFilter.mesh.triangles[i]);
				indexList.Add(meshFilter.mesh.triangles[i+2]);
				indexList.Add(meshFilter.mesh.triangles[i+1]);
			}
			
			meshIndexArray = indexList.ToArray();
			
			triangleArray = new btTriangleIndexVertexArray(indexList.Count/3,meshIndexArray,3*sizeof(int),
				                                                                      meshFilter.mesh.vertexCount,meshVertexArray,3*sizeof(float));
			bvhTriangleMeshShape = new btBvhTriangleMeshShape(triangleArray.GetSwigPtr(),true);
			collisionShapePtr = bvhTriangleMeshShape.GetSwigPtr();
		}
		else if( ShapeType == CollisionShapeType.StaticPlaneShape)
		{
			btVector3 vec = new btVector3(StaticPlaneNormal.x,StaticPlaneNormal.y,StaticPlaneNormal.z);
			staticPlaneShape = new btStaticPlaneShape(vec.GetSwigPtr(),StaticPlaneConstant);
			collisionShapePtr = staticPlaneShape.GetSwigPtr();
		}
		
		return true;
	}
	
    bool CheckUnityMesh()
	{
		meshFilter = gameObject.GetComponent<MeshFilter>();
		if( meshFilter == null || meshFilter.mesh == null)
		{
			Debug.LogError("Need a Convex Mesh to Create ConvexHull!");
			return false;
		}
		
		meshRender = gameObject.GetComponent<MeshRenderer>();
		if( meshRender == null )
		{
			meshRender = gameObject.AddComponent("MeshRenderer") as MeshRenderer;
		}
		
		return true;
	}
			
	public void CalculateLocalInertia(float mass,btVector3 intertiaVec)
	{
		if( ShapeType == CollisionShapeType.BoxShape && boxShape != null)
		{
			 boxShape.calculateLocalInertia(mass,intertiaVec.GetSwigPtr());
		}
		else if( ShapeType == CollisionShapeType.SphereShape && sphereShape != null)
		{
			sphereShape.calculateLocalInertia(mass,intertiaVec.GetSwigPtr());
		}
		else if( ShapeType == CollisionShapeType.CapsuleShape && capsuleShape != null)
		{
			capsuleShape.calculateLocalInertia(mass,intertiaVec.GetSwigPtr());
		}
		else if( ShapeType == CollisionShapeType.CylinderShape && cylinderShape != null)
		{
			cylinderShape.calculateLocalInertia(mass,intertiaVec.GetSwigPtr());
		}
		else if( ShapeType == CollisionShapeType.ConeShape && coneShape != null)
		{
			coneShape.calculateLocalInertia(mass,intertiaVec.GetSwigPtr());
		}
		else if( ShapeType == CollisionShapeType.ConvexHull && convexPolyhedral != null )
		{
			convexPolyhedral.calculateLocalInertia(mass,intertiaVec.GetSwigPtr());
		}
		else if( ShapeType == CollisionShapeType.CompoundShape && compoundShape != null )
		{
			compoundShape.calculateLocalInertia(mass,intertiaVec.GetSwigPtr());
		}
		else if( ShapeType == CollisionShapeType.StaticPlaneShape && staticPlaneShape != null)
		{
			staticPlaneShape.calculateLocalInertia(mass,intertiaVec.GetSwigPtr());
		}
	}
	
	public SWIGTYPE_p_btCollisionShape GetCollisionShapePtr()
	{
		return collisionShapePtr;
	}
	
	public bool OnBulletExit()
	{
		return true;
	}
}
