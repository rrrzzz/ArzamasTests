using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Tests
{
    public static class Measurement
    {
        private static void Main(string[] args)
        {
            RunAndGetTestStats();
            Console.ReadLine();
        }

        public static void RunAndGetTestStats()
        {
            var testAssembly = Assembly.GetCallingAssembly();
            var types = testAssembly.GetTypes().Where(x => x.Name != "TestMeasure" &&
                                                           x.GetCustomAttributes(typeof (TestFixtureAttribute), false).Length > 0);
            foreach (var type in types)
            {
                var methods = type.GetMethods();
                var tearDownMethods = methods.Where(x => x.GetCustomAttributes(typeof (TearDownAttribute), false).Length > 0).ToList();
                var setUpMethods = methods.Where(x => x.GetCustomAttributes(typeof(SetUpAttribute), false).Length > 0).ToList();
                var testMethods = methods.Where(x => x.GetCustomAttributes(typeof(TestAttribute), false).Length > 0).ToList();
                bool hasSetUp = setUpMethods.Any();
                bool hasTear = tearDownMethods.Any();
                var instance = Activator.CreateInstance(type);
                foreach (var method in testMethods)
                {
                    string testResult = null;
                    var watch = Stopwatch.StartNew();
                    if (hasSetUp)
                        InvokeMethods(instance, setUpMethods);

                    try
                    {
                        method.Invoke(instance, null);
                        testResult = "Passed";
                    }
                    catch (TargetInvocationException ex)
                    {
                        testResult = "Failed, because" + ex.InnerException.Message;
                    }
                    if (hasTear)
                        InvokeMethods(instance, tearDownMethods);
                    watch.Stop();
                    var timeResult = watch.Elapsed;
                    Console.WriteLine($"Test: {method.Name}\nfrom Fixture: {type.Name}\nhas run with result: {testResult}" +
                                      $"\nin {timeResult.Hours} hours, {timeResult.Minutes} minutes, {timeResult.Seconds} seconds and {timeResult.Milliseconds} milliseconds");
                }
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
}
