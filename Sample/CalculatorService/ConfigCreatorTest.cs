﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using CalculatorService.Interface;
using Gigya.Microdot.Interfaces.Configuration;
using Gigya.Microdot.Ninject;
using Gigya.Microdot.ServiceProxy.Caching;

namespace CalculatorService
{
    public class ConfigCreatorTest
    {
        //private readonly IConfiguration _config;
        private readonly Func<CacheConfig> _config;
        private readonly ISourceBlock<MyConfig> _myConfigSource;
        private readonly Func<ISourceBlock<CacheConfig>> _cacheConfigSource;

        public ConfigCreatorTest(Func<CacheConfig> config, ISourceBlock<MyConfig> myConfigSource, Func<ISourceBlock<CacheConfig>> cacheConfigSource)
        {
            _config = config;
            _myConfigSource = myConfigSource;
            _cacheConfigSource = cacheConfigSource;
        }
        //public ConfigCreatorTest(Func<CacheConfig> config)
        //{
        //    _config = config;
        //}

        public CacheConfig GetConfig()
        {
            //return _config.GetObject<CacheConfig>();
            return _config();
        }

        public ISourceBlock<CacheConfig> GetISourceBlock()
        {
            return _cacheConfigSource();
        }
    }
}