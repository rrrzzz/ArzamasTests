using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Security.Permissions;
using NLog;
using NUnit.Framework;
using Tests.Database;

namespace Tests
{
    public static class Measurement
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void RunAndGetTestStats()
        {
            var testsRepository = new TestsRepository();
            var testSuiteRun = new TestSuiteRun { StartTime = DateTime.UtcNow};
            var testAssembly = Assembly.GetCallingAssembly();
            var types = testAssembly.GetTypes().Where(x => x.Name != "TestMeasure" &&
                                                           x.GetCustomAttributes(typeof(TestFixtureAttribute), false).Any());

            foreach (var type in types)
            {
                ExtractAndInvokeTests(type, testSuiteRun);
            }

            testsRepository.Add(testSuiteRun);
        }

        private static void ExtractAndInvokeTests(Type type, TestSuiteRun suiteRun)
        {
            var instance = Activator.CreateInstance(type);
            var methods = type.GetMethods();
            var tearDownMethods = methods.Where(x => x.HasAttribute(typeof(TearDownAttribute))).ToList();
            var setUpMethods = methods.Where(x => x.HasAttribute(typeof(SetUpAttribute))).ToList();
            var testMethods = methods.Where(x => x.HasAttribute(typeof(TestAttribute))).ToList();
            bool hasSetUp = setUpMethods.Any();
            bool hasTear = tearDownMethods.Any();
            foreach (var method in testMethods)
            {
                string testResult = null;
                string testComment = null;
                var watch = Stopwatch.StartNew();
                if (hasSetUp)
                    InvokeMethods(instance, setUpMethods);

                try
                {
                    method.Invoke(instance, null);
                    testResult = "Passed";
                    testComment = "OK";
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException.GetType().Name == "AssertionException")
                    {
                        testResult = "Failed";
                        testComment = ex.InnerException.Message.Trim();
                    }
                    else
                    {
                        testResult = "Error";
                        testComment = ex.InnerException.Message;
                    }
                }
                catch (Exception ex)
                {
                    testResult = "Error";
                    testComment = ex.InnerException.Message;
                }

                if (hasTear)
                    InvokeMethods(instance, tearDownMethods);
                watch.Stop();
                var timeResult = watch.Elapsed;
                logger.Info($"Test: {method.Name}\nfrom Fixture: {type.Name}\nhas run with result: {testResult}; comment: {testComment}" +
                                  $"\nin {timeResult.Hours} hours, {timeResult.Minutes} minutes, {timeResult.Seconds} seconds and {timeResult.Milliseconds} milliseconds");

                var testExecution = new TestExecution { Fixture = type.Name, Name = method.Name, Result = testResult, Description = testComment, ExecutionTime = timeResult };
                suiteRun.Add(testExecution);
            }
        }

        private static void InvokeMethods(object instance, IEnumerable<MethodInfo> methods)
        {
            foreach (var method in methods)
            {
                method.Invoke(instance, null);
            }
        }
    }

    public static class MethodInfoExt
    {
        public static bool HasAttribute(this MethodInfo met, Type attributeType)
        {
            return met.GetCustomAttributes(attributeType, false).Any();
        }
    }
}
