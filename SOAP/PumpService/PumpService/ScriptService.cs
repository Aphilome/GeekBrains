﻿using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PumpService
{
    public class ScriptService : IScriptService
    {
        private CompilerResults results = null;
        private readonly IStatisticsService _statisticsService;
        private readonly ISettingsService _settingsService;
        private readonly IPumpServiceCallback _pumpServiceCallback;

        public ScriptService(
            IPumpServiceCallback callback,
            ISettingsService serviceSettings,
            IStatisticsService statisticsService)
        {
            _settingsService = serviceSettings;
            _statisticsService = statisticsService;
            _pumpServiceCallback = callback;
        }

        public bool Compile()
        {
            try
            {
                var compilerParameters = new CompilerParameters
                {
                    GenerateInMemory = true
                };
                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Data.dll");
                compilerParameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

                var fileStream = new FileStream(_settingsService.FileName, FileMode.Open);
                byte[] buffer;
                try
                {
                    var length = (int)fileStream.Length;
                    buffer = new byte[length];
                    int count;
                    var sum = 0;
                    while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                        sum += count;
                }
                finally
                {
                    fileStream.Close();
                }
                var provider = new CSharpCodeProvider();
                results = provider.CompileAssemblyFromSource(compilerParameters, System.Text.Encoding.UTF8.GetString(buffer));
                if (results.Errors != null && results.Errors.Count != 0)
                {
                    var compileErrors = string.Empty;
                    for (var i = 0; i < results.Errors.Count; i++)
                    {
                        if (compileErrors != string.Empty)
                        {
                            compileErrors += "\n";
                        }
                        compileErrors += results.Errors[i];
                    }

                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Run(int count)
        {
            if (results == null || (results != null && results.Errors != null && results.Errors.Count > 0))
            {
                if (Compile() == false)
                {
                    return;
                }
            }

            var t = results.CompiledAssembly.GetType("Sample.SampleScript");
            if (t == null)
            {
                return;
            }
            var entryPointMethod = t.GetMethod("EntryPoint");
            if (entryPointMethod == null)
            {
                return;
            }

            Task.Run(() =>
            {
                for (var i = 0; i < count; i++)
                {
                    if ((bool)entryPointMethod.Invoke(Activator.CreateInstance(t), null))
                    {
                        _statisticsService.SuccessTacts++;
                    }
                    else
                    {
                        _statisticsService.ErrorTacts++;
                    }
                    _statisticsService.AllTacts++;
                    _pumpServiceCallback.UpdateStatistics((StatisticsService)_statisticsService);
                    Thread.Sleep(1000);
                }
            });
        }
    }
}