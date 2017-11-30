using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RAT.AsyncFileIO.IO
{
    public interface IFileHelper
    {
        Task<bool> ExistsAsync(string filename);
        Task WriteTextAsync(string filename, string text);
        Task<string> ReadTextAsync(string filename);
        Task<IEnumerable<string>> GetFilesAsync();
        Task DeleteAsync(string filename);
    }
}