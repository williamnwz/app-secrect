using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.External.NameGenerator.Interfaces
{
    public interface INameGenerate
    {

        Task<string> Generate(GenderEnum gender, CountryEnum country);
    }
}
