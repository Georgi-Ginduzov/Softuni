//Get Report
using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using System.Collections.Generic;
using SharkTaxonomy;
using System.Text;

[TestFixture]
public class Test_000_113
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void Validate_Classifier_GetReport()
    {
        var shark1Arguments = new object[] { "Great White", 5, "Seals", "Open Ocean" };
        var shark1 = CreateObjectInstance(GetType("Shark"), shark1Arguments);
        var shark2Arguments = new object[] { "Hammerhead", 4, "Fish", "Tropical Waters" };
        var shark2 = CreateObjectInstance(GetType("Shark"), shark2Arguments);
        var shark3Arguments = new object[] { "Tiger", 4, "Turtles", "Coral Reefs" };
        var shark3 = CreateObjectInstance(GetType("Shark"), shark3Arguments);

        var classifierArguments = new object[] { 3 };
        var classifier = CreateObjectInstance(GetType("Classifier"), classifierArguments);

        InvokeMethod(classifier, "AddShark", new object[] { shark1 });
        InvokeMethod(classifier, "AddShark", new object[] { shark2 });
        InvokeMethod(classifier, "AddShark", new object[] { shark3 });

        string actualResult = (string)InvokeMethod(classifier, "Report", null);
        string expectedResult =
            $"3 sharks classified:{Environment.NewLine}Great White shark: 5m long.{Environment.NewLine}Could be spotted in the Open Ocean, typical menu: Seals{Environment.NewLine}Hammerhead shark: 4m long.{Environment.NewLine}Could be spotted in the Tropical Waters, typical menu: Fish{Environment.NewLine}Tiger shark: 4m long.{Environment.NewLine}Could be spotted in the Coral Reefs, typical menu: Turtles";
        try
        {
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
        catch (AssertionException)
        {
            Console.WriteLine("Expected result: " + expectedResult);
            Console.WriteLine();
            Console.WriteLine("Actual result: " + actualResult);
            throw;
        }
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