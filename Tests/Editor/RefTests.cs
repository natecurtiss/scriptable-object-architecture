using NUnit.Framework;
using UnityEngine;

namespace N8.Utils.SOA.Tests.Editor
{
    using Refs;
    
    public class RefTests
    {
        [Test]
        public void Constructor_Empty()
        {
            Vector3Ref __vector3Ref = new Vector3Ref();
            
            Assert.AreEqual(
                expected: Vector3.zero, 
                actual: __vector3Ref.Value);
            
            Assert.AreNotEqual(
                expected: Vector3.one, 
                actual: __vector3Ref.Value);
        }
        
        [Test]
        public void Constructor_T()
        {
            Vector3Ref __vector3Ref = new Vector3Ref(val: Vector3.one);
            
            Assert.AreEqual(
                expected: Vector3.one, 
                actual: __vector3Ref.Value);
            
            Assert.AreNotEqual(
                expected: Vector3.zero, 
                actual: __vector3Ref.Value);
        }
        
        [Test]
        public void Constructor_TVal()
        {
            // Use the Assert class to test conditions
        }
    }
}
