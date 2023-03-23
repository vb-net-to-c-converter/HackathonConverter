using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonConverter.Services.Interfaces;
public interface ICopyProjectService
{
    void CopySourceProjectExcludingVbFiles();
    string? GetNewBasePath();
}