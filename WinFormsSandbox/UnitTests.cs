#if DEBUG
using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WinFormsSandbox
{
    /// <summary>
    /// Provides unit tests for mainly C# code generating functions.
    /// Note, this class does not compile into the release build.
    /// </summary>
    [TestClass]
    public class UnitTests
    {
        /// <summary>
        /// Tests the GetPropertySignature method on properties having various modifiers.
        /// </summary>
        [TestMethod]
        public void ValidatePropertySig()
        {
            const BindingFlags FLAGS = BindingFlags.NonPublic | BindingFlags.Public
                | BindingFlags.Static | BindingFlags.Instance;

            PropertyInfo[] properties = GetType().GetProperties(FLAGS);

            PropertyInfo property = properties.First(p => p.Name == nameof(TestProp1));
            string val = CSharpSourceGen.GetPropertySignature(property, true);
            Assert.AreEqual(val, "private System.Int32 TestProp1 { get; set; }", val);

            property = properties.First(p => p.Name == nameof(TestProp2));
            val = CSharpSourceGen.GetPropertySignature(property, true);
            Assert.AreEqual(val, "protected System.Int32 TestProp2 { get; set; }", val);

            property = properties.First(p => p.Name == nameof(TestProp3));
            val = CSharpSourceGen.GetPropertySignature(property, true);
            Assert.AreEqual(val, "protected internal System.Int32 TestProp3 { get; set; }", val);

            property = properties.First(p => p.Name == nameof(TestProp4));
            val = CSharpSourceGen.GetPropertySignature(property, true);
            Assert.AreEqual(val, "internal System.Int32 TestProp4 { get; set; }", val);

            property = properties.First(p => p.Name == nameof(TestProp5));
            val = CSharpSourceGen.GetPropertySignature(property, true);
            Assert.AreEqual(val, "public System.Int32 TestProp5 { get; set; }", val);

            property = properties.First(p => p.Name == nameof(TestProp6));
            val = CSharpSourceGen.GetPropertySignature(property, true);
            Assert.AreEqual(val, "public System.Int32 TestProp6 { private get; set; }", val);

            property = properties.First(p => p.Name == nameof(TestProp7));
            val = CSharpSourceGen.GetPropertySignature(property, true);
            Assert.AreEqual(val, "public System.Int32 TestProp7 { get; private set; }", val);

            property = properties.First(p => p.Name == nameof(TestProp8));
            val = CSharpSourceGen.GetPropertySignature(property, true);
            Assert.AreEqual(val, "public System.Int32 TestProp8 { get; protected internal set; }", val);
        }

        /// <summary>
        /// Tests the CSharpSourceGen.GetTypeName method with "fullyQualified" set to true.
        /// </summary>
        [TestMethod]
        public void ValidateFullTypeName()
        {
            string val = CSharpSourceGen.GetTypeName(typeof(MyClass5), true);
            Assert.AreEqual(val, "WinFormsSandbox.UnitTests.MyClass5", val);

            val = CSharpSourceGen.GetTypeName(typeof(Action<Type, Type>), true);
            Assert.AreEqual(val, "System.Action<System.Type, System.Type>", val);

            val = CSharpSourceGen.GetTypeName(typeof(Action<Type>), true);
            Assert.AreEqual(val, "System.Action<System.Type>", val);

            val = CSharpSourceGen.GetTypeName(typeof(Assert), true);
            Assert.AreEqual(val, "Microsoft.VisualStudio.TestTools.UnitTesting.Assert", val);
        }

        /// <summary>
        /// Tests the CSharpSourceGen.GetTypeName method with "fullyQualified" set to false.
        /// </summary>
        [TestMethod]
        public void ValidateTypeName()
        {
            string val = CSharpSourceGen.GetTypeName(typeof(MyClass5), false);
            Assert.AreEqual(val, "MyClass5", val);

            val = CSharpSourceGen.GetTypeName(typeof(Action<Type, Type>), false);
            Assert.AreEqual(val, "Action<Type, Type>", val);

            val = CSharpSourceGen.GetTypeName(typeof(Action<Type>), false);
            Assert.AreEqual(val, "Action<Type>", val);

            val = CSharpSourceGen.GetTypeName(typeof(Assert), false);
            Assert.AreEqual(val, "Assert", val);
        }

        /// <summary>
        /// Tests the GetTypeSignature method's ability to work with internal Types.
        /// </summary>
        [TestMethod]
        public void ValidateInternalTypeSig()
        {
            // Namespace scope.
            string val = CSharpSourceGen.GetTypeSignature(typeof(MyClass5), false);
            Assert.AreEqual(val, "internal class MyClass5", val);
            // Embedded.
            val = CSharpSourceGen.GetTypeSignature(typeof(MyClass1), false);
            Assert.AreEqual(val, "internal class MyClass1", val);
        }

        /// <summary>
        /// Tests the GetTypeSignature method's ability to work with private Types.
        /// </summary>
        [TestMethod]
        public void ValidatePrivateTypeSig()
        {
            string val = CSharpSourceGen.GetTypeSignature(typeof(MyClass2), false);
            Assert.AreEqual(val, "private class MyClass2", val);
        }

        /// <summary>
        /// Tests the GetTypeSignature method's ability to work with public Types.
        /// </summary>
        [TestMethod]
        public void ValidatePublicTypeSig()
        {
            // Namespace scope.
            string val = CSharpSourceGen.GetTypeSignature(typeof(MyClass6), false);
            Assert.AreEqual(val, "public class MyClass6", val);
            // Embedded.
            val = CSharpSourceGen.GetTypeSignature(typeof(MyClass3), false);
            Assert.AreEqual(val, "public class MyClass3", val);
        }

        /// <summary>
        /// Tests the GetTypeSignature method's ability to work with Types with generic arguments.
        /// or parameters.
        /// </summary>
        [TestMethod]
        public void ValidateGenericTypeSig()
        {
            // Embedded scope, two type params.
            string val = CSharpSourceGen.GetTypeSignature(typeof(MyClass4<string, string>), false);
            Assert.AreEqual(val, "internal class MyClass4<string, string>", val);
            // Namespace scope, one type param.
            val = CSharpSourceGen.GetTypeSignature(typeof(MyClass7<Type>), false);
            Assert.AreEqual(val, "internal class MyClass7<Type>", val);
        }

        /// <summary>
        /// Tests the GetTypeSignature method's ability to work with sealed and abstract Types.
        /// or parameters.
        /// </summary>
        [TestMethod]
        public void ValidateSealedAndAbstractTypeSig()
        {
            string val = CSharpSourceGen.GetTypeSignature(typeof(MyClass8), false);
            Assert.AreEqual(val, "public sealed class MyClass8", val);

            val = CSharpSourceGen.GetTypeSignature(typeof(MyClass9), false);
            Assert.AreEqual(val, "public abstract class MyClass9", val);
        }

        /// <summary>
        /// Tests the GetTypeSignature method's ability to work with value Types.
        /// </summary>
        [TestMethod]
        public void ValidateStructTypeSig()
        {
            string val = CSharpSourceGen.GetTypeSignature(typeof(MyStruct1), false);
            Assert.AreEqual(val, "internal struct MyStruct1", val);

            val = CSharpSourceGen.GetTypeSignature(typeof(MyStruct2), false);
            Assert.AreEqual(val, "public struct MyStruct2", val);
        }

        /// <summary>
        /// Tests the GetTypeSignature method's ability to work with derived Types.
        /// </summary>
        [TestMethod]
        public void ValidateDerivingTypeSig()
        {
            string val = CSharpSourceGen.GetTypeSignature(typeof(MyClass11), false);
            Assert.AreEqual(val, "public class MyClass11 : MyClass9", val);

            val = CSharpSourceGen.GetTypeSignature(typeof(MyClass11), true);
            Assert.AreEqual(val, "public class MyClass11 : WinFormsSandbox.UnitTests.MyClass9", val);

            val = CSharpSourceGen.GetTypeSignature(typeof(MyClass12), false);
            Assert.AreEqual(val, "internal class MyClass12 : MyClass7<string>", val);
        }


        /// <summary>
        /// Tests the GetMethodSignature method's ability to work with static methods.
        /// </summary>
        [TestMethod]
        public void ValidateStaticTypeSig()
        {
            Type dummyMethodsType = typeof(DummyMethods);
            const BindingFlags STATIC = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

            var method = dummyMethodsType.GetMethod("TestMethodPrivateStatic1", STATIC);
            var val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "private static void TestMethodPrivateStatic1()", val);

            method = dummyMethodsType.GetMethod("TestMethodPublicStatic2", STATIC);
            val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "public static void TestMethodPublicStatic2()", val);

            method = dummyMethodsType.GetMethod("TestMethodInternalStatic3", STATIC);
            val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "internal static void TestMethodInternalStatic3()", val);

            method = dummyMethodsType.GetMethod("TestMethodProtectedStatic4", STATIC);
            val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "protected static void TestMethodProtectedStatic4()", val);

            method = dummyMethodsType.GetMethod("TestMethodProtectedInternalStatic5", STATIC);
            val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "protected internal static void TestMethodProtectedInternalStatic5()", val);
        }

        /// <summary>
        /// Tests the GetMethodSignature method's ability to work with instance methods.
        /// </summary>
        [TestMethod]
        public void ValidateInstanceMethodSig()
        {
            const BindingFlags NON_STATIC = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            Type dummyMethodsType = typeof(DummyMethods);
            // Private
            var method = dummyMethodsType.GetMethod("TestMethodPrivate6", NON_STATIC);
            var val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "private void TestMethodPrivate6()", val);
            // Public
            method = dummyMethodsType.GetMethod("TestMethodPublic7", NON_STATIC);
            val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "public void TestMethodPublic7()", val);
            // Internal
            method = dummyMethodsType.GetMethod("TestMethodInternal8", NON_STATIC);
            val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "internal void TestMethodInternal8()", val);
            // Protected
            method = dummyMethodsType.GetMethod("TestMethodProtected9", NON_STATIC);
            val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "protected void TestMethodProtected9()", val);
            // protected Internal
            method = dummyMethodsType.GetMethod("TestMethodProtectedInternal10", NON_STATIC);
            val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "protected internal void TestMethodProtectedInternal10()", val);
            // protected Virtual
            method = dummyMethodsType.GetMethod("TestMethodProtectedVirtual11", NON_STATIC);
            val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "protected virtual void TestMethodProtectedVirtual11()", val);
            // protected Abstract
            method = typeof(DummyMethods2).GetMethod("TestMethodProtectedAbstract12", NON_STATIC);
            val = CSharpSourceGen.GetMethodSignature(method, false);
            Assert.AreEqual(val, "protected abstract void TestMethodProtectedAbstract12()", val);
        }

        /// <summary>
        /// Tests GetStatic extension method.
        /// </summary>
        [TestMethod]
        public void IsStaticReturnCheck()
        {
            Assert.IsTrue(typeof(MyClass10).IsStatic());
            Assert.IsFalse(typeof(MyClass9).IsStatic());
            Assert.IsFalse(typeof(MyClass5).IsStatic());
        }

#pragma warning disable 1591
        // Here are the dummy Types, methods, and properties to test. Occasionally
        // cut and paste some of them to namespace scope and test them there.

        internal class MyClass1 { }
        private class MyClass2 { }
        public class MyClass3 { }
        internal class MyClass4<T, T2> where T : class { }
        internal class MyClass5 { }
        public class MyClass6 { }
        internal class MyClass7<T> where T : class { }
        public sealed class MyClass8 { }
        public abstract class MyClass9 { }
        public static class MyClass10 { }
        public class MyClass11 : MyClass9 { }
        internal class MyClass12 : MyClass7<string> { }
        internal struct MyStruct1 { }
        public struct MyStruct2 { }

        private int TestProp1 { get; set; }
        protected int TestProp2 { get; set; }
        protected internal int TestProp3 { get; set; }
        internal int TestProp4 { get; set; }
        public int TestProp5 { get; set; }
        public int TestProp6 { private get; set; }
        public int TestProp7 { get; private set; }
        public int TestProp8 { get; protected internal set; }

        class DummyMethods
        {
            private static void TestMethodPrivateStatic1() { }
            public static void TestMethodPublicStatic2() { }
            internal static void TestMethodInternalStatic3() { }
            protected static void TestMethodProtectedStatic4() { }
            protected internal static void TestMethodProtectedInternalStatic5() { }
            private void TestMethodPrivate6() { }
            public void TestMethodPublic7() { }
            internal void TestMethodInternal8() { }
            protected void TestMethodProtected9() { }
            protected internal void TestMethodProtectedInternal10() { }
            protected virtual void TestMethodProtectedVirtual11() { }
        }

        abstract class DummyMethods2
        {
            protected abstract void TestMethodProtectedAbstract12();
        }
#pragma warning restore 1591
    }
}
#endif