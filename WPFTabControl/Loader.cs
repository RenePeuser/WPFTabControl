using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WPFTabControl
{
    public class Loader<T>
    {
        private const string Dll = "*.dll";
        private readonly object _parameter;
        private readonly bool _parameterless;

        public List<T> Libraries
        {
            get;
            private set;
        }

        public Loader(object parameter)
        {
            _parameter = parameter;
            _parameterless = false;
            GetProcs(Environment.CurrentDirectory);
        }

        public Loader()
        {
            _parameterless = true;
            GetProcs(Environment.CurrentDirectory);
        }

        private void GetProcs(string dir)
        {
            Libraries = new List<T>();

            var files = Directory.GetFiles(dir, Dll, SearchOption.AllDirectories);
            foreach (var s in files)
            {
                try
                {
                    LoadAssembly(s);
                }
                catch (Exception e)
                {
                    var isMyException = (e is BadImageFormatException) || (e is ReflectionTypeLoadException);
                    if (!isMyException) throw;
                }
            }
        }

        private object CreateInstance(Type assemblyType, Type instanceType, string path)
        {
            object retval = null;
            if (assemblyType.GetInterface(instanceType.FullName) == instanceType)
            {
                if (assemblyType.IsClass)
                {
                    var handle = Activator.CreateInstanceFrom(path, assemblyType.FullName, false,
                                                              BindingFlags.Instance | BindingFlags.Public, null, new object[] { _parameter },
                                                              System.Threading.Thread.
                                                                  CurrentThread.
                                                                  CurrentUICulture, null, null);
                    if (handle != null) retval = handle.Unwrap();
                }
            }
            return retval;
        }

        private static object CreateInstanceParameterless(Type assemblyType, Type instanceType, string path)
        {
            object retval = null;
            if (assemblyType.GetInterface(instanceType.FullName) == instanceType)
            {
                if (assemblyType.IsClass)
                {
                    var handle = Activator.CreateInstanceFrom(path, assemblyType.FullName, false,
                                                              BindingFlags.Instance | BindingFlags.Public, null, null,
                                                              System.Threading.Thread.
                                                                  CurrentThread.
                                                                  CurrentUICulture, null, null);
                    if (handle != null) retval = handle.Unwrap();
                }
            }
            return retval;
        }

        public void LoadAssembly(string filename)
        {
            if (!File.Exists(filename)) return;
            var assembly = Assembly.LoadFile(filename);
            if (assembly == null) return;
            var t = assembly.GetTypes();
            foreach (var type in t)
            {
                try
                {
                    object mod;
                    if (_parameterless) mod = (T)CreateInstanceParameterless(type, typeof(T), filename);
                    else mod = (T)CreateInstance(type, typeof(T), filename);
                    if (Equals(mod, default(T))) continue;
                    Libraries.Add((T)mod);
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}