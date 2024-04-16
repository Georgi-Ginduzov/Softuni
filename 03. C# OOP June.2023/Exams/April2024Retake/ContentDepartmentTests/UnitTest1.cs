using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using TheContentDepartment;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

public class Tests_001
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void Validate_ExampleOutput()
    {
        var controller = CreateObjectInstance(GetType("Controller"));

        StringBuilder sb = new StringBuilder();

        var arggumentsArray1 = new object[]
        {
            new object[] { "TeamLead", "YokoYong", "Master" },
            new object[] { "ContentMember", "DaniDavis", "JavaScript" },
            new object[] { "ContentMember", "DaniDavis", "Java" },
            new object[] { "ContentMember", "PeterSully", "Java"  },
            new object[] { "ContentMember", "ValGendor", "Python" },
        };
        foreach (object[] arg in arggumentsArray1)
        {
            var tempResult = InvokeMethod(controller, "JoinTeam", arg);
            sb.AppendLine(tempResult?.ToString()?.Trim());
        }

        var arggumentsArray2 = new object[] { "Presentation", "Inheritance", "CSharp" };
        sb.AppendLine($"{InvokeMethod(controller, "CreateResource", arggumentsArray2)}");

        var arggumentsArray3 = new object[]
        {
            new object[] { "ContentMember", "KrissThompson", "CSharp" },
            new object[] { "TrainingMember", "DenisPeters", "CSharp" },
            new object[] { "ContentMember", "ValGendor", "Java" }
        };
        foreach (object[] arg in arggumentsArray3)
        {
            var tempResult = InvokeMethod(controller, "JoinTeam", arg);
            sb.AppendLine(tempResult?.ToString()?.Trim());
        }

        var arggumentsArray4 = new object[]
        {
            new object[] { "Lab", "LabDocument", "CSharp" },
            new object[] { "Exam", "JavaScriptOOP-Retake", "JavaScript" },
            new object[] { "Workshop", "TicTacToe", "Python" },
            new object[] { "Exam", "JavaScriptOOP-Regular", "JavaScript" },
            new object[] { "Exam", "JavaScriptOOP-Regular", "JavaScript" },
            new object[] { "Exam", "JavaOOP-Regular", "Java"  },
            new object[] { "VideoContent", "WelcomeVideo", "Java" },
            new object[] { "Exam", "JavaOOP-Retake", "Java" },
            new object[] { "WorkShop", "Regex-Exercise", "Python" },
            new object[] { "Presentation", "Inheritance", "CSharp" },
            new object[] { "Exam", "C#OOP-Regular", "CSharp" }
        };
        foreach (object[] arg in arggumentsArray4)
        {
            var tempResult = InvokeMethod(controller, "CreateResource", arg);
            sb.AppendLine(tempResult?.ToString()?.Trim());
        }

        var arggumentsArray5 = new object[]
        {
            new object[] { "DenisPeters"},
            new object[] { "ValGendor"},
            new object[] { "ValGendor" },
            new object[] { "ValGendor" },
            new object[] { "DannyDavis" },
            new object[] { "PeterSully" },
            new object[] { "PeterSully" },
            new object[] { "KrissThompson" }
        };
        foreach (object[] arg in arggumentsArray5)
        {
            var tempResult = InvokeMethod(controller, "LogTesting", arg);
            sb.AppendLine(tempResult?.ToString()?.Trim());
        }

        var arggumentsArray6 = new object[]
        {
            new object[] { "JavaOOP-Regular", true },
            new object[] { "JavaOOP-Retake", false },
            new object[] { "Inheritance", true },
            new object[] { "C#OOP-Regular", true },
            new object[] { "TicTacToe", true },
            new object[] { "JavaScriptOOP-Retake", true }
        };
        foreach (object[] arg in arggumentsArray6)
        {
            var tempResult = InvokeMethod(controller, "ApproveResource", arg);
            sb.AppendLine(tempResult?.ToString()?.Trim());
        }

        sb.AppendLine($"{InvokeMethod(controller, "DepartmentReport", null)}");

        var actualResult = sb.ToString().Trim();

        var expectedResult = "YokoYong has joined the team. Welcome!\r\nDaniDavis has joined the team. Welcome!\r\nDaniDavis has already joined the team.\r\nPeterSully has joined the team. Welcome!\r\nValGendor has joined the team. Welcome!\r\nNo content member is able to create the Inheritance resource.\r\nKrissThompson has joined the team. Welcome!\r\nTrainingMember is not a valid member type.\r\nPosition is occupied.\r\nLab type is not handled by Content Department.\r\nDaniDavis created Exam - JavaScriptOOP-Retake.\r\nValGendor created Workshop - TicTacToe.\r\nDaniDavis created Exam - JavaScriptOOP-Regular.\r\nThe JavaScriptOOP-Regular resource is being created.\r\nPeterSully created Exam - JavaOOP-Regular.\r\nVideoContent type is not handled by Content Department.\r\nPeterSully created Exam - JavaOOP-Retake.\r\nWorkShop type is not handled by Content Department.\r\nKrissThompson created Presentation - Inheritance.\r\nKrissThompson created Exam - C#OOP-Regular.\r\nProvide the correct member name.\r\nTicTacToe is tested and ready for approval.\r\nValGendor has no resources for testing.\r\nValGendor has no resources for testing.\r\nProvide the correct member name.\r\nJavaOOP-Regular is tested and ready for approval.\r\nJavaOOP-Retake is tested and ready for approval.\r\nC#OOP-Regular is tested and ready for approval.\r\nYokoYong approved JavaOOP-Regular.\r\nYokoYong returned JavaOOP-Retake for a re-test.\r\nInheritance cannot be approved without being tested.\r\nYokoYong approved C#OOP-Regular.\r\nYokoYong approved TicTacToe.\r\nJavaScriptOOP-Retake cannot be approved without being tested.\r\nFinished Tasks:\r\n--TicTacToe (Workshop), Created By: ValGendor\r\n--JavaOOP-Regular (Exam), Created By: PeterSully\r\n--C#OOP-Regular (Exam), Created By: KrissThompson\r\nTeam Report:\r\n--YokoYong (TeamLead) - Currently working on 1 tasks.\r\nDaniDavis - JavaScript path. Currently working on 2 tasks.\r\nPeterSully - Java path. Currently working on 0 tasks.\r\nValGendor - Python path. Currently working on 0 tasks.\r\nKrissThompson - CSharp path. Currently working on 1 tasks.";

        Console.WriteLine(actualResult[1720] + actualResult[1721] + actualResult[1722] + actualResult[1723] + actualResult[1724] + actualResult[1725]);
        Console.WriteLine(expectedResult[1720] + expectedResult[1721] + expectedResult[1722] + expectedResult[1723] + expectedResult[1724] + expectedResult[1725]);

        Console.WriteLine("Actual result: " + actualResult);
        Console.WriteLine();
        Console.WriteLine("Expected result: " + expectedResult);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    private static object InvokeMethod(object obj, string methodName, object[] parameters)
    {
        try
        {
            var result = obj?.GetType()?
                .GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance)?
                .Invoke(obj, parameters);

            return result!;
        }
        catch (TargetInvocationException e)
        {
            throw e.InnerException!;
        }
    }

    private static object CreateObjectInstance(Type type, params object[] parameters)
    {
        try
        {
            var desiredConstructor = type.GetConstructors()
                .FirstOrDefault(x => x.GetParameters().Any());

            if (desiredConstructor == null)
            {
                return Activator.CreateInstance(type, parameters);
            }

            var instances = new List<object>();

            foreach (var parameterInfo in desiredConstructor.GetParameters())
            {
                var currentInstance = Activator.CreateInstance(GetType(parameterInfo.Name.Substring(1)));

                instances.Add(currentInstance);
            }

            return Activator.CreateInstance(type, instances.ToArray());
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