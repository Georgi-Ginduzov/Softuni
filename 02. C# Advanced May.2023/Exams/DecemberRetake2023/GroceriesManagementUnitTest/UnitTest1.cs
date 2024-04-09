using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using System.Collections.Generic;
using GroceriesManagement;
using System.Text;

[TestFixture]
public class Test_001
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void Validate_PriceList_Zero()
    {
        var product1Arguments = new object[] { "Apples", 1.50 };
        var product1 = CreateObjectInstance(GetType("Product"), product1Arguments);
        var product2Arguments = new object[] { "Bananas", 2.50 };
        var product2 = CreateObjectInstance(GetType("Product"), product2Arguments);
        var product3Arguments = new object[] { "Grapes", 3.50 };
        var product3 = CreateObjectInstance(GetType("Product"), product3Arguments);

        var storeArguments = new object[] { 3 };
        var store = CreateObjectInstance(GetType("GroceriesStore"), storeArguments);

        InvokeMethod(store, "AddProduct", new object[] { product1 });
        InvokeMethod(store, "AddProduct", new object[] { product2 });
        InvokeMethod(store, "AddProduct", new object[] { product3 });

        var actualResult = InvokeMethod(store, "PriceList", null);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Groceries Price List:");
        sb.AppendLine("Apples: 1.50$");
        sb.AppendLine("Bananas: 2.50$");
        sb.AppendLine("Grapes: 3.50$");

        var expectedResult = sb.ToString().Trim();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    private static object GetPropertyValue(object obj, string propertyName)
    {
        return obj.GetType().GetProperty(propertyName).GetValue(obj);
    }

    private static object InvokeMethod(object obj, string methodName, object[] parameters)
    {
        try
        {
            var result = obj.GetType()
                .GetMethod(methodName)
                .Invoke(obj, parameters);

            return result;
        }
        catch (TargetInvocationException e)
        {
            return e.InnerException.Message;
        }
    }

    private static object CreateObjectInstance(Type type, params object[] parameters)
    {
        try
        {
            return Activator.CreateInstance(type, parameters);
        }
        catch (TargetInvocationException e)
        {
            return e.InnerException.Message;
        }
    }

    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name.Contains(name));

        return type;
    }
}