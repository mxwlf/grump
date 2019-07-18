using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace grump.core
{
    public interface IConfigurationProvider
    {
        Task<T> GetConfigurationItemAsync<T>(string configurationItemId);

        Task<string> GetStringConfigurationItemAsync(string configurationItemId);



    }
}
