/*
 * Created by SharpDevelop.
 * User: Eric NARA
 * Date: 13/06/2014
 * Time: 11:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace YOT.Test
{
	/// <summary>
	/// Description of TestVerify.
	/// </summary>
	/// 
	[TestFixture]
	public class TestVerify
	{
		/*
		 * 
		 * 
    IsTrue(sut,message="")*
    IsFalse(sut,message="")
    IsNull(sut,message="")
    IsNotNull(sut,message="")
    AreEqual(sut,expected, message="")



*/

		[Test]
		public void ShouldBeTrueWithoutException()
		{
				Verify.IsTrue(true);
				Verify.IsTrue(1==1);
		}
		
		
		[Test]
		[ExpectedException(typeof(FailedException))]
		public void ShouldBeTrueWithException()
		{
			Verify.IsTrue(false);
			Verify.IsTrue(1==2);
		}
		
		
		[Test]
		public void ShouldBeFalseWithoutException()
		{
				Verify.IsFalse(false);
				Verify.IsFalse(1==2);
		}
		
		
		[Test]
		[ExpectedException(typeof(FailedException))]
		public void ShouldBeFalseWithException()
		{
			Verify.IsFalse(true);
			Verify.IsFalse(1==1);
		}
		
		
		[Test]
		public void ShouldBeNullWithoutException()
		{
			object objectNull=null;
			Verify.IsNull(objectNull);
		}
		
		
		[Test]
		[ExpectedException(typeof(FailedException))]
		public void ShouldBeNullWithException()
		{
			Verify.IsNull(1);
			Verify.IsNull("string");
		}
		
		
			
		
		[Test]
		public void ShouldBeNotNullWithoutException()
		{
			Verify.IsNotNull(1);
			Verify.IsNotNull("string");
		}
		
		
		[Test]
		[ExpectedException(typeof(FailedException))]
		public void ShouldBeNotNullWithException()
		{
			object objectNull = null;
			Verify.IsNotNull(objectNull);
		}
		
		
		
		
		
		[Test]
		public void ShouldAreEqualWithoutException()
		{
			Verify.AreEqual(1,1);
			Verify.AreEqual("string", "string");
			Verify.AreEqual(true, true);
		}
		
		
		[Test]
		[ExpectedException(typeof(FailedException))]
		public void ShouldAreEqualWithException()
		{
			Verify.AreEqual(1,2);
			Verify.AreEqual("string", "char");
			Verify.AreEqual(true, false);
		}
		
	}
}
