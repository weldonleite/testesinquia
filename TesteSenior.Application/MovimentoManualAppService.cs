using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSenior.Domain.Entities;
using TesteSenior.Domain.Interfaces.Services;
using TesteSenior.Domain.Structure;
using TesteSenior.Repository;

namespace TesteSenior.Application
{
    public class MovimentoManualAppService : IMovimentoManualAppService
    {
        MovimentoManualRepository movRepo;

        public MovimentoManualAppService()
        {
            movRepo = new MovimentoManualRepository();
        }

        public Result GravarMovimento(MovimentoManual mov)
        {
            Result result = new Result();
            if (MovimentoManual.ValidaModelCadastroMovimento(mov))
            {
                result = movRepo.GravarMovimento(mov);
            }
            return result;
        }

        public List<MovimentoManual> Listar()
        {
            return movRepo.Listar();
        }
    }
}
