using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        // Resource Tests
        [Test]
        public void ResourceConstructorShouldSetNameAndResourceType()
        {
            string name = "Resource";
            string resourceType = "Document";

            Resource resource = new Resource(name, resourceType);

            Assert.AreEqual(name, resource.Name);
            Assert.AreEqual(resourceType, resource.ResourceType);
        }

        [Test]
        public void ResourceNameShouldBeSettable()
        {
            string name = "Resource";
            string resourceType = "Document";

            Resource resource = new Resource(name, resourceType);

            string newName = "New Resource Name";
            resource.Name = newName;

            Assert.AreEqual(newName, resource.Name);
        }

        [Test]
        public void ResourceTypeShouldBeSettable()
        {
            string name = "Resource";
            string resourceType = "Document";

            Resource resource = new Resource(name, resourceType);

            string newResourceType = "Image";
            resource.ResourceType = newResourceType;

            Assert.AreEqual(newResourceType, resource.ResourceType);
        }


        [Test]
        public void ResourceIsTestedDefaultValueShouldBeFalse()
        {
            string name = "Resource";
            string resourceType = "Document";

            Resource resource = new Resource(name, resourceType);

            Assert.False(resource.IsTested);
        }

        [Test]
        public void ResourceIsTestedCouldBeSetToTrue()
        {
            string name = "Resource";
            string resourceType = "Document";
            Resource resource = new Resource(name, resourceType);

            resource.IsTested = true;

            Assert.True(resource.IsTested);
        }

        // Task Tests ------------------------------------------------- Task Tests
        [Test]
        public void TaskConstructorSetsPriorityLabelAndResourceName()
        {
            int priority = 1;
            string label = "Task";
            string resourceName = "Resource";

            Task task = new Task(priority, label, resourceName);

            // Assert
            Assert.AreEqual(priority, task.Priority);
            Assert.AreEqual(label, task.Label);
            Assert.AreEqual(resourceName, task.ResourceName);
        }

        [Test]
        public void TaskPriorityShouldBeSettable()
        {
            int priority = 1;
            string label = "Task";
            string resourceName = "Resource";
            Task task = new Task(priority, label, resourceName);

            task.Priority = 2;

            Assert.AreEqual(2, task.Priority);
        }

        [Test]
        public void TaskLabelShouldBeSettable()
        {
            int priority = 1;
            string label = "Task";
            string resourceName = "Resource";
            Task task = new Task(priority, label, resourceName);

            task.Label = "Updated Task";

            Assert.AreEqual("Updated Task", task.Label);
        }

        [Test]
        public void TaskResourceNameShouldBeSettable()
        {
            int priority = 1;
            string label = "Task";
            string resourceName = "Resource";
            Task task = new Task(priority, label, resourceName);

            task.ResourceName = "Resource2";

            Assert.AreEqual("Resource2", task.ResourceName);
        }

        // ResourceCloud Tests ------------------------------------------------- ResourceCloud Tests
        [Test]
        public void DepartmentCloudShouldInitializeResourcesAndTasksSuccessfully()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();

            Assert.NotNull(departmentCloud.Resources);
            Assert.NotNull(departmentCloud.Tasks);

            Assert.IsEmpty(departmentCloud.Resources);
            Assert.IsEmpty(departmentCloud.Tasks);

            Assert.IsNotAssignableFrom<List<Resource>>(departmentCloud.Resources);
            Assert.IsNotAssignableFrom<List<Task>>(departmentCloud.Tasks);
        }


        [Test]
        public void ShouldLogTaskSuccessfully()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] args = new string[] { "1", "Task", "Resource" };

            string result = departmentCloud.LogTask(args);

            Assert.AreEqual("Task logged successfully.", result);
        }

        [Test]
        public void LogTaskWithNullOrShortArgsThrowsArgumentException()
        {
            DepartmentCloud departmentCloudWithNullArgs = new DepartmentCloud();
            DepartmentCloud departmentCloudWithShortArgs = new DepartmentCloud();
            string[] nullArgs = new string[] { "1", "Task", null };
            string[] shortArgs = new string[] { "1", "Task" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => departmentCloudWithNullArgs.LogTask(nullArgs), "Arguments values cannot be null.");
            Assert.Throws<ArgumentException>(() => departmentCloudWithShortArgs.LogTask(shortArgs), "All arguments are required.");
        }

        [Test]
        public void LogAlreadyLoggedTaskShouldReturnMessage()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] args = new string[] { "1", "Task", "Resourse" };
            Task task = new Task(int.Parse(args[0]), args[1], args[2]);

            departmentCloud.LogTask(args);

            Assert.AreEqual($"{task.ResourceName} is already logged.", departmentCloud.LogTask(args));
        }

        [Test]
        public void CreateResource_WithTask_CreatesResourceSuccessfully()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            departmentCloud.LogTask(new string[] { "1", "Test Task", "Resource1" });

            var result = departmentCloud.CreateResource();

            Assert.True(result);
            Assert.IsEmpty(departmentCloud.Tasks);
        }

        [Test]
        public void CreateResource_WithoutTask_ReturnsFalse()
        {
            var departmentCloud = new DepartmentCloud();

            var result = departmentCloud.CreateResource();

            Assert.False(result);
            Assert.IsEmpty(departmentCloud.Resources);
        }

        [Test]
        public void TestResource_WithExistingResource_TestsResourceSuccessfully()
        {
            var departmentCloud = new DepartmentCloud();
            departmentCloud.LogTask(new string[] { "1", "Test Task", "Resource1" });
            departmentCloud.CreateResource();
            string resourceName = "Resource1";

            var result = departmentCloud.TestResource(resourceName);

            Assert.NotNull(result);
            Assert.True(result.IsTested);
        }

        [Test]
        public void TestResource_WithNonExistingResource_ReturnsNull()
        {
            var departmentCloud = new DepartmentCloud();
            string resourceName = "NonExistingResource";

            var result = departmentCloud.TestResource(resourceName);

            Assert.Null(result);
        }
    }
}