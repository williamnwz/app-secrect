
namespace AppSecrect.Application.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    /// <summary>
    /// IDtoMapper
    /// </summary>
    public interface IDtoMapper<TDestination, TSource>
    {
        TDestination Convert(TSource source);
    }
}
