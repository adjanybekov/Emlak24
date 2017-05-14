using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Wohnungstausch24.Core.TypeMapping
{
    public interface IAutoMapperTypeConfigurator
    {
        void Configure(IMapperConfigurationExpression cfg);
    }
}
