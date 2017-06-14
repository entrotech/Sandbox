using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Data
{
    public interface ISandboxRepository
    {
        IQueryable<Pog> GetPogs();
        IQueryable<PogDetail> GetPogDetailsByPogId(int pogId);
        IQueryable<PogFile> GetPogFilesByPogId(int pogId);

    }
}