using System.Data.Common;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string fileName, string[] fieldsToInvestigate)
        {
            Type file = Type.GetType(fileName);

            FieldInfo[] privateFields = file.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            Object classInstance = Activator.CreateInstance(file, new object[] { });

            StringBuilder output = new StringBuilder();
            output.AppendLine($"Class under investigation: {fileName}");
            foreach (FieldInfo field in privateFields.Where(n => fieldsToInvestigate.Contains(n.Name)))
            {
                output.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return output.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type analyzeClass = Type.GetType(className);
            StringBuilder output = new StringBuilder();

            FieldInfo[] classFields = analyzeClass.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in classFields.Where(f => f.IsPublic))
            {
                output.AppendLine($"{field.Name} must be private!");
            }


            PropertyInfo[] classProperties = analyzeClass.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            
            foreach (PropertyInfo accessor in analyzeClass.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (accessor.GetMethod.IsPrivate)
                {
                    output.AppendLine($"{accessor.GetMethod.Name} have to be public!");
                }
            }

            foreach (PropertyInfo accessor in analyzeClass.GetProperties())
            {
                if (accessor.SetMethod.IsPublic)
                {
                    output.AppendLine($"{accessor.SetMethod.Name} have to be private!");
                }
            }

            return output.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            Type analyzeClass = Type.GetType(className);
            Object classInstance = Activator.CreateInstance(analyzeClass, new object[] { });
            StringBuilder output = new StringBuilder();

            foreach (PropertyInfo method in analyzeClass.GetProperties(BindingFlags.NonPublic | BindingFlags.Public |BindingFlags.Instance))
            {
                if (method.DeclaringType.is)
                {

                }
            }


            return output.ToString();
        }
    }
}
