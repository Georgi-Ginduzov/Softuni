//Device Manager
using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using DataCenter;

[TestFixture]
public class Test_000_113
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void Validate_Rack_DeviceManager()
    {
        var server1Arguments = new object[] { "SN001", "Dell PowerEdge T340", 100, 450 };
        var server1 = CreateObjectInstance(GetType("Server"), server1Arguments);

        var server2Arguments = new object[] { "SN002", "HPE Synergy 480 Gen10", 200, 650 };
        var server2 = CreateObjectInstance(GetType("Server"), server2Arguments);

        var server3Arguments = new object[] { "SN003", "Cisco UCS B200 M5", 383, 550 };
        var server3 = CreateObjectInstance(GetType("Server"), server3Arguments);

        var rackArguments = new object[] { 3 };
        var rack = CreateObjectInstance(GetType("Rack"), rackArguments);

        InvokeMethod(rack, "AddServer", new object[] { server1 });
        InvokeMethod(rack, "AddServer", new object[] { server2 });
        InvokeMethod(rack, "AddServer", new object[] { server3 });

        string actualResult = (string)InvokeMethod(rack, "DeviceManager", null);
        string expectedResult =
            $"3 servers operating:{Environment.NewLine}Server SN001: Dell PowerEdge T340, 100TB, 450W{Environment.NewLine}Server SN002: HPE Synergy 480 Gen10, 200TB, 650W{Environment.NewLine}Server SN003: Cisco UCS B200 M5, 383TB, 550W";

        Assert.That(expectedResult, Is.EqualTo(actualResult));
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