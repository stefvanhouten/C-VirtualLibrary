using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpLibrary.Data
{
    public interface IBookRepo
    {
        int GetBookById(int id);
    }
}
