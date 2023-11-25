using Assets.Code.Application.Commons.Interfaces.Services;
using Code.Application.Commons.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Application.Modules.Game.Queries.IsSaveFileExist
{
    public class IsSaveFileExistQueryHandler : IQueryHandler<IsSaveFileExistQuery, bool>
    {
        private readonly ISavingService _savingService;

        public IsSaveFileExistQueryHandler(ISavingService savingService)
        {
            _savingService = savingService;
        }

        public bool Handle(IsSaveFileExistQuery query)
        {
            return _savingService.IsSaveFileExist();
        }
    }
}
