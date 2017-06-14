using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Data
{
    public class SandboxRepository : ISandboxRepository
    {
        SandboxContext _ctx;

        public SandboxRepository(SandboxContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Pog> GetPogs()
        {
            return _ctx.Pogs.OrderBy(o => o.Name).ToList().AsQueryable();
        }

        public IQueryable<PogDetail> GetPogDetailsByPogId(int pogId)
        {
            return _ctx.PogDetails.Where(i => i.PogId == pogId).AsQueryable();
        }

        public IQueryable<PogFile> GetPogFilesByPogId(int pogId)
        {
            return _ctx.PogFiles.Where(i => i.PogId == pogId).AsQueryable();
        }

    }
}