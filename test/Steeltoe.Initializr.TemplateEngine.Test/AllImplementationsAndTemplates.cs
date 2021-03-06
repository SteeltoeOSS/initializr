﻿// Copyright 2017 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Steeltoe.Initializr.TemplateEngine.Services;
using Steeltoe.Initializr.TemplateEngine.Services.Mustache;

namespace Steeltoe.Initializr.TemplateEngine.Test
{
    public class AllImplementationsAndTemplates : IEnumerable<object[]>
    {
        private readonly List<object[]> _data;

        public AllImplementationsAndTemplates()
        {
            IConfigurationRoot configuration = TestHelper.GetConfiguration();
            var implementation = new MustacheTemplateService(configuration, new LoggerFactory().CreateLogger<MustacheTemplateService>());

            _data = new[]
            {
                new object[] {implementation, Constants.Steeltoe24, Constants.NetCoreApp21, Constants.WebApi},
                new object[] {implementation, Constants.Steeltoe24, Constants.NetCoreApp31, Constants.WebApi},
                new object[] {implementation, Constants.Steeltoe30, Constants.NetCoreApp31, Constants.WebApi},
            }.ToList();

        }

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
