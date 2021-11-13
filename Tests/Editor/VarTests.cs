using NUnit.Framework;
using UnityEngine;

namespace N8.Utils.SOA.Tests.Editor
{
	using Vars;
	
	public class VarTests
	{
		/*
		[Test]
		public void New_Empty()
		{
			Var<Vector3> __vector3Var = Var<Vector3>.New();
		    
			Assert.AreEqual(
				expected: Vector3.zero, 
				actual: __vector3Var.Value);
		    
			Assert.AreNotEqual(
				expected: Vector3.one, 
				actual: __vector3Var.Value);
		}

		[Test]
		public void New_T()
		{
			Var<Vector3> __vector3Var = Var<Vector3>.New(val: Vector3.one);
		    
			Assert.AreEqual(
				expected: Vector3.one, 
				actual: __vector3Var.Value);
		    
			Assert.AreNotEqual(
				expected: Vector3.zero, 
				actual: __vector3Var.Value);
		}
		*/
		
		[Test]
		public void New_Empty()
		{
			Vector3Var __vector3Var = Vector3Var.New();
            
			Assert.AreEqual(
				expected: Vector3.zero, 
				actual: __vector3Var.Value);
            
			Assert.AreNotEqual(
				expected: Vector3.one, 
				actual: __vector3Var.Value);
		}
        
		[Test]
		public void New_T()
		{
			Vector3Var __vector3Var = Vector3Var.New(val: Vector3.one);
            
			Assert.AreEqual(
				expected: Vector3.one, 
				actual: __vector3Var.Value);
            
			Assert.AreNotEqual(
				expected: Vector3.zero, 
				actual: __vector3Var.Value);
		}
	}
}